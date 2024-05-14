using System.Collections.ObjectModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;

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
        string userNombre = Preferences.Get("UserNombre", "Nombre por defecto");
        string userApellido = Preferences.Get("UserApellido", "Apellido por defecto");
        string userDireccion = Preferences.Get("UserDireccion", "Direccion por defecto");
        string userTelefono = Preferences.Get("UserTelefono", "Telefono por defecto");
        string userEmail = Preferences.Get("UserEmail", "email@default.com");
        string userContrasena = Preferences.Get("UserContrasena", "Pass por defecto");
        string userRol = Preferences.Get("UserRol", "Rol por defecto");

        // Establecer los valores en las etiquetas
        txtNombres.Text = userNombre;
        txtApellidos.Text = userApellido; 
        txtDireccion.Text = userDireccion;
        txtTelefono.Text = userTelefono;
        txtEmailReg.Text = userEmail;
        


        
    }
}


