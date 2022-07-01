using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class StockInsumos
    {
        public int Contador { get; set; }
        //
        public int idINS { get; set; }
        public int idSUC { get; set; }
        //
        public int Cantidad { get; set; }
        public string NombreInsumo { get; set; }
        public string NombreSucursal { get; set; }

        public DateTime Fecha { get; set; }
        public int TipoTransacción { get; set; }

        private List<StockInsumos> ListSI { get; set; } = new List<StockInsumos>();
        

        public List<StockInsumos> ListarStockInsumos(string pNomIns, string pNomSuc)
        {
            ListSI = new List<StockInsumos>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT I.id idINS, I.nombre nombreI, S.id idSUC, S.nombre nombreS
                                FROM INSUMO I, SUCURSAL S
                                WHERE I.nombre LIKE '%{pNomIns}%'
                                AND S.nombre LIKE '%{pNomSuc}%';", connection.connectDb);

            registros = querySel.ExecuteReader();

            int count = 1;

            while (registros.Read())
            {
                var registro = new StockInsumos()
                {
                    Contador = count,
                    idINS = Convert.ToInt32(registros["idINS"]),
                    NombreInsumo = registros["nombreI"].ToString(),
                    idSUC = Convert.ToInt32(registros["idSUC"]),
                    NombreSucursal = registros["nombreS"].ToString()
                };
                ListSI.Add(registro);
                count++;
            }
            connection.Close();

            return ListSI;
        }

        public int CalcularStock(int pINS, int pSUC)
        {

            ListSI = new List<StockInsumos>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT idINS, idSUC, fecha, hora,
                        SUM(cantidad * case when tipoTransaccion = 0 then 1 else -1 END) as movimientos 
                        FROM STOCK_INSUMO
                        WHERE idINS = {pINS} AND idSUC = {pSUC}
                        GROUP BY idINS, idSUC, fecha, hora", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new StockInsumos()
                {
                    Cantidad = Convert.ToInt32(registros["movimientos"]),
                };
                ListSI.Add(registro);
            }
            connection.Close();

            int stock = 0;
            for (int i = 0; i < ListSI.Count; i++)
            {
                stock += ListSI[i].Cantidad;
            }

            return stock;

        }
    }
}