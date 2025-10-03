using PromoWeb.Datos;

namespace PromoWeb.Negocio
{
    public class VoucherNegocio
    {
        private readonly VoucherDatos _datos = new VoucherDatos();

        public bool EsValidoDisponible(string codigo) =>
            _datos.ExisteDisponible(codigo);

        public void MarcarParaCliente(string codigo, int idCliente) =>
            _datos.AsignarACliente(codigo, idCliente);
    }
}
