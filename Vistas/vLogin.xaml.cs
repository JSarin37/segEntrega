using Newtonsoft.Json;
using segEntrega.Modelos;

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
        try
    {
        using (var client = new HttpClient())
        {
            var values = new Dictionary<string, string>
            {
                { "email", txtEmail.Text },
                { "password", txtPassword.Text }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://172.28.80.1/segentrega/login.php", content);

            if (response.IsSuccessStatusCode)
            {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(responseString);

                    // Guardar los datos del usuario usando Preferences
                    Preferences.Set("UserId", user.codigo.ToString());
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
                await DisplayAlert("Error", "Email o contraseña incorrectos.", "OK");
            }
        }
    }
    catch (Exception ex)
    {
        await DisplayAlert("Error", "Un error ocurrió: " + ex.Message, "Cerrar");
    }
        
        
    }

}