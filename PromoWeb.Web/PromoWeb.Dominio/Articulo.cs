namespace PromoWeb.Dominio
{
    using System.Collections.Generic;

    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenPrincipal { get; set; }
        public List<string> Imagenes { get; set; } = new List<string>();
    }
}
