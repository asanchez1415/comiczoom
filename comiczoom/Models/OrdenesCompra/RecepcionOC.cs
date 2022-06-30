using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.OrdenesCompra
{
    public class RecepcionOC
    {
        public int Id { get; set; }
        public int IdOC { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
 
        public int InsertarCabeceraRec(int pIdOC)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO RECEPCION_OC (idOC, fecha, hora) 
                         VALUES ({pIdOC}, '{DateTime.Now.ToString("yyyy-MM-dd")}', '{DateTime.Now.ToString("HH:mm:ss")}')
                         SELECT @@IDENTITY AS id;";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            int idIngresado = Convert.ToInt32(queryInsert.ExecuteScalar());

            connection.Close();
            return idIngresado;
        }

        public List<RecepcionOC> ObtenerRecepcionesPorOC(int pIdOC)
        {
            List<RecepcionOC> ListRecs = new List<RecepcionOC>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT *
                        FROM RECEPCION_OC
                        WHERE idOC = {pIdOC};";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);
            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new RecepcionOC()
                {
                    Id = (int)registros["id"],
                    IdOC = (int)registros["idOC"],
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