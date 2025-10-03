using System;

namespace PromoWeb.Datos
{
    public class VoucherDatos
    {
        public bool ExisteDisponible(string codigo)
        {
            var datos = new AccesoDatos();
            try
            {
                datos.SetConsulta(
                    "SELECT COUNT(1) FROM Vouchers WHERE CodigoVoucher=@cod AND IdCliente IS NULL");
                datos.SetParametro("@cod", codigo);
                var r = datos.EjecutarEscalar();
                int n = (r == null || r == DBNull.Value) ? 0 : Convert.ToInt32(r);
                return n > 0;
            }
            finally
            {
                datos.Cerrar();
            }
        }

        public void AsignarACliente(string codigo, int idCliente)
        {
            var datos = new AccesoDatos();
            try
            {
                datos.SetConsulta(
                    "UPDATE Vouchers SET IdCliente=@cli WHERE CodigoVoucher=@cod AND IdCliente IS NULL");
                datos.SetParametro("@cli", idCliente);
                datos.SetParametro("@cod", codigo);
                datos.EjecutarEscalar();
            }
            finally
            {
                datos.Cerrar();
            }
        }
    }
}
