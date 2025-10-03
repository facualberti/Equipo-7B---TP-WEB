using System;
using PromoWeb.Dominio;

namespace PromoWeb.Datos
{
    public class ClienteDatos
    {
        public Cliente ObtenerPorDni(string dni)
        {
            using (var datos = new AccesoDatos())
            {
                datos.SetConsulta(@"SELECT Id, DNI, Nombre, Apellido, Email, Direccion, Ciudad, CP
                                    FROM Clientes WHERE DNI = @dni");
                datos.SetParametro("@dni", dni);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    var c = new Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        DNI = datos.Lector["DNI"] as string,
                        Nombre = datos.Lector["Nombre"] as string,
                        Apellido = datos.Lector["Apellido"] as string,
                        Email = datos.Lector["Email"] as string,
                        Direccion = datos.Lector["Direccion"] as string,
                        Ciudad = datos.Lector["Ciudad"] as string,
                        CP = datos.Lector["CP"] as string
                    };
                    datos.Cerrar();
                    return c;
                }

                datos.Cerrar();
                return null;
            }
        }
    }
}
