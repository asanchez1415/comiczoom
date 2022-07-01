using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class StockComics
    {
        public int Contador { get; set; }
        //
        public int idCOM { get; set; }
        public int idSUC { get; set; }
        //
        public int Cantidad { get; set; }
        public string NombreComic { get; set; }
        public string NombreSucursal { get; set; }

        public DateTime Fecha { get; set; }
        public int TipoTransacción { get; set; }

        private List<StockComics> ListCOM { get; set; } = new List<StockComics>();

        public List<StockComics> ListarStockComics(string pNomCom, string pNomSuc)
        {
            ListCOM = new List<StockComics>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT C.id idCOM, C.nombre nombreC, S.id idSUC, S.nombre nombreS
                                FROM COMIC C, SUCURSAL S
								WHERE C.nombre LIKE '%{pNomCom}%'
								AND S.nombre LIKE '%{pNomSuc}%';", connection.connectDb);

            registros = querySel.ExecuteReader();

            int count = 1;

            while (registros.Read())
            {
                var registro = new StockComics()
                {
                    Contador = count,
                    idCOM = Convert.ToInt32(registros["idCOM"]),
                    NombreComic = registros["nombreC"].ToString(),
                    idSUC = Convert.ToInt32(registros["idSUC"]),
                    NombreSucursal = registros["nombreS"].ToString()
                };
                ListCOM.Add(registro);
                count++;
            }
            connection.Close();

            return ListCOM;
        }
        public int CalcularStock(int pCOM, int pSUC)
        {
            ListCOM = new List<StockComics>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT idCOM, idSUC, fecha, hora,
                        SUM(cantidad * case when tipoTransaccion = 0 then 1 else -1 END) as movimientos 
                        FROM STOCK_COMIC
                        WHERE idCOM = {pCOM} AND idSUC = {pSUC}
                        GROUP BY idCOM, idSUC, fecha, hora", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new StockComics()
                {
                    Cantidad = Convert.ToInt32(registros["movimientos"]),
                };
                ListCOM.Add(registro);
            }
            connection.Close();

            int stock = 0;
            for (int i = 0; i < ListCOM.Count; i++)
            {
                stock += ListCOM[i].Cantidad;
            }

            return stock;
        }

        public void SumarComics(int pIdSUC, int pIdCOM, int pCantidad)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO STOCK_COMIC (idSUC, idCOM, cantidad, fecha, hora, tipoTransaccion)
                VALUES ({pIdSUC}, {pIdCOM}, {pCantidad}, '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                '{DateTime.Now.ToString("HH:mm:ss")}', 0);";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        public void RestarComics(int pIdSUC, int pIdCOM, int pCantidad)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO STOCK_COMIC (idSUC, idCOM, cantidad, fecha, hora, tipoTransaccion)
                VALUES ({pIdSUC}, {pIdCOM}, {pCantidad}, '{DateTime.Now.ToString("yyyy-MM-dd")}', 
                '{DateTime.Now.ToString("HH:mm:ss")}', 1);";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }
    }
}