using System;
using CAI2023.Datos;
using CAI2023.Entidades;

namespace CAI2023.Negocio
{
	public class ReporteNegocio
	{
        //public ReportedeStockcrítico();
        //public Reportedeproductomásvendidoporcategoría();

        private readonly VentaNegocio ventaDatos;

        public List<Venta> ReporteVentasPorCategoria()
        {
            List<Venta> ventas = VentaDatos.(idCategoria);

            List<Venta> reporteVentas = ventas.FindAll(v => v.Id == IdCategoria);

            return reporteVentas;
        }

        public List<Venta> ReporteVentasPorVendedor(int idVendedor)
        {
            List<Venta> ventas = ventaDatos.TraerVentas();

            List<Venta> reporteVentas = ventas.FindAll(v => v.Id == idVendedor);

            return reporteVentas;
        }
    }
}