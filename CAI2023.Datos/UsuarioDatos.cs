    using System;
    using CAI2023.Datos.Utilidades;
    using Microsoft.Win32;
    using System.Collections.Specialized;
    using CAI2023.Entidades;
    using Newtonsoft.Json;
using System.Data.SqlTypes;

namespace CAI2023.Datos
{
    public class UsuarioDatos

    {
        public TransactionResult Agregarusuario(AdministradorNegocio usuario)
        {
            NameValueCollection obj = ReverseMap(usuario);

            string json = WebHelper.Post("Usuario/AgregarUsuario", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Cambiarcontrasena(AdministradorNegocio usuario)
        {
            NameValueCollection obj = ReverseMap(usuario);

            string json = WebHelper.Patch("Usuario/CambiarContraseña", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Login(AdministradorNegocio usuario)
        {
            NameValueCollection obj = ReverseMap(usuario); //serializacion -> json

            string json = WebHelper.Post("Usuario/Login", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public List<AdministradorNegocio> TraerUsuariosActivos()
        {
            string json2 = WebHelper.Get("Usuario/TraerUsuariosActivos" + ToString()); // trae un texto en formato json de una web
            List<AdministradorNegocio> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult EliminarUsuario(AdministradorNegocio usuario)
        {
            NameValueCollection obj = ReverseMap(usuario);

            string json = WebHelper.Delete("Usuario/BajaUsuario", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }

        public TransactionResult Reactivarusuario(AdministradorNegocio usuario)
        {
            NameValueCollection obj = ReverseMap(usuario);

            string json = WebHelper.Patch("Usuario/ReactivarUsuario", obj);

            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);

            return lst;
        }
        private NameValueCollection ReverseMap(AdministradorNegocio usuario)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Nombre", usuario.Nombre);
            n.Add("Apellido", usuario.Apellido);
            n.Add("Direccion", usuario.Direccion);
            n.Add("Telefono", usuario.Telefono.ToString());
            n.Add("Email", usuario.Email);
            n.Add("Usuario", usuario.NombreUsuario.ToString());
            n.Add("Contraseña", usuario.Contraseña);
            return n;

    }

    private List<AdministradorNegocio> MapList(string json)
        {
            List<AdministradorNegocio> lst = JsonConvert.DeserializeObject<List<AdministradorNegocio>>(json); // deserializacion
            return lst;
        }

        private AdministradorNegocio MapObj(string json)
        {
            AdministradorNegocio lst = JsonConvert.DeserializeObject<AdministradorNegocio>(json); // deserializacion
            return lst;
        }
    }
}
  

