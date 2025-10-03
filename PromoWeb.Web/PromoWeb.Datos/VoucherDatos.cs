using System;

namespace PromoWeb.Datos
{
    public class VoucherDatos
    {
        // Supuesto de tabla del script: Vouchers(CodigoVoucher PK, IdCliente NULL => no usado)
        public bool ExisteDisponible(string codigo)
        {
            using (var datos = new AccesoDatos())
            {
                datos.SetConsulta(
                    "SELECT COUNT(1) FROM Vouchers WHERE CodigoVoucher=@cod AND (IdCliente IS NULL)");
                datos.SetParametro("@cod", codigo);
                var r = datos.EjecutarEscalar();
                var n = (r == null || r == DBNull.Value) ? 0 : Convert.ToInt32(r);
                return n > 0;
            }
        }
    }
}
