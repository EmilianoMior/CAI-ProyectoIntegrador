using System;
using CAI2023.Datos;
using CAI2023.Entidades;

namespace CAI2023.Negocio
{
	public class SupervisorNegocio : UsuarioNegocio
	{
        public static void AltaDeProducto(Producto nuevoProducto)
        {
            listaProductos.Add(nuevoProducto);
            Console.WriteLine("Producto agregado con éxito.");
        }

        public static void BajaDeProducto(int id)
        {
            Producto productoAEliminar = listaProductos.Find(p => p.Id == id);
            if (productoAEliminar != null)
            {
                listaProductos.Remove(productoAEliminar);
                Console.WriteLine("Producto dado de baja con éxito.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public static void ModificacionDeProducto(int id, string nuevoNombre, double nuevoPrecio, int nuevoStock)
        {
            Producto productoAModificar = listaProductos.Find(p => p.Id == id);
            if (productoAModificar != null)
            {
                productoAModificar.Nombre = nuevoNombre;
                productoAModificar.Precio = nuevoPrecio;
                productoAModificar.Stock = nuevoStock;
                Console.WriteLine("Producto modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public static void DevolucionDeProducto(int id, int cantidad)
        {
            Producto productoADevolver = listaProductos.Find(p => p.Id == id);
            if (productoADevolver != null)
            {
                if (productoADevolver.Stock >= cantidad)
                {
                    productoADevolver.Stock -= cantidad;
                    Console.WriteLine("Devolución de producto realizada con éxito.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente stock para la devolución.");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
    }
}

