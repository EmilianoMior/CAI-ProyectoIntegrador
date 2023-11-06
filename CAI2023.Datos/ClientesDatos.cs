using System;
using CAI2023.Datos.Utilidades;
using Microsoft.Win32;
using System.Collections.Specialized;
using CAI2023.Entidades;
using Newtonsoft.Json;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace CAI2023.Datos
{
    public class ClientesDatos
    {
        public class ClienteDatos
        {
            public List<Cliente> TraerTodos()
            {
                string json2 = WebHelper.Get("/cliente/GetClientes" + ToString()); // trae un texto en formato json de una web
                List<Cliente> resultado = MapList(json2);
                return resultado;
            }

            public List<Cliente> TraerCliente()
            {
                string json2 = WebHelper.Get("/cliente/GetCliente" + ToString()); // trae un texto en formato json de una web
                List<Cliente> resultado = MapList(json2);
                return resultado;
            }

            public TransactionResult AgregarCliente(Cliente cliente)
            {
                NameValueCollection obj = ReverseMap(cliente); //serializacion -> json

                string json = WebHelper.Post("Cliente/AgregarCliente", obj);

                TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

                return lst;
            }

            public TransactionResult BajaCliente(Cliente cliente)
            {
                NameValueCollection obj = ReverseMap(cliente);

                string json = WebHelper.Delete("Cliente/BajaCliente", obj);

                TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

                return lst;
            }

            public TransactionResult ActualizarCliente(Cliente cliente)
            {
                NameValueCollection obj = ReverseMap(cliente);

                string json = WebHelper.Patch("Cliente/PatchCliente", obj);

                TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

                return lst;
            }


            public TransactionResult ReactivarCliente(Cliente cliente)
            {
                NameValueCollection obj = ReverseMap(cliente);

                string json = WebHelper.Patch("Cliente/ReactivarCliente", obj);

                TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

                return lst;
            }

            private List<Cliente> MapList(string json)
            {
                List<Cliente> lst = JsonConvert.DeserializeObject<List<Cliente>>(json); // deserializacion
                return lst;
            }

            private Cliente MapObj(string json)
            {
                Cliente lst = JsonConvert.DeserializeObject<Cliente>(json); // deserializacion
                return lst;
            }

            private NameValueCollection ReverseMap(Cliente cliente)
            {
                NameValueCollection n = new NameValueCollection();
                n.Add("id", cliente.Id.ToString());
                n.Add("Nombre", cliente.Nombre);
                n.Add("Apellido", cliente.Apellido);
                n.Add("Direccion", cliente.Direccion);
                n.Add("Telefono", cliente.Telefono);
                n.Add("Email", cliente.Email);
                n.Add("FechaAlta", cliente.FechaAlta.ToString("yyyy-MM-dd"));
                n.Add("FechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
                n.Add("FechaBaja", cliente.FechaBaja.ToString("yyyy-MM-dd"));
                n.Add("IdUsuario", cliente.IdUsuario.ToString());
                n.Add("Host", cliente.Host.ToString());
                n.Add("Dni", cliente.DNI.ToString());
                return n;
            }
        }
    }
}

