using System.Collections.Generic;
using PromoWeb.Datos;
using PromoWeb.Dominio;

namespace PromoWeb.Negocio
{
    public class ArticuloNegocio
    {
        private readonly ArticuloDatos _datos = new ArticuloDatos();

        public List<Articulo> ListarPremios() => _datos.ListarPremios();
    }
}
