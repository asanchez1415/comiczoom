using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Venta
    {
        public int IdVEN { get; set; }

        public int IdSUC { get; set; }
        public string Sucursal { get; set; }

        public int IdCLI { get; set; }
        public string NombreCLI{ get; set; }

        public int IdEMP { get; set; }
        public string NombreEMP { get; set; }

        public DateTime FechaHora { get; set; }

        public decimal ValorVenta { get; set; }


        public List<Venta> ListarVentas(string pSucursal, string pIdCLI, string pIdEMP, string pIdVEN)
        {
            List<Venta> ListVentas= new List<Venta>();
            ListVentas = new List<Venta>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT V.id idVEN, S.id idSUC, S.nombre sucursal,
            C.id idCLI, CONCAT(C.nombre,' ', C.apellido,' ', C.segApellido) AS nombreCLI,
            E.id idEMP, CONCAT(E.nombre,' ', E.apellido,' ', E.segApellido) AS nombreEMP,
            V.fechaHora, SUM(DV.precioTotal) AS precioVenta
            FROM DETALLE_VENTA DV
            INNER JOIN VENTA AS V ON DV.idVEN = V.id
            INNER JOIN SUCURSAL AS S ON V.idSUC = S.id
            INNER JOIN CLIENTE AS C ON V.idCLI = C.id
            INNER JOIN EMPLEADO AS E ON V.idEMP = E.id
            WHERE S.id like '%{pSucursal}%' AND
            V.id like '%{pIdVEN}%' AND
            C.id like '%{pIdCLI}%' AND
            E.id like '%{pIdEMP}%' COLLATE Latin1_general_CI_AI
            GROUP BY V.id, S.id, S.nombre, C.id, E.id, fechaHora,
            C.nombre, C.apellido, C.segApellido,
            E.nombre, E.apellido, E.segApellido
            ORDER BY V.id ASC;";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Venta()
                {
                    IdVEN = (int)registros["idVEN"],
                    IdSUC = (int)registros["idSUC"],
                    Sucursal = registros["sucursal"].ToString(),
                    IdCLI = (int)registros["idCLI"],
                    NombreCLI = registros["nombreCLI"].ToString(),
                    IdEMP = (int)registros["idEMP"],
                    NombreEMP = registros["nombreEMP"].ToString(),
                    FechaHora = Convert.ToDateTime(registros["fechaHora"]),
                    ValorVenta = Convert.ToDecimal(registros["precioVenta"]),
                };
                ListVentas.Add(registro);
            }
            connection.Close();

            return ListVentas;
        }

        public int InsertarVenta(int pIdSuc, int pIdCLI, int pIdEMP)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO VENTA (idSUC, idCLI, idEMP, fechaHora)
                         VALUES ({pIdSuc}, {pIdCLI}, {pIdEMP},
                         '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')
                         SELECT @@IDENTITY AS id;";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            int idIngresado = Convert.ToInt32(queryInsert.ExecuteScalar());

            connection.Close();
            return idIngresado;
        }
    }
}