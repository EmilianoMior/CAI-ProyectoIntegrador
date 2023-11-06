using System;
namespace CAI2023.Entidades
{
	public class Venta
	{
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }

        public Venta(int id, int idCliente, int idProducto, int cantidad, DateTime fechaAlta, string estado, int idUsuario)
        {
            Id = id;
            IdCliente = idCliente;
            IdProducto = idProducto;
            Cantidad = cantidad;
            FechaAlta = fechaAlta;
            Estado = estado;
            IdUsuario = idUsuario;
        }
    }
}