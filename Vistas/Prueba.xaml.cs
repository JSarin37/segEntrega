namespace segEntrega.Vistas;

public partial class Prueba : ContentPage
{
	public Prueba()
	{
		InitializeComponent();
        LoadUserData();
    }

    private void LoadUserData()
    {
        // Recuperar los datos del usuario desde Preferences
        string userCodigo = Preferences.Get("UserCodigo", string.Empty);
        string userNombre = Preferences.Get("UserNombre", string.Empty);
        string userApellido = Preferences.Get("UserApellido", string.Empty);
        string userDireccion = Preferences.Get("UserDireccion", "Apellido por defecto");
        string userTelefono = Preferences.Get("UserTelefono", string.Empty);
        string userEmail = Preferences.Get("UserEmail", string.Empty);
        string userContrasena = Preferences.Get("UserContrasena", string.Empty);
        string userRol = Preferences.Get("UserRol", string.Empty);

        // Verificación temporal de los valores recuperados
        Console.WriteLine("Recuperado User Codigo: " + userCodigo);
        Console.WriteLine("Recuperado User Nombre: " + userNombre);
        Console.WriteLine("Recuperado User Apellido: " + userApellido);
        Console.WriteLine("Recuperado User Direccion: " + userDireccion);
        Console.WriteLine("Recuperado User Telefono: " + userTelefono);
        Console.WriteLine("Recuperado User Email: " + userEmail);

        // Asignar los datos a los Entry
        codigoEntry.Text = userCodigo;
        nombreEntry.Text = userNombre;
        apellidoEntry.Text = userApellido;
        direccionEntry.Text = userDireccion;
        telefonoEntry.Text = userTelefono;
        emailEntry.Text = userEmail;
        contrasenaEntry.Text = userContrasena;
        rolEntry.Text = userRol;
    }
}
