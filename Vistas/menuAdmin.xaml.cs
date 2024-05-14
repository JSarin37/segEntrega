namespace segEntrega.Vistas;

public partial class menuAdmin : ContentPage
{
	public menuAdmin()
	{
		InitializeComponent();
	}

    private async void btnlistaPer_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        string option = button.Text;
        await DisplayAlert("Ha seleccionado", option, "OK");
        await Navigation.PopModalAsync();
    }

    private async void btnregPer_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnlistaUsu_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void btnlistaPedidos_Clicked(object sender, EventArgs e)
    {

    }
}