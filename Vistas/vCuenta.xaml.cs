using System.Collections.ObjectModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using segEntrega.Modelos;

namespace segEntrega.Vistas;

public partial class vCuenta : ContentPage
{

    public vCuenta()
    {
        InitializeComponent();
        LoadUserData();
        
    }

    private void LoadUserData()
    {
        // Recuperar los datos del usuario desde Preferences
        int userCodigo = int.Parse(Preferences.Get("UserCodigo", "0"));
        string userNombre = Preferences.Get("UserNombre", "Nombre por defecto");
        string userApellido = Preferences.Get("UserApellido", "Apellido por defecto");
        string userDireccion = Preferences.Get("UserDireccion", "Direccion por defecto");
        string userTelefono = Preferences.Get("UserTelefono", "Telefono por defecto");
        string userEmail = Preferences.Get("UserEmail", "email@default.com");

        // Establecer los valores en las etiquetas
        txtCodigo.Text = userCodigo.ToString();       
        txtNombres.Text = userNombre;
        txtApellidos.Text = userApellido; 
        txtDireccion.Text = userDireccion;
        txtTelefono.Text = userTelefono;
        txtEmailReg.Text = userEmail;
        
      
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        
    }
  
}


