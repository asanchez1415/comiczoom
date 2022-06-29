using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.OrdenesCompra
{
    public class DetalleOC
    {
        public int Id { get; set; }
        public int IdIns { get; set; }
        public int IdOC { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnit{ get; set; }
        public decimal PrecioTotal { get; set; }

        public void InsertarDetallesPorOC(int pIdOC, string pIdINS, int pCantidad, decimal pPrecioU)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO DETALLE_OC (idOC, idINS,cantidad, precioUnit, precioTotal)
                        VALUES ({pIdOC}, {pIdINS}, {pCantidad}, {pPrecioU}, {pCantidad * pPrecioU});";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }
    }
}