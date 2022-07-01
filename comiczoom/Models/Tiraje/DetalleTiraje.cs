using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.Tiraje
{
    public class DetalleTiraje
    {
        public int Id { get; set; }
        public int IdCom { get; set; }
        public string NombreCom { get; set; }
        public int IdTir { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnit { get; set; }
        public decimal PrecioTotal { get; set; }
        //
        public int Count { get; set; }
        private List<DetalleTiraje> ListDetalleTir { get; set; } = new List<DetalleTiraje>();

        public void InsertarDetallesPorTiraje(int pIdTir, string pIdCom, int pCantidad, decimal pPrecioU)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO DETALLE_TIRAJE (idTIR, idCOM, cantidad, precioUnit, precioTotal)
                        VALUES ({pIdTir}, {pIdCom}, {pCantidad}, {pPrecioU}, {pCantidad * pPrecioU});";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        public List<DetalleTiraje> ObtenerDetalleTir(int pId)
        {
            int id = Convert.ToInt32(pId);

            ListDetalleTir = new List<DetalleTiraje>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT DT.id id, DT.idTIR, C.id idCOM,
                                    C.nombre comic, DT.cantidad, DT.precioUnit, DT.precioTotal
                                    FROM DETALLE_TIRAJE DT
                                    INNER JOIN COMIC as C ON DT.idCOM = C.id
									WHERE DT.idTIR = {pId};", connection.connectDb);

            registros = querySel.ExecuteReader();

            int count = 1;
            while (registros.Read())
            {
                var registro = new DetalleTiraje()
                {
                    Count = count,
                    Id = (int)registros["id"],
                    IdTir = (int)registros["idTIR"],
                    IdCom = (int)registros["idCOM"],
                    NombreCom = registros["comic"].ToString(),
                    Cantidad = (int)registros["cantidad"],
                    PrecioUnit = Convert.ToDecimal(registros["precioUnit"]),
                    PrecioTotal = Convert.ToDecimal(registros["precioTotal"]),
                };

                ListDetalleTir.Add(registro);
                count++;
            }
            connection.Close();

            return ListDetalleTir;
        }
    }
}