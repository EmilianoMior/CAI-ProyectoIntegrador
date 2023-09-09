using CAI2023.Modelo;

namespace CAI2023.Negocio
{
    public class ValidacionUsuario
    {
        public static bool ValidarUsuario(Usuario usuario)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(usuario.NombreUsuario))
            {
                Console.WriteLine("Completar nombre usuario");
                valid = false;
            }
            else if (usuario.NombreUsuario.Length < 8 || usuario.NombreUsuario.Length > 15)
            {
                Console.WriteLine("El nombre de usuario debe tener entre 8 y 15 caracteres.");
                valid = false;
                return;
            }

            else if (usuario.NombreUsuario.Contains(usuario.Nombre) || usuario.NombreUsuario.Contains(usuario.Apellido))
            {
                Console.WriteLine("El nombre de usuario no puede contener ni el nombre ni el apellido del usuario.");
                valid = false;
                return;
            }
                
           

            return valid;
        }
    }
}