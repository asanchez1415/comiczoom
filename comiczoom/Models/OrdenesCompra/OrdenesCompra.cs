using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using prueba.Models;

namespace prueba.Models.OrdenesCompra
{
    public class OrdenesCompra
    {
        public int Id { get; set; }
        //
        public int IdProv { get; set; }
        public string Proveedor { get; set; }
        //
        public int IdSUC { get; set; }
        public string Sucursal { get; set; }
        //
        public string NumEstado { get; set; }
        //
        public DateTime FechaHora { get; set; }

        // Solo en la lista
        public decimal PrecioTotalOC { get; set; }
        private List<OrdenesCompra> ListOC { get; set; } = new List<OrdenesCompra>();

        public List<OrdenesCompra> ListarProveedores(string pProveedor, string pSucursal, string pFecha, string pEstado)
        {
            ListOC = new List<OrdenesCompra>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT OC.id, PRO.nombre proveedor, OC.fechaHora, SUC.nombre sucursal,
            OC.estado, SUM(precioTotal) precioTotalOC
            FROM DETALLE_OC DOC
            INNER JOIN ORDEN_COMPRA as OC ON DOC.idOC = OC.id
            INNER JOIN SUCURSAL as SUC ON OC.idSUC = SUC.id
            INNER JOIN PROVEEDOR as PRO ON OC.idSUC = PRO.id
            WHERE PRO.id like '%{pProveedor}%' AND
            SUC.id like '%{pSucursal}%' AND
            OC.estado like '%{pEstado}%' AND
			CONVERT(VARCHAR(25), OC.fechaHora, 126) LIKE '%{pFecha}%'
			COLLATE Latin1_general_CI_AI
            GROUP BY OC.id, OC.fechaHora, SUC.nombre, PRO.nombre, OC.estado;";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new OrdenesCompra()
                {
                    Id = (int)registros["id"],
                    Proveedor = registros["proveedor"].ToString(),
                    FechaHora = Convert.ToDateTime(registros["fechaHora"]),
                    Sucursal = registros["sucursal"].ToString(),
                    NumEstado = registros["estado"].ToString(),
                    PrecioTotalOC = Convert.ToDecimal(registros["precioTotalOC"]),
                };

                ListOC.Add(registro);
            }

            connection.Close();
            return ListOC;
        }

        public int InsertarOC(int pIdSuc, int pIdProv)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO ORDEN_COMPRA (idSUC, idPRV, estado, fechaHora)
                         VALUES ({pIdSuc}, {pIdProv}, 0, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd")}')
                         SELECT @@IDENTITY AS id;";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            int idIngresado = Convert.ToInt32(queryInsert.ExecuteScalar());

            connection.Close();
            return idIngresado;
        }

        public void EliminarOC(int pIdOC)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad1 = $@"DELETE FROM ORDEN_COMPRA WHERE id = {pIdOC}";
            string cad2 = $@"DELETE FROM DETALLE_OC WHERE idOC = {pIdOC}";

            SqlCommand queryDelete1 = new SqlCommand(cad1, connection.connectDb);
            SqlCommand queryDelete2 = new SqlCommand(cad2, connection.connectDb);

            queryDelete2.ExecuteNonQuery();
            queryDelete1.ExecuteNonQuery();

            connection.Close();
        }
    }
}