using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PromoWeb.Datos
{
    public class AccesoDatos
    {
        private readonly SqlConnection _cn;
        private readonly SqlCommand _cmd;
        private SqlDataReader _dr;

        public SqlDataReader Lector => _dr;

        public AccesoDatos()
        {
            var cs = ConfigurationManager.ConnectionStrings["PromoWebDB"].ConnectionString;
            _cn = new SqlConnection(cs);
            _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
        }

        public void SetConsulta(string sql)
        {
            _cmd.Parameters.Clear();
            _cmd.CommandText = sql;
        }

        public void SetParametro(string nombre, object valor)
        {
            _cmd.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }

        public void EjecutarLectura()
        {
            if (_cn.State != ConnectionState.Open) _cn.Open();
            _dr = _cmd.ExecuteReader();
        }

        public object EjecutarEscalar()
        {
            if (_cn.State != ConnectionState.Open) _cn.Open();
            return _cmd.ExecuteScalar();
        }

        public void EjecutarAccion()
        {
            if (_cn.State != ConnectionState.Open) _cn.Open();
            _cmd.ExecuteNonQuery();
        }

        public void Cerrar()
        {
            try { _dr?.Close(); } catch { }
            try { if (_cn.State != ConnectionState.Closed) _cn.Close(); } catch { }
        }
    }
}
