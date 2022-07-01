using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.Tiraje
{
    public class DRecepcionTir
    {
        public int IdCom { get; set; }
        public int Contador { get; set; }
        public string NombreCom { get; set; }
        public int IdTIR { get; set; }// no es propio de la clase
        public int IdRecTir { get; set; }
        public int Cantidad { get; set; }

        public int CantidadARecepcionar(int pIdTir, int pIdCOM, int pCantidad)
        {
            List<DRecepcionTir> ListCantidades = new List<DRecepcionTir>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT DRT.idCOM, RT.idTIR, RT.id idRT, DRT.cantidad
                                FROM DETALLE_RECEPCION_TIRAJE DRT
                                INNER JOIN RECEPCION_TIRAJE as RT ON DRT.idRT = RT.id
								WHERE RT.idTIR = {pIdTir} AND DRT.idCOM = {pIdCOM};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new DRecepcionTir()
                {
                    IdRecTir = (int)registros["idRT"],
                    IdCom = (int)registros["idCOM"],
                    IdTIR = (int)registros["idTIR"],
                    Cantidad = (int)registros["cantidad"],
                };
                ListCantidades.Add(registro);
            }
            connection.Close();

            for (int i = 0; i < ListCantidades.Count; i++)
            {
                pCantidad -= ListCantidades[i].Cantidad;
            }

            return pCantidad;
        }

        public void InsertarUnDetalleDeRTIR(int pIdCom, int pIdRT, int pCantidad)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO DETALLE_RECEPCION_TIRAJE(idCOM, idRT, cantidad) 
                        VALUES ({pIdCom}, {pIdRT}, {pCantidad});";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        public List<DRecepcionTir> ObtenerDetallePorRT(int pIdRT)
        {
            List<DRecepcionTir> ListDRecs = new List<DRecepcionTir>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT C.nombre comic, DRT.idRT, DRT.cantidad,
                        DRT.idCOM
                        FROM DETALLE_RECEPCION_TIRAJE DRT
                        INNER JOIN COMIC AS C ON DRT.idCOM = C.id
                        WHERE DRT.idRT = {pIdRT};";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);
            registros = querySel.ExecuteReader();

            int contador = 1;
            while (registros.Read())
            {
                var registro = new DRecepcionTir()
                {
                    Contador = contador,
                    IdRecTir = (int)registros["idRT"],
                    IdCom = (int)registros["idCOM"],
                    NombreCom = registros["comic"].ToString(),
                    Cantidad = (int)registros["cantidad"],
                };
                ListDRecs.Add(registro);
                contador++;
            }
            connection.Close();
            return ListDRecs;
        }
    }
}