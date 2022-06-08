using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class Provincia
    {
        public int IdProv { get; set; }
        public string NomProvincia { get; set; }

        private List<Provincia> ListComboProv { get; set; } = new List<Provincia>();

        public List<Provincia> ComboProv()
        {
            ListComboProv = new List<Provincia>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM PROVINCIA;",
                connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Provincia()
                {
                    IdProv = (int)registros["id"],
                    NomProvincia = registros["nombre"].ToString(),
                };

                ListComboProv.Add(registro);
            }
            connection.Close();

            return ListComboProv;
        }
    }
}