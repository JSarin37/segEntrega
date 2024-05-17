namespace segEntrega.Vistas;

public partial class vEntregas : ContentPage
{
	public vEntregas()
	{
		InitializeComponent();
	}

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new vMenuPrincipal(), true);
    }
}