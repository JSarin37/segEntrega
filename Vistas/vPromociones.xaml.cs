namespace segEntrega.Vistas;

public partial class vPromociones : ContentPage
{
	public vPromociones()
	{
		InitializeComponent();
	}

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new vMenuPrincipal(), true);
    }
}