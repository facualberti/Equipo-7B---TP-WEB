using System;
using System.Collections.Generic;
using PromoWeb.Dominio;

namespace PromoWeb.Datos
{
    public class ArticuloDatos
    {
        public List<Articulo> ListarPremios()
        {
            var lista = new List<Articulo>();

            using (var datos = new AccesoDatos())
            {
                
                datos.SetConsulta(@"
                    SELECT A.Id,
                           A.Nombre,
                           A.Descripcion,
                           (SELECT TOP 1 I.ImagenUrl
                              FROM Imagenes I
                              WHERE I.IdArticulo = A.Id
                              ORDER BY I.Id) AS ImagenUrl
                    FROM Articulos A
                    ORDER BY A.Id");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    var art = new Articulo
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = datos.Lector["Nombre"] as string ?? "",
                        Descripcion = datos.Lector["Descripcion"] as string ?? "",
                        ImagenUrl = datos.Lector["ImagenUrl"] as string 
                    };
                    lista.Add(art);
                }

                datos.Cerrar();
            }

            return lista;
        }
    }
}
