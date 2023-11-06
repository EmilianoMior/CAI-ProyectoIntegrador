 using System;
using System.Net.NetworkInformation;
using CAI2023.Entidades;
using CAI2023.Consola.Utilidades;
using CAI2023.Negocio;
namespace CAI2023.Consola
{
    public class Program
    {
        private static UsuarioNegocio usuarioNegocio;
        private static ProveedorNegocio proveedorNegocio;
        private static AdministradorNegocio administradorNegocio;
        private static VentaNegocio ventaNegocio;
        private static ProductoNegocio productoNegocio;
        private static ReporteNegocio reporteNegocio;

        public static void Main(string[] args)
        {
            administradorNegocio = new AdministradorNegocio();
            proveedorNegocio = new ProveedorNegocio();
            ventaNegocio = new VentaNegocio();
            reporteNegocio = new ReporteNegocio();
            productoNegocio = new ProductoNegocio();
            usuarioNegocio = new UsuarioNegocio();

            Console.WriteLine("Bienvenido a Cai 2023 - Gestion de Stock!\n");
            Console.ReadLine();

            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("1. Iniciar sesión");
            Console.WriteLine("2. Registrarse");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            int valor;
            valor = Validaciones.PedirInt("\nSeleccione una opcion:", 0, 5);
            Console.Clear();
            do
            {
                switch (valor)
                {
                    case 0:
                        Console.WriteLine("Muchas gracias por usar el sistema!!\nPresiona una tecla para salir");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case 1:
                        Login();
                        break;
                    case 2:
                        AgregarUsuario();
                        break;

                }
            } while (valor != 0);
        }

        public static void MenuAdministrador()
        {
            Console.WriteLine("Esta en el menu Administrador");
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1 - Alta de usuario");
            Console.WriteLine("2 - Modificación de usuarios ");
            Console.WriteLine("3 - Baja de usuarios Supervisores");
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
                case "1":
                    administradorNegocio.AgregarUsuario();
                    break;
                case "2":
                    administradorNegocio.BajaDeUsuario();
                    break;
            }
        }

        private static Usuario AgregarUsuario()
        {
            {
                string nombre = Validaciones.PedirStr("Ingrese el nombre del usuario:");
                string apellido = Validaciones.PedirStr("Ingrese un apellido para el usuario:");
                string direccion = Validaciones.PedirStr("Ingrese una dirección para el usuario:");
                string telefono = Validaciones.PedirStr("Ingrese un numero de teléfono para el usuario:"); ;
                string email = Validaciones.PedirEmail("Ingrese un email para el usuario");
                string nombreusuario = Validaciones.PedirStr("Ingrese un email para el usuario");
                string contraseña = Validaciones.PedirStr("Ingrese una contraseña para el usuario");
                bool ingresar;

                Usuario usuario = new Usuario(nombre, apellido, direccion, telefono, email, nombreusuario, contraseña);
                Console.Clear();
                ingresar = Validaciones.ValidarSN("Está a punto de ingresar el cliente, está de acuerdo?");
                if (ingresar)
                {
                    usuarioNegocio.AgregarUsuario(usuario);
                    Console.WriteLine("Cliente ingresado correctamente! Pulse una tecla para continuar");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ha decidido no ingresar el cliente. Pulse una tecla para continuar");
                    Console.ReadKey();
                    usuario = null;
                }
                return usuario;
            }
        }

        private static void Login()
        {
            var usuarioDatos = new UsuarioNegocio();

            List<Usuario> listaUsuarios = usuarioDatos.TraerUsuarios();

            // Solicitar al usuario que ingrese nombre de usuario y contraseña
            Console.Write("Nombre de Usuario: ");
            string nombreUsuario = Validaciones.PedirStr("Ingrese su nombre de usuario:");
            Console.Write("Contraseña: ");
            string contraseña = Validaciones.PedirStr("Ingrese su contraseña:");

            // Buscar el usuario en la lista
            Usuario usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);

            if (usuarioEncontrado != null)
            {
                Console.WriteLine("Acceso concedido. Bienvenido, " + usuarioEncontrado.Nombre);
            }
            else
            {
                Console.WriteLine("Nombre de usuario o contraseña incorrectos. Acceso denegado.");
            }

            Console.ReadLine();
        }

        public static void MenuSupervisor()
        {

            Console.WriteLine("Menu principal");
            Console.WriteLine("1 - Menu Cliente");

        }

        public static void MenuVendedor()
        {

            Console.WriteLine("Menu principal");
            Console.WriteLine("1 - Menu Cliente");
        }
    }
}

    


  

