using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class DetalleVenta
    {
        public int IdVEN { get; set; }
        public int Count { get; set; }
        public int IdCOM { get; set; }
        public string NombreCom { get; set; }
        public int Cantidad { get; set; }
        public decimal precioUnit { get; set; }
        public decimal precioTotal { get; set; }

        public void InsertarDetallePorVenta(int pIdVen, int pIdCom, int pCantidad, decimal pPrecioU)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO DETALLE_VENTA (idVEN, idCOM, cantidad, precioUnit, precioTotal)
                        VALUES ({pIdVen}, {pIdCom}, {pCantidad}, {pPrecioU}, {pCantidad * pPrecioU});";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        public List<DetalleVenta> DetallePorVenta(int pIdVen)
        {
            List<DetalleVenta> ListDetalleVen = new List<DetalleVenta>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT DV.id, DV.idVEN, C.nombre comic,
                                    DV.cantidad, DV.precioUnit, DV.precioTotal
                                    FROM DETALLE_VENTA DV
                                    INNER JOIN COMIC as C ON DV.idCOM = C.id
									WHERE DV.idVEN = {pIdVen};", connection.connectDb);

            registros = querySel.ExecuteReader();

            int count = 1;
            while (registros.Read())
            {
                var registro = new DetalleVenta()
                {
                    Count = count,
                    IdVEN = (int)registros["idVEN"],
                    NombreCom = registros["comic"].ToString(),
                    Cantidad = (int)registros["cantidad"],
                    precioUnit = Convert.ToDecimal(registros["precioUnit"]),
                    precioTotal = Convert.ToDecimal(registros["precioTotal"]),
                };

                ListDetalleVen.Add(registro);
                count++;
            }
            connection.Close();

            return ListDetalleVen;
        }
    }
}