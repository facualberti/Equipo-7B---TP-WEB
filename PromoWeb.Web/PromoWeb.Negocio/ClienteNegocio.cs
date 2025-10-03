using PromoWeb.Datos;
using PromoWeb.Dominio;

namespace PromoWeb.Negocio
{
    public class ClienteNegocio
    {
        private readonly ClienteDatos _datos = new ClienteDatos();
        public Cliente ObtenerPorDni(string dni) => _datos.ObtenerPorDni(dni);
        public int Guardar(Cliente c) => _datos.Guardar(c);
        public void MarcarVoucherParaCliente(string codigo, int idCliente) => _datos.MarcarVoucherParaCliente(codigo, idCliente);

    }
}
