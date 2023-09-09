namespace CAI2023.Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Perfil { get; set; }
        public bool Activo { get; set; }
        public bool CambiarPassword { get; set; }
        public DateTime FechaPassword { get; set; }

        public Usuario() { }

        public Usuario(int usuarioId, string nombre, string apellido, string mail, string nombreUsuario, string password, string perfil, bool activo, bool cambiarPassword, DateTime fechaPassword)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellido = apellido;
            Email = mail;
            NombreUsuario = nombreUsuario;
            Password = password;
            Perfil = perfil;
            Activo = activo;
            CambiarPassword = cambiarPassword;
            FechaPassword = fechaPassword;
        }
    }
}