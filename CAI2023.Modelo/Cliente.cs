using System;
namespace CAI2023.Entidades
{
	public class Cliente
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaBaja { get; set; }
        public int IdUsuario { get; set; }
        public string Host { get; set; }
        public string DNI { get; set; }

        public Cliente(int id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaAlta, DateTime fechaNacimiento, DateTime fechaBaja, int idUsuario, string host, string dni)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            FechaAlta = fechaAlta;
            FechaNacimiento = fechaNacimiento;
            FechaBaja = fechaBaja;
            IdUsuario = idUsuario;
            Host = host;
            DNI = dni;
        }

        public override string ToString()
        {
            return this.Id + ") " + this.Apellido + ", " + this.Nombre;
        }
    }
}

