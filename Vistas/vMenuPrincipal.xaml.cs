
namespace segEntrega.Vistas;

public partial class vMenuPrincipal : ContentPage
{
	public vMenuPrincipal()
	{
		InitializeComponent();
        ConfigureAdminMenuVisibility();
    }
    private void ConfigureAdminMenuVisibility()
    {
        string userRole = Preferences.Get("UserRol", string.Empty);
        adminMenuSection.IsVisible = userRole == "admin";
    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Vistas.vPromociones());
    }

    private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Vistas.vCuenta());
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Vistas.vEntregas());
    }

    private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Vistas.vSeguimiento());
    }

    private async void btnMenu_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new menuAdmin(), true);
    }
}