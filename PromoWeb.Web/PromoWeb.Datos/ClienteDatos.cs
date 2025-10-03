using System;
using PromoWeb.Dominio;

namespace PromoWeb.Datos
{
    public class ClienteDatos
    {
        public Cliente ObtenerPorDni(string dni)
        {
            var datos = new AccesoDatos();
            datos.SetConsulta(@"
                SELECT TOP 1 Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP
                FROM Clientes
                WHERE Documento = @dni");
            datos.SetParametro("@dni", dni);
            datos.EjecutarLectura();

            Cliente c = null;
            if (datos.Lector.Read())
            {
                c = new Cliente
                {
                    Id = (int)datos.Lector["Id"],
                    DNI = datos.Lector["Documento"].ToString(),
                    Nombre = datos.Lector["Nombre"].ToString(),
                    Apellido = datos.Lector["Apellido"].ToString(),
                    Email = datos.Lector["Email"].ToString(),
                    Direccion = datos.Lector["Direccion"].ToString(),
                    Ciudad = datos.Lector["Ciudad"].ToString(),
                    CP = datos.Lector["CP"].ToString()
                };
            }

            datos.Cerrar();
            return c;
        }

        public int Guardar(Cliente c)
        {
            var datos = new AccesoDatos();

            if (c.Id > 0)
            {
                datos.SetConsulta(@"
                    UPDATE Clientes
                    SET Documento = @dni, Nombre = @nom, Apellido = @ape, Email = @mail,
                        Direccion = @dir, Ciudad = @ciu, CP = @cp
                    WHERE Id = @id");
                datos.SetParametro("@id", c.Id);
                datos.SetParametro("@dni", c.DNI ?? "");
                datos.SetParametro("@nom", c.Nombre ?? "");
                datos.SetParametro("@ape", c.Apellido ?? "");
                datos.SetParametro("@mail", c.Email ?? "");
                datos.SetParametro("@dir", c.Direccion ?? "");
                datos.SetParametro("@ciu", c.Ciudad ?? "");
                datos.SetParametro("@cp", c.CP ?? "");
                datos.EjecutarAccion();
                datos.Cerrar();
                return c.Id;
            }
            else
            {
                datos.SetConsulta(@"
                    INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)
                    VALUES (@dni, @nom, @ape, @mail, @dir, @ciu, @cp);
                    SELECT SCOPE_IDENTITY();");
                datos.SetParametro("@dni", c.DNI ?? "");
                datos.SetParametro("@nom", c.Nombre ?? "");
                datos.SetParametro("@ape", c.Apellido ?? "");
                datos.SetParametro("@mail", c.Email ?? "");
                datos.SetParametro("@dir", c.Direccion ?? "");
                datos.SetParametro("@ciu", c.Ciudad ?? "");
                datos.SetParametro("@cp", c.CP ?? "");
                var id = Convert.ToInt32(datos.EjecutarEscalar());
                datos.Cerrar();
                return id;
            }
        }

        public void MarcarVoucherParaCliente(string codigoVoucher, int idCliente)
        {
            var datos = new AccesoDatos();
            datos.SetConsulta(@"
                UPDATE Vouchers
                SET Usado = 1, IdCliente = @cli, FechaUso = GETDATE()
                WHERE Codigo = @cod AND Usado = 0");
            datos.SetParametro("@cli", idCliente);
            datos.SetParametro("@cod", codigoVoucher);
            datos.EjecutarAccion();
            datos.Cerrar();
        }
    }
}
