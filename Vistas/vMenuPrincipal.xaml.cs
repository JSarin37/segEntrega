
using segEntrega.Modelos;
using segEntrega.Vistas;
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
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new vPromociones(), true);
    }

    public async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {
        var user = UserDataHelper.GetUserFromPreferences();
      
        await Navigation.PushModalAsync(new vCuenta(user), true);
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        
        await Navigation.PushModalAsync(new vEntregas(), true);
    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new vSeguimiento(), true);
    }

    private async void btnMenu_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new menuAdmin(), true);
    }

}