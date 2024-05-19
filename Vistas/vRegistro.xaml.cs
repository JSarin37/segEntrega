using Microsoft.Maui;
using System.Xml.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

#if ANDROID
using Android.Content; // Esta directiva using es necesaria para utilizar Intent
#endif



namespace segEntrega.Vistas;

public partial class vRegistro : ContentPage
{
	public vRegistro()
	{
		InitializeComponent();
	}

    private async void btnRegistro_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
            {
                {"nombre", txtNombreReg.Text},
                {"apellido", txtApellidoReg.Text},
                {"direccion", txtDireccionReg.Text},
                {"telefono", txtTelefonoReg.Text},
                {"email", txtEmailReg.Text},
                {"contrasena", txtPasswordReg.Text}
            };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://10.0.2.2/segentrega/usuario/post.php?action=add", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Éxito", "Usuario agregado correctamente.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo agregar el usuario.", "Cerrar");
                }
            }
            
            await Navigation.PushModalAsync(new NavigationPage(new vLogin()), true);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
        
    }

    private async void btnSeleccionar_Clicked(object sender, EventArgs e)
    {
        await SeleccionarImagen();
    }

    private async void btnTomarFotografia_Clicked(object sender, EventArgs e)
    {
        TomarFotografia();
    }

    private async Task TomarFotografia()
    {
        try
        {
            await CheckAndRequestPermissionsAsync();  // Asegúrate de que este método también use async Task

            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                using (var stream = await photo.OpenReadAsync())
                {
                    Imagen.Source = ImageSource.FromStream(() => stream);
                    var filePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                    using var fileStream = File.OpenWrite(filePath);
                    await stream.CopyToAsync(fileStream);
                }
            }
            else
            {
                // Informar al usuario que no se tomó ninguna foto
                await DisplayAlert("Error", "No se pudo tomar una foto.", "OK");
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error", "Cámara no compatible.", "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert("Error", "Permiso de cámara denegado.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al tomar la fotografía: {ex.Message}", "OK");
        }
    }

    private async Task SeleccionarImagen()
    {
        try
        {
            await CheckAndRequestPermissionsAsync();

            var photo = await MediaPicker.PickPhotoAsync();
            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                Imagen.Source = ImageSource.FromStream(() => stream);

                var filePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using var fileStream = File.OpenWrite(filePath);
                await stream.CopyToAsync(fileStream);
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            await DisplayAlert("Error", "Acceso a la galería no compatible", "OK");
        }
        catch (PermissionException pEx)
        {
            await DisplayAlert("Error", "Permiso denegado: " + pEx.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al seleccionar la fotografía: {ex.Message}", "OK");
        }
    }


    private async Task CheckAndRequestPermissionsAsync()
    {
        var readPermissionStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
        if (readPermissionStatus != PermissionStatus.Granted)
        {
            readPermissionStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
        }

        if (readPermissionStatus != PermissionStatus.Granted)
        {
            bool answer = await DisplayAlert("Permiso Denegado",
                "El permiso de lectura de almacenamiento fue denegado. Por favor, habilite el permiso en la configuración de la aplicación.",
                "Abrir Configuración", "Cancelar");

            if (answer)
            {
                OpenAppSettings();
            }
        }
        // Continuar con la funcionalidad que requiere el permiso
    }

    public async Task OpenAppSettings()
    {
        try
        {
            AppInfo.ShowSettingsUI();
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            Debug.WriteLine("Failed to open app settings: " + ex.ToString());
        }
    }
}