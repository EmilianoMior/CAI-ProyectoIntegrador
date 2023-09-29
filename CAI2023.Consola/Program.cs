using System;
using CAI2023.Modelo;
using CAI2023.Negocio;

namespace CAI2023.Consola
{
    public class Program
    {
        private static List<Usuario> usuarioListado = new List<Usuario>();
        private static Usuario usuarioLogeado = null;

        static void Main(string[] args)
        {
            usuarioListado.Add(new Usuario(1, "Emiliano", "Mior", "emiliano@gmail.com", "emior", "1234", "ADMIN", true, false, DateTime.Now));

            Login();

            string opcionMenu;
            do
            {
                switch (usuarioLogeado.Perfil)
                {
                    case "ADMIN": PrintMenuAdminstrador(); break;
                    case "SUPERVISOR": PrintMenuSupervisor(); break;
                }

                Console.WriteLine("99 - Cerrar Sesion");
                Console.WriteLine("0 - Cerrar Programa");
                Console.Write("Opcion: ");
                opcionMenu = Console.ReadLine();

                switch (opcionMenu)
                {
                    case "1": CargarUsuario("SUPERVISOR"); break;
                    case "2": CargarUsuario("VENDEDOR"); break;
                    case "99":
                        Login();
                        break;
                }

            } while (opcionMenu != "0");
        }

        static void Login()
        {
            Console.Clear();

            string nombreUsuario;
            string password;
            int reintentos = 0;

            usuarioLogeado = null;

            while (usuarioLogeado == null)
            {
                Console.Write("Usuario: ");
                nombreUsuario = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();

                foreach (Usuario u in usuarioListado)
                {
                    if (nombreUsuario == u.NombreUsuario && password == u.Password)
                    {
                        usuarioLogeado = u;
                        Console.WriteLine("Usuario Logeado!");
                        Console.WriteLine("Continuar...");

                        if (reintentos >= 3)
                        {
                            usuarioListado[usuarioListado.IndexOf(u)].Activo = false;
                        }

                        if (usuarioLogeado.CambiarPassword == true || CalcularDiferenciaDias(usuarioLogeado.FechaPassword, DateTime.Now) >= 30)
                        {
                            CambiarPassword(usuarioLogeado.UsuarioId);
                        }

                        Console.ReadKey();
                        break;
                    }
                }

                if (usuarioLogeado == null)
                {
                    reintentos++;
                }
            }
        }

        static void CambiarPassword(int usuarioId)
        {
            Console.Clear();
            Console.Write("Nuevo Password: ");
            string nuevoPassword = Console.ReadLine();

            // Agregar validacion de password.

            for (int i = 0; i < usuarioListado.Count; i++)
            {
                if (usuarioListado[i].UsuarioId == usuarioId)
                {
                    usuarioListado[i].Password = nuevoPassword;
                    usuarioListado[i].FechaPassword = DateTime.Now;
                    usuarioListado[i].Activo = true;
                    usuarioListado[i].CambiarPassword = false;
                }
            }

            Console.WriteLine("Password Cambiado!");
            Console.ReadKey();
        }

        static void CargarUsuario(string perfil)
        {
            Usuario nuevoUsuario = new Usuario();

            nuevoUsuario.Activo = false;
            nuevoUsuario.CambiarPassword = true;
            nuevoUsuario.Perfil = perfil;

            Console.Clear();
            Console.WriteLine("Ingrese los datos del Usuario");
            Console.Write("Nombre: ");
            nuevoUsuario.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            nuevoUsuario.Apellido = Console.ReadLine();
            Console.Write("Email: ");
            nuevoUsuario.Email = Console.ReadLine();
            Console.Write("NombreUsuario: ");
            nuevoUsuario.NombreUsuario = Console.ReadLine();
            Console.Write("Password: ");
            
            nuevoUsuario.Password = Console.ReadLine();

            if (ValidacionUsuario.ValidarUsuario(nuevoUsuario))
            {
                nuevoUsuario.UsuarioId = usuarioListado.Count() + 1;
                nuevoUsuario.FechaPassword = DateTime.Now;

                usuarioListado.Add(nuevoUsuario);
                // Usuario Cargado!
            }
            else
            {
                Console.WriteLine("Usuario invalido!");
            }
        }

        static void PrintMenuAdminstrador()
        {
            
            Console.WriteLine("Bienvenido al menu del Administrador");
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1 - Alta de usuarios Supervisores");
            Console.WriteLine("2 - Modificación de usuarios Supervisores ");
            Console.WriteLine("3 - Baja de usuarios Supervisores");
            Console.WriteLine("4 - Alta de usuarios Vendedores");
            Console.WriteLine("5 - Modificación de usuarios Vendedores");
            Console.WriteLine("6 - Baja de usuarios Vendedores");
            Console.WriteLine("7 - Alta de Proveedores");
            Console.WriteLine("8 - Modificación de Proveedores");
            Console.WriteLine("9 - Baja de Proveedores");
            Console.WriteLine("10 - Alta de Productos ");
            Console.WriteLine("11 - Modificación de Productos ");
            Console.WriteLine("12 - Baja de Productos");
            Console.WriteLine("13 - Reporte de stock crítico");
            Console.WriteLine("14 - Reporte de ventas por vendedor ");
            Console.WriteLine("15 - Reporte de productos más vendido por categoría");

            string opcionMenuAdmin;
            opcionMenuAdmin = Console.ReadLine();

            switch (opcionMenuAdmin)
            {
                case "1": BajaDeUsuario(); break;
                case "2": AltaDeUsuario(); ; break;
                
                    
                    break;
            }




        }
        

        static void PrintMenuSupervisor()
        {
            Console.WriteLine("Bienvenido al menu del Supervisor");
            Console.WriteLine("Ingrese una opcion:");
        }

        static int CalcularDiferenciaDias(DateTime fechaInicio, DateTime fechaFin)
        {
            // Calcular la diferencia en días utilizando el método Subtract
            TimeSpan diferencia = fechaFin - fechaInicio;

            // La propiedad TotalDays de TimeSpan devuelve la diferencia en días
            int diferenciaDias = (int)diferencia.TotalDays;

            return Math.Abs(diferenciaDias); // Math.Abs() para asegurarse de que el resultado sea siempre positivo
        }
    }
}
