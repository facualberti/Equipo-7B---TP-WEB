using PromoWeb.Datos;
using PromoWeb.Dominio;

namespace PromoWeb.Negocio
{
    public class ClienteNegocio
    {
        private readonly ClienteDatos _datos = new ClienteDatos();
        public Cliente ObtenerPorDni(string dni) => _datos.ObtenerPorDni(dni);
    }
}
