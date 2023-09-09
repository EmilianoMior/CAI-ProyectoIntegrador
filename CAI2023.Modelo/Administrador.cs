using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI2023.Modelo
{
    class Administrador
    {
        public static void AltaDeUsuario(string nombre, string apellido, string nombreUsuario, string contraseña, bool esAdministrador)
        {
            if (nombreUsuario.Length < 8 || nombreUsuario.Length > 15)
            {
                Console.WriteLine("El nombre de usuario debe tener entre 8 y 15 caracteres.");
                return;
            }

            if (nombreUsuario.Contains(nombre) || nombreUsuario.Contains(apellido))
            {
                Console.WriteLine("El nombre de usuario no puede contener ni el nombre ni el apellido del usuario.");
                return;
            }

            if (!Regex.IsMatch(contraseña, @"^(?=.*[A-Z])(?=.*\d)(?!.*\s).{8,15}$"))
            {
                Console.WriteLine("La contraseña debe tener entre 8 y 15 caracteres, al menos una letra mayúscula y un número.");
                return;
            }

            if (esAdministrador && usuarios.Exists(u => u.EsAdministrador))
            {
                Console.WriteLine("Ya existe un perfil de Administrador.");
                return;
            }
            if (!esAdministrador)
            {
                // Generar una contraseña temporal para Supervisor y Vendedor
                string contraseniaTemporal = GenerarContraseniaTemporal();
                contraseñasTemporales[nombreUsuario] = contraseniaTemporal;
                Console.WriteLine($"Contraseña temporal generada: {contraseniaTemporal}");
            }

            usuarios.Add(usuario);
            Console.WriteLine("Usuario dado de alta correctamente.");

        }
        private static string GenerarContraseniaTemporal()
        {
            // Generar una contraseña temporal aleatoria con los requisitos necesarios
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string contraseniaTemporal = new string(Enumerable.Repeat(caracteres, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return contraseniaTemporal;
        }




    }
}
