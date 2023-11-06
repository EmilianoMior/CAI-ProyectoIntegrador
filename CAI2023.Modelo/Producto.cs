using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI2023.Entidades
{
	public class Producto 
	{
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }

        public Producto(int id, int idCategoria, string nombre, DateTime fechaAlta, DateTime fechaBaja, double precio, int stock, int idUsuario, int idProveedor)
        {
            Id = id;
            IdCategoria = idCategoria;
            Nombre = nombre;
            FechaAlta = fechaAlta;
            FechaBaja = fechaBaja;
            Precio = precio;
            Stock = stock;
            IdUsuario = idUsuario;
            IdProveedor = idProveedor;
        }
    }
}

