using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Rubros
    {
        public int IdRUB { get; set; }
        public string Rubro{ get; set; }

        private List<Rubros> ListComboRubro { get; set; } = new List<Rubros>();

        public List<Rubros> ComboRubro()
        {
            ListComboRubro = new List<Rubros>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM RUBRO
            ORDER BY nombre Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Rubros()
                {
                    IdRUB = (int)registros["id"],
                    Rubro = registros["nombre"].ToString(),
                };

                ListComboRubro.Add(registro);
            }
            connection.Close();

            return ListComboRubro;
        }
    }
}
