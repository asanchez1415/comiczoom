using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class TipoEmpleado
    {
        public int IdTE { get; set; }
        public string NomTE { get; set; }

        private List<TipoEmpleado> ListTE { get; set; } = new List<TipoEmpleado>();

        public List<TipoEmpleado> ComboTE()
        {
            ListTE = new List<TipoEmpleado>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM TIPO_EMPLEADO;",
                connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new TipoEmpleado()
                {
                    IdTE = (int)registros["id"],
                    NomTE = registros["nombre"].ToString(),
                };

                ListTE.Add(registro);
            }
            connection.Close();

            return ListTE;
        }

        public List<TipoEmpleado> NombreTE(int pId)
        {
            ListTE = new List<TipoEmpleado>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM TIPO_EMPLEADO WHERE id like '%{pId}%';",
                connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new TipoEmpleado()
                {
                    IdTE = (int)registros["id"],
                    NomTE = registros["nombre"].ToString(),
                };

                ListTE.Add(registro);
            }
            connection.Close();

            return ListTE;
        }

    }
}