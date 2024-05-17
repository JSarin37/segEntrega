using Newtonsoft.Json;
using segEntrega.Modelos;
using Microsoft.Maui.Storage;
using System.Diagnostics;

namespace segEntrega.Vistas;

public partial class vLogin : ContentPage
{
    public vLogin()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Vistas.vRegistro());
    }

    private async void btnMenuPrin_Clicked(object sender, EventArgs e)
    {
        using (var client = new HttpClient())
        {
            var values = new Dictionary<string, string>
        {
            { "email", txtEmail.Text },
            { "contrasena", txtPassword.Text }
        };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://10.0.2.2/segentrega/login.php", content);

            try
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseString);
                Console.WriteLine($"Usuario deserializado: {JsonConvert.SerializeObject(user)}");

                if (user != null && user.codigo != 0)
                {
                    // Procesa el usuario como necesites aquí, por ejemplo, cambiar de página o actualizar la UI
                    await Application.Current.MainPage.DisplayAlert("Bienvenido", $"{user.nombre}", "OK");
                    
                    Preferences.Set("UserCodigo", user.codigo.ToString());
                    Preferences.Set("UserNombre", user.nombre);
                    Preferences.Set("UserApellido", user.apellido);
                    Preferences.Set("UserDireccion", user.direccion);
                    Preferences.Set("UserTelefono", user.telefono);
                    Preferences.Set("UserEmail", user.email);
                    Preferences.Set("UserContrasena", user.contrasena);
                    Preferences.Set("UserRol", user.rol);

                    await Navigation.PushAsync(new Vistas.vMenuPrincipal());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Datos del usuario no válidos. JSON recibido: " + responseString, "OK");
                }

            }
            catch (JsonException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error al procesar la respuesta del servidor: " + ex.Message, "OK");
            }
        }
    }
    
}