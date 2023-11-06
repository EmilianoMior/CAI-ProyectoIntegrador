using System;
using CAI2023.Datos;
using CAI2023.Entidades;

namespace CAI2023.Negocio
{
	public class VendedorNegocio
	{
        public static Venta RegistrarNuevaVenta(int idCliente, int idProducto, int cantidad, int idUsuario)
        {
            int nuevaVentaId = GenerarNuevoIdDeVenta(); // Generar un nuevo ID de venta
            DateTime fechaActual = DateTime.Now;
            string estadoInicial = "Pendiente";

            return new Venta(nuevaVentaId, idCliente, idProducto, cantidad, fechaActual, estadoInicial, idUsuario);
        }

        private static int GenerarNuevoIdDeVenta()
        {
            // Simula obtener el último ID de venta registrado en una base de datos.
            int ultimoIdRegistrado = ObtenerUltimoIdDeVentaDesdeBaseDeDatos();

            // Incrementa el último ID en uno para obtener el nuevo ID.
            int nuevoId = ultimoIdRegistrado + 1;

            return nuevoId;
        }

        public void DevolverVenta()
        {
            // Lógica para procesar la devolución de la venta
            if (Estado != "Devuelta")
            {
                Estado = "Devuelta";
                Console.WriteLine($"Venta con ID {Id} devuelta exitosamente.");
            }
            else
            {
                Console.WriteLine($"La venta con ID {Id} ya ha sido devuelta previamente.");
            }
        }

    }
}

