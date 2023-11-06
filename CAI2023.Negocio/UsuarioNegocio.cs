        using CAI2023.Negocio;
        using CAI2023.Datos;
        using CAI2023.Entidades;

    namespace CAI2023.Negocio
    {

    public class UsuarioNegocio
    {
        private readonly UsuarioDatos usuarioDatos;

        public List<Entidades.AdministradorNegocio> TraerUsuarios()
        {
            List<Entidades.AdministradorNegocio> usuarios = usuarioDatos.TraerUsuariosActivos();
            return usuarios;
        }

        public void Login(Entidades.AdministradorNegocio usuario)
        {
            usuarioDatos.Login(usuario);
        }

        public void CambiarContrasena (Entidades.AdministradorNegocio usuario)
        {
            usuarioDatos.Cambiarcontrasena(usuario);
        }

        public void AgregarUsuario(Entidades.AdministradorNegocio usuario)
        {
            usuarioDatos.Agregarusuario(usuario);
        }

 static int CalcularDiferenciaDias(DateTime fechaInicio, DateTime fechaFin)
                    {
                        // Calcular la diferencia en días utilizando el método Subtract
                        TimeSpan diferencia = fechaFin - fechaInicio;

                        // La propiedad TotalDays de TimeSpan devuelve la diferencia en días
                        int diferenciaDias = (int)diferencia.TotalDays;

                        return Math.Abs(diferenciaDias); // Math.Abs() para asegurarse de que el resultado sea siempre positivo
                    }

                    public static bool ValidarUsuario(Entidades.AdministradorNegocio usuario)
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

                        void CambiarContrasena(string nuevaContrasena)
                        {
                            Contrasena = nuevaContrasena;
                            Console.WriteLine("Contraseña cambiada con éxito.");
                        }
                    }
                }
            }
        }