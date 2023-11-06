using System;
using CAI2023.Datos.Utilidades;
using Microsoft.Win32;
using System.Collections.Specialized;
using CAI2023.Entidades;
using Newtonsoft.Json;
using System.Data.SqlTypes;

namespace CAI2023.Datos
{
    public class ProductoDatos
    {
        public List<Producto> TraerTodos()
        {
            string productos = WebHelper.Get("Producto/TraerProductos" + ToString());
            List<Producto> resultado = MapList(productos);
            return resultado;
        }

        public List<Producto> TraerporCategoria()
        {
            string productos = WebHelper.Get("Producto/TraerProductosPorCategoria" + ToString());
            List<Producto> resultado = MapList(productos);
            return resultado;
        }

        public TransactionResult InsertarProducto(Producto producto)
        {
            NameValueCollection obj = ReverseMap(producto);

            string json = WebHelper.Post("Producto/AgregarProducto", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult EliminarProducto(Producto producto)
        {
            NameValueCollection obj = ReverseMap(producto);

            string json = WebHelper.Delete("Producto/BajaProducto", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult ActualizarProducto(Producto producto)
        {
            NameValueCollection obj = ReverseMap(producto);

            string json = WebHelper.Patch("Producto/ModificarProducto", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult ReactivarProducto(Producto producto)
        {
            NameValueCollection obj = ReverseMap(producto);

            string json = WebHelper.Patch("Producto/ReactivarProducto", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        private List<Producto> MapList(string json)
        {
            List<Producto> listProductos = JsonConvert.DeserializeObject<List<Producto>>(json);
            return listProductos;
        }

        private NameValueCollection ReverseMap(Producto producto)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", producto.Id.ToString());
            n.Add("idCategoria", producto.IdCategoria.ToString());
            n.Add("Nombre", producto.Nombre);
            n.Add("FechaAlta", producto.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("FechaBaja", producto.FechaBaja.ToString("yyyy-MM-dd"));
            n.Add("Precio", producto.Precio.ToString());
            n.Add("Stock", producto.Stock.ToString());
            n.Add("IdUsuario", producto.IdUsuario.ToString());
            n.Add("IdProveedor", producto.IdProveedor.ToString());
            return n;
        }
    }
}

