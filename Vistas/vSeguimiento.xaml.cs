namespace segEntrega.Vistas;

public partial class vSeguimiento : ContentPage
{
    public vSeguimiento()
    {
        InitializeComponent();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vistas.vMapa());
    }

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new vMenuPrincipal(), true);
    }
}