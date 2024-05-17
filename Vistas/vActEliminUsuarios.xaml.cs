namespace segEntrega.Vistas;
using segEntrega.Modelos;
using segEntrega.Vistas;
using System.Net;

public partial class vActEliminUsuarios : ContentPage
{
	public vActEliminUsuarios(User datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombres.Text = datos.nombre.ToString();
        txtApellidos.Text = datos.apellido.ToString();
        txtDireccion.Text = datos.direccion.ToString();
        txtTelefono.Text = datos.telefono.ToString();
        txtEmailReg.Text = datos.email.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {

        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection()
        {
            { "codigo", txtCodigo.Text },
            { "nombre", txtNombres.Text },
            { "apellido", txtApellidos.Text },
            { "direccion", txtDireccion.Text },
            { "telefono", txtTelefono.Text },
            { "email", txtEmailReg.Text }
        };

            string url = $"http://10.0.2.2/segentrega/usuario/post.php?codigo={txtCodigo.Text}&nombre={txtNombres.Text}&apellido={txtApellidos.Text}&direccion={txtDireccion.Text}&telefono={txtTelefono.Text}&email={txtEmailReg.Text}";

            byte[] respuesta = cliente.UploadValues(url, "PUT", parametros);
            string respuestaString = System.Text.Encoding.UTF8.GetString(respuesta);

            // Aquí deberías analizar respuestaString para asegurarte de que la actualización fue exitosa
            // Simularemos que la respuesta fue exitosa para seguir con el ejemplo
            if (true) // Reemplaza `true` con la condición real basada en la respuesta del servidor
            {
                // Actualizar las Preferences
                Preferences.Set("UserCodigo", txtCodigo.Text);
                Preferences.Set("UserNombre", txtNombres.Text);
                Preferences.Set("UserApellido", txtApellidos.Text);
                Preferences.Set("UserDireccion", txtDireccion.Text);
                Preferences.Set("UserTelefono", txtTelefono.Text);
                Preferences.Set("UserEmail", txtEmailReg.Text);

                await DisplayAlert("Éxito", "Datos actualizados correctamente", "OK");
                var user = UserDataHelper.GetUserFromPreferences();
                await Navigation.PushAsync(new Vistas.vCuenta(user));
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar la información en el servidor", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var answer = await DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar este usuario?", "Sí", "No");
        if (answer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var requestUri = $"http://10.0.2.2/segentrega/usuario/post.php?codigo={txtCodigo.Text}";
                    var response = await client.DeleteAsync(requestUri);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Éxito", "Usuario eliminado correctamente.", "OK");
                    }
                    else
                    {
                        // Muestra el contenido de la respuesta en caso de error
                        await DisplayAlert("Error", "No se pudo eliminar el usuario: " + responseContent, "Cerrar");
                    }
                }
                await Navigation.PushModalAsync(new vListaUsuarios(), true);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new vListaUsuarios(), true);
    }
}