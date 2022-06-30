using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.OrdenesCompra
{
    public class RecepcionOC
    {
        public int ID { get; set; }
        public int IdOC { get; set; }

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

    }
}