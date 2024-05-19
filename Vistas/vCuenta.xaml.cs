using System.Collections.ObjectModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using segEntrega.Modelos;
using System.Net;
using segEntrega.Vistas;

namespace segEntrega.Vistas;

public partial class vCuenta : ContentPage
{

    public vCuenta(User datos)
    {
        InitializeComponent();
        GetUserFromPreferences();
        this.BindingContext = GetUserFromPreferences();
        LoadUserData();
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
                await Navigation.PushModalAsync(new NavigationPage(new vCuenta(user)), true);
                
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


    public User GetUserFromPreferences()
    {
        return new User
        {
            codigo = int.Parse(Preferences.Get("UserCodigo", "0")),
            nombre = Preferences.Get("UserNombre", string.Empty),
            apellido = Preferences.Get("UserApellido", string.Empty),
            direccion = Preferences.Get("UserDireccion", string.Empty),
            telefono = Preferences.Get("UserTelefono", string.Empty),
            email = Preferences.Get("UserEmail", string.Empty)
        };
    }

    private void LoadUserData()
    {
        User user = GetUserFromPreferences();
        txtCodigo.Text = user.codigo.ToString();
        txtNombres.Text = user.nombre;
        txtApellidos.Text = user.apellido;
        txtDireccion.Text = user.direccion;
        txtTelefono.Text = user.telefono;
        txtEmailReg.Text = user.email;
    }

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new vMenuPrincipal()), true);
    }
}

 
