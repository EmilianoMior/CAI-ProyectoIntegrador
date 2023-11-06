namespace CAI2023.Entidades
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public Usuario(string nombre, string apellido, string direccion, int telefono, string email, string nombreusuario, string contraseña)
        {
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            NombreUsuario = nombreusuario;
            Contraseña = contraseña;
        }
    }
}