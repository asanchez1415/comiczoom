using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class Comuna
    {
        public int IdCmn { get; set; }
        public string NomComuna { get; set; }

        private List<Comuna> ListComboCmn { get; set; } = new List<Comuna>();

        public List<Comuna> ComboCmn()
        {
            ListComboCmn = new List<Comuna>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM COMUNA;",
                connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Comuna()
                {
                    IdCmn = (int)registros["id"],
                    NomComuna = registros["nombre"].ToString(),
                };

                ListComboCmn.Add(registro);
            }
            connection.Close();

            return ListComboCmn;
        }
    }
}