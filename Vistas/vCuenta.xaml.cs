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
        GetUserFromPreferences();
        this.BindingContext = GetUserFromPreferences();
        LoadUserData();


    }



    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        
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

}


