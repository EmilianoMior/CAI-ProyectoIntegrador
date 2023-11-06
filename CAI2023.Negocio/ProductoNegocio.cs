using System;
using CAI2023.Datos;
using CAI2023.Entidades;

namespace CAI2023.Negocio
{
    public class ProductoNegocio
    {
        private readonly ProductoDatos productoDatos;

        public List<Producto> TraerProductos()
        {
            List<Producto> productos = productoDatos.TraerTodos();

            return productos;
        }

        public List<Producto> TraerProductosporCat()
        {
            List<Producto> productos = productoDatos.TraerporCategoria();

            return productos;
        }

        public void CrearProducto(Producto producto)
        {
            productoDatos.InsertarProducto(producto);
        }

        public void EliminarProducto(Producto producto)
        {
            productoDatos.EliminarProducto(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            productoDatos.ActualizarProducto(producto);
        }

        public void ReactivarProducto(Producto producto)
        {
            productoDatos.ReactivarProducto(producto);
        }

        public void ActualizarStock(Producto producto, int cantidad)
        {
            if (producto.Stock >= cantidad)
            {
                producto.Stock -= cantidad;
                productoDatos.ActualizarProducto(producto);
            }
            else
            {
                throw new Exception("No hay más stock del producto que desea vender");
            }
        }
    }
}
