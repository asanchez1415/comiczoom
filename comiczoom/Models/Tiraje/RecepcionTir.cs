using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.Tiraje
{
    public class RecepcionTir
    {
        public int Id { get; set; }
        public int IdTIR { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public int InsertarCabeceraRec(int pIdTIR)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO RECEPCION_TIRAJE (idTIR, fecha, hora) 
                         VALUES ({pIdTIR}, '{DateTime.Now.ToString("yyyy-MM-dd")}', '{DateTime.Now.ToString("HH:mm:ss")}')
                         SELECT @@IDENTITY AS id;";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            int idIngresado = Convert.ToInt32(queryInsert.ExecuteScalar());

            connection.Close();
            return idIngresado;
        }

        public List<RecepcionTir> ObtenerRecepcionesPorTir(int pIdTir)
        {
            List<RecepcionTir> ListRecs = new List<RecepcionTir>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT *
                        FROM RECEPCION_TIRAJE
                        WHERE idTIR = {pIdTir};";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);
            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new RecepcionTir()
                {
                    Id = (int)registros["id"],
                    IdTIR = (int)registros["idTIR"],
                    Fecha = Convert.ToDateTime(registros["fecha"]),
                    Hora = registros["hora"].ToString(),
                };
                ListRecs.Add(registro);
            }
            connection.Close();

            return ListRecs;
        }
    }
}