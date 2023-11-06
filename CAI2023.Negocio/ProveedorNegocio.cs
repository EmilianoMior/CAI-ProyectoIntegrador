using System;
using CAI2023.Entidades;
using CAI2023.Datos;

namespace CAI2023.Negocio
{
    public class ProveedorNegocio
    {
        private readonly ProveedorDatos proveedorDatos;

        public List<Proveedor> TraerProveedores()
        {
            List<Proveedor> proveedores = proveedorDatos.TraerTodos();

            return proveedores;
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            proveedorDatos.Insertar(proveedor);
        }

        public void EliminarProveedor(Proveedor proveedor)
        {
            proveedorDatos.EliminarProveedor(proveedor);
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            proveedorDatos.ModificarProveedor(proveedor);
        }

        public void ReactivarProveedor(Proveedor proveedor)
        {
            proveedorDatos.Reactivar(proveedor);
        }
        
    }
}

