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
        public string NombreIns { get; set; }
        public int IdOC { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnit{ get; set; }
        public decimal PrecioTotal { get; set; }
        //
        public int Count { get; set; }
        private List<DetalleOC> ListDetalleOC { get; set; } = new List<DetalleOC>();

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

        public List<DetalleOC> ObtenerDetalleOC(int pId)
        {
            int id = Convert.ToInt32(pId);

            ListDetalleOC = new List<DetalleOC>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT DEOC.id id, DEOC.idOC, INS.id idINS, 
                                    INS.nombre insumo, DEOC.cantidad, DEOC.precioUnit, DEOC.precioTotal
                                    FROM DETALLE_OC DEOC
                                    INNER JOIN INSUMO as INS ON DEOC.idINS = INS.id
                                    WHERE DEOC.idOC = {id};", connection.connectDb);

            registros = querySel.ExecuteReader();

            int count = 1;
            while (registros.Read())
            {
                var registro = new DetalleOC()
                {
                    Count = count,
                    Id = (int)registros["id"],
                    IdOC = (int)registros["idOC"],
                    IdIns = (int)registros["idINS"],
                    NombreIns = registros["insumo"].ToString(),
                    Cantidad = (int)registros["cantidad"],
                    PrecioUnit = Convert.ToDecimal(registros["precioUnit"]),
                    PrecioTotal = Convert.ToDecimal(registros["precioTotal"]),
                };

                ListDetalleOC.Add(registro);
                count++;
            }
            connection.Close();

            return ListDetalleOC;
        }
    }
}