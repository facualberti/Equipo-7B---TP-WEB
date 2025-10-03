using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PromoWeb.Datos
{
    public class AccesoDatos : IDisposable
    {
        private readonly SqlConnection _cn;
        private SqlCommand _cmd;
        private SqlDataReader _dr = null; // inicializado para evitar warning
        public SqlDataReader Lector => _dr;

        public AccesoDatos()
        {
            _cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["PromoWebDB"].ConnectionString);
        }

        public void SetConsulta(string sql)
        {
            _cmd = new SqlCommand(sql, _cn) { CommandType = CommandType.Text };
        }

        public void SetParametro(string nombre, object valor)
        {
            _cmd.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }

        public object EjecutarEscalar()
        {
            if (_cn.State != ConnectionState.Open) _cn.Open();
            return _cmd.ExecuteScalar();
        }

        public void Dispose()
        {
            if (_dr != null && !_dr.IsClosed) _dr.Close();
            if (_cn.State == ConnectionState.Open) _cn.Close();
            _dr?.Dispose(); _cmd?.Dispose(); _cn?.Dispose();
        }
    }
}
