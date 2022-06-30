using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models.EquipoComic
{
    public class EquipoComic
    {
        public int Id { get; set; }
        public int IdCOM { get; set; }
        public DateTime fechaCreacion { get; set; }

        public List<EquipoComic> ListEquipoComic { get; set; } = new List<EquipoComic>();


        //Listar EquipoComics
        public List<EquipoComic> ObtenerEquipoComic(string idCOM)
        {
            ListEquipoComic = new List<EquipoComic>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open(); 

            SqlCommand querySel = new SqlCommand($@"SELECT EC.id FROM EQUIPO_COMIC as EC
                WHERE EC.idCOM like '%{idCOM}%';", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new EquipoComic()
                {
                    Id = (int)registros["id"],
                };

                ListEquipoComic.Add(registro);
            }


            connection.Close();

            return ListEquipoComic;
        }
    }
}