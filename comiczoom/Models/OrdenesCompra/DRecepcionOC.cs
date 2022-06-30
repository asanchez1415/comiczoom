using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.OrdenesCompra
{
    public class DRecepcionOC
    {
        public int IdIns { get; set; }
        public int IdOC{ get; set; }
        public int IdRO { get; set; }
        public int Cantidad { get; set; }

        
        public int CantidadARecepcionar(int pIdOC, int pIdINS, int pCantidad)
        {
            List<DRecepcionOC> ListCantidades  = new List<DRecepcionOC>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT DRO.idINS, RO.idOC, RO.id idRO, DRO.cantidad
                                FROM DETALLE_RECEPCION_OC DRO
                                INNER JOIN RECEPCION_OC as RO ON DRO.idRO = RO.id
                                WHERE RO.idOC = {pIdOC} AND idINS = {pIdINS};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new DRecepcionOC()
                {
                    IdOC = (int)registros["idOC"],
                    IdIns = (int)registros["idINS"],
                    IdRO = (int)registros["idRO"],
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

        public void InsertarUnDetalleDeRO(int pIdINS, int pIdRO, int pCantidad)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO DETALLE_RECEPCION_OC (idINS, idRO, cantidad) 
                        VALUES ({pIdINS}, {pIdRO}, {pCantidad});";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

    }
}