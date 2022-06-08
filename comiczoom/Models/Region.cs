using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class Region
    {
        public int IdReg { get; set; }
        public string NomRegion { get; set; }

        private List<Region> ListComboReg { get; set; } = new List<Region>();

        public List<Region> ComboReg()
        {
            ListComboReg = new List<Region>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM REGION;", 
                connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Region()
                {
                    IdReg = (int)registros["id"],
                    NomRegion = registros["nombre"].ToString(),
                };

                ListComboReg.Add(registro);
            }
            connection.Close();

            return ListComboReg;
        }
    }
}