using System.Collections.Generic;
using PromoWeb.Dominio;

namespace PromoWeb.Datos
{
    public class ArticuloDatos
    {
        public List<Articulo> ListarPremios()
        {
            var lista = new List<Articulo>();
            var map = new Dictionary<int, Articulo>();
            var datos = new AccesoDatos();

            try
            {
                datos.SetConsulta(@"
                    SELECT A.Id, A.Nombre, A.Descripcion, I.ImagenUrl
                    FROM Articulos A
                    LEFT JOIN Imagenes I ON I.IdArticulo = A.Id
                    ORDER BY A.Id, I.Id");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    var id = (int)datos.Lector["Id"];
                    if (!map.TryGetValue(id, out var art))
                    {
                        art = new Articulo
                        {
                            Id = id,
                            Nombre = datos.Lector["Nombre"] as string ?? "",
                            Descripcion = datos.Lector["Descripcion"] as string ?? ""
                        };
                        map.Add(id, art);
                        lista.Add(art);
                    }

                    var url = datos.Lector["ImagenUrl"] as string;
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        art.Imagenes.Add(url);
                        if (string.IsNullOrWhiteSpace(art.ImagenPrincipal))
                            art.ImagenPrincipal = url;
                    }
                }

                foreach (var art in lista)
                {
                    if (string.IsNullOrWhiteSpace(art.ImagenPrincipal))
                        art.ImagenPrincipal = "~/Content/placeholder.png";
                }
            }
            finally
            {
                datos.Cerrar();
            }

            return lista;
        }
    }
}
