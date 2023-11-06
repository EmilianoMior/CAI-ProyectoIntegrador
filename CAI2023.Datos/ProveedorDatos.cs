using System;
using CAI2023.Datos.Utilidades;
using Microsoft.Win32;
using System.Collections.Specialized;
using CAI2023.Entidades;
using Newtonsoft.Json;
using System.Data.SqlTypes;

namespace CAI2023.Datos
{
    public class ProveedorDatos 
    {
        public List<Proveedor> TraerTodos()
        {
            string json2 = WebHelper.Get("Proveedor/TraerProveedores" + ToString()); // trae un texto en formato json de una web
            List<Proveedor> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insertar(Proveedor proveedor)
        {
            NameValueCollection obj = ReverseMap(proveedor); //serializacion -> json

            string json = WebHelper.Post("Proveedor/AgregarProveedor", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult ModificarProveedor(Proveedor proveedor)
        {
            NameValueCollection obj = ReverseMap(proveedor);

            string json = WebHelper.Put("Proveedor/ModificarProveedor", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult EliminarProveedor(Proveedor proveedor)
        {
            NameValueCollection obj = ReverseMap(proveedor);

            string json = WebHelper.Delete("Proveedor/EliminarProveedor", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Reactivar(Proveedor proveedor)
        {
            NameValueCollection obj = ReverseMap(proveedor); //serializacion -> json

            string json = WebHelper.Post("Proveedor/Reactivar", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }


        private List<Proveedor> MapList(string json)
        {
            List<Proveedor> lst = JsonConvert.DeserializeObject<List<Proveedor>>(json); // deserializacion
            return lst;
        }

        private NameValueCollection ReverseMap(Proveedor proveedor)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", proveedor.Id.ToString());
            n.Add("IdProducto", proveedor.IdProducto.ToString());
            n.Add("Nombre", proveedor.Nombre);
            n.Add("FechaAlta", proveedor.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("FechaBaja", proveedor.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("Cuit", proveedor.CUIT.ToString());
            n.Add("Email", proveedor.Email);
            n.Add("Apellido", proveedor.Apellido);
            n.Add("IdUsuario", proveedor.IdUsuario.ToString());
            return n;
        }
    }
}