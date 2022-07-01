using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models.Tiraje
{
    public class Tirajes
    {
        public int Id { get; set; }
        //
        public int IdSUC { get; set; }
        public string Sucursal { get; set; }
        //
        public string NumEstado { get; set; }
        //
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public decimal PrecioTotalCosto { get; set; }
        private List<Tirajes> ListTirajes { get; set; } = new List<Tirajes>();

        public List<Tirajes> ListarTirajes(string pSucursal, string pFecha, string pEstado)
        {
            ListTirajes = new List<Tirajes>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT T.id, T.fecha, T.hora, SUC.nombre sucursal,
            T.estado, SUM(precioTotal) precioTotalT
            FROM DETALLE_TIRAJE DT
            INNER JOIN TIRAJE as T ON DT.idTIR = T.id
            INNER JOIN SUCURSAL as SUC ON T.idSUC = SUC.id
            WHERE SUC.id like '%{pSucursal}%' AND
            T.estado like '%{pEstado}%' AND
			T.fecha LIKE '%{pFecha}%'
			COLLATE Latin1_general_CI_AI
            GROUP BY T.id, T.fecha, T.hora, SUC.nombre, 
			T.estado;";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Tirajes()
                {
                    Id = (int)registros["id"],
                    Fecha = Convert.ToDateTime(registros["fecha"]),
                    Hora = registros["hora"].ToString(),
                    Sucursal = registros["sucursal"].ToString(),
                    NumEstado = registros["estado"].ToString(),
                    PrecioTotalCosto = Convert.ToDecimal(registros["precioTotalT"]),
                };

                ListTirajes.Add(registro);
            }

            connection.Close();
            return ListTirajes;
        }

        public int InsertarTiraje(int pIdSuc)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO TIRAJE (idSUC, estado, fecha, hora)
                         VALUES ({pIdSuc}, 0, '{DateTime.Now.ToString("yyyy-MM-dd")}',
                         '{DateTime.Now.ToString("HH:mm:ss")}')
                         SELECT @@IDENTITY AS id;";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            int idIngresado = Convert.ToInt32(queryInsert.ExecuteScalar());

            connection.Close();
            return idIngresado;
        }

        public void EliminarTiraje(int pIdTIR)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad1 = $@"DELETE FROM TIRAJE WHERE id = {pIdTIR}";
            string cad2 = $@"DELETE FROM DETALLE_TIRAJE WHERE idTIR = {pIdTIR}";

            SqlCommand queryDelete1 = new SqlCommand(cad1, connection.connectDb);
            SqlCommand queryDelete2 = new SqlCommand(cad2, connection.connectDb);

            queryDelete2.ExecuteNonQuery();
            queryDelete1.ExecuteNonQuery();

            connection.Close();
        }

        public List<Tirajes> ObtenerTiraje(int pId)
        {
            ListTirajes = new List<Tirajes>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT T.id id, SUC.nombre sucursal
                                  FROM TIRAJE T 
                                  INNER JOIN SUCURSAL as SUC ON T.idSUC = SUC.id
                                  WHERE T.id = {pId};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Tirajes()
                {
                    Id = (int)registros["id"],
                    Sucursal = registros["sucursal"].ToString(),
                };
                ListTirajes.Add(registro);
            }
            connection.Close();

            return ListTirajes;
        }

        public void ActualizarEstado(int pId, int pEstado)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE TIRAJE SET estado = {pEstado}
                         WHERE id = {pId}";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }
    }
}