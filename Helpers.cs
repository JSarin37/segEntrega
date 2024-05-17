using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using segEntrega.Modelos;

namespace segEntrega
{
    public static class UserDataHelper
    {
        public static User GetUserFromPreferences()
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
    }
}
