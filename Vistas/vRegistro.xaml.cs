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
                var response = await client.PostAsync("http://172.28.80.1/segentrega/post_usu.php?action=add", content);

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
            await Navigation.PushAsync(new Vistas.vLogin());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
        
    }
}