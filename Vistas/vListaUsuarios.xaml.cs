using Newtonsoft.Json;
using System.Collections.ObjectModel;
using segEntrega.Modelos;

namespace segEntrega.Vistas;

public partial class vListaUsuarios : ContentPage
{
    private const string Url = "http://10.0.2.2/segentrega/usuario/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<segEntrega.Modelos.User> usu;
    public vListaUsuarios()
	{
		InitializeComponent();
        Obtener();
    }
    public async void Obtener()
    {
        try
        {
            var content = await cliente.GetStringAsync(Url);
            Console.WriteLine(content);
            List<User> mostrarUsu = JsonConvert.DeserializeObject<List<User>>(content);
            usu = new ObservableCollection<User>(mostrarUsu);
            listaUsuarios.ItemsSource = usu;

            if (usu.Count > 0)
            {



            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener datos: {ex.Message}");
            
        }
    }

     private async void listaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objetousuario = (segEntrega.Modelos.User)e.SelectedItem;
        
        await Navigation.PushModalAsync(new vActEliminUsuarios(objetousuario), true);
    }

    private async void btnIngreso_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new vRegistro(), true);
    }

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new vMenuPrincipal(), true);
    }
}