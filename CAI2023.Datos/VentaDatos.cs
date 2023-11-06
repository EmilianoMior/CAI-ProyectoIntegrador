    using System;
    using CAI2023.Datos.Utilidades;
    using Microsoft.Win32;
    using System.Collections.Specialized;
    using Newtonsoft.Json;
    using CAI2023.Entidades;


    namespace CAI2023.Datos
    {
            public class VentaDatos
            {
                public List<Venta> TraerTodos()
                {
                    string ventas = WebHelper.Get("Venta/GetVenta" + ToString());
                    List<Venta> resultado = MapList(ventas);
                    return resultado;
                }

                public TransactionResult AgregarVenta(Venta venta)
                {
                    NameValueCollection obj = ReverseMap(venta);

                    string json = WebHelper.Post("Venta/AgregarVenta", obj);

                    TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

                    return lst;
                }

                public TransactionResult DevolverVenta(Venta venta)
                {
                    NameValueCollection obj = ReverseMap(venta);

                    string json = WebHelper.Post("Venta/Devolver", obj);

                    TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

                    return lst;
                }

            private List<Venta> MapList(string json)
            {
                List<Venta> listVentas = JsonConvert.DeserializeObject<List<Venta>>(json);
                return listVentas;
            }

            private NameValueCollection ReverseMap(Venta venta)
                {
                    NameValueCollection n = new NameValueCollection();
                    n.Add("Id", venta.Id.ToString());
                    n.Add("IdCliente", venta.IdCliente.ToString());
                    n.Add("IdProducto", venta.IdProducto.ToString());
                    n.Add("Cantidad", venta.Cantidad.ToString());
                    n.Add("FechaAlta", venta.FechaAlta.ToString("yyyy-MM-dd"));
                    n.Add("Estado", venta.Estado.ToString());
                    n.Add("IdUsuario", venta.IdUsuario.ToString());
                return n;
                }
            }
        }

