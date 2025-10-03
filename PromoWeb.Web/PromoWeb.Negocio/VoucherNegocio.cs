using PromoWeb.Datos;

namespace PromoWeb.Negocio
{
    public class VoucherNegocio
    {
        private readonly VoucherDatos _datos = new VoucherDatos();

        public bool EsValidoDisponible(string codigoVoucher)
        {
            if (string.IsNullOrWhiteSpace(codigoVoucher)) return false;
            return _datos.ExisteDisponible(codigoVoucher.Trim().ToUpper());
        }
    }
}
