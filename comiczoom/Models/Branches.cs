using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class Branches
    {
        // Atributos sucursal
        public int IdSUC { get; set; }
        public string Sucursal { get; set; }

        private List<Branches> ListComboSucursal { get; set; } = new List<Branches>();

        public List<Branches> ComboSucursal()
        {
            ListComboSucursal = new List<Branches>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM SUCURSAL
            ORDER BY nombre Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Branches()
                {
                    IdSUC = (int)registros["id"],
                    Sucursal = registros["nombre"].ToString(),
                };

                ListComboSucursal.Add(registro);
            }
            connection.Close();

            return ListComboSucursal;
        }
    }
}