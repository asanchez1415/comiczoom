using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class PrecioSucursal
    {
        public int Id { get; set; }
        public int IdSUC { get; set; }
        public int IdCOM { get; set; }
        public string Sucursal { get; set; }
        public decimal Normal { get; set; }
        public decimal AlMayor { get; set; }
        public decimal Oferta { get; set; }


        public List<PrecioSucursal> ListPS { get; set; } = new List<PrecioSucursal>();

        public List<PrecioSucursal> ListarPS(int idCOM)
        {
            ListPS = new List<PrecioSucursal>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT  PS.id, PS.idSUC, PS.idCOM, PS.normal, PS.alMayor, PS.oferta, S.nombre
				FROM PRECIO_SUCURSAL as PS
				INNER JOIN SUCURSAL AS S ON PS.idSUC = S.id
                WHERE PS.idCOM like '%{idCOM}%';", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new PrecioSucursal()
                {
                    Id = (int)registros["id"],
                    IdSUC = (int)registros["idSUC"],
                    IdCOM = (int)registros["idCOM"],
                    Normal = (decimal)registros["normal"],
                    AlMayor = (decimal)registros["alMayor"],
                    Oferta = (decimal)registros["oferta"],
                    Sucursal= registros["nombre"].ToString(),
                };

                ListPS.Add(registro);
            }

            connection.Close();
            return ListPS;
        }

        public void InsertarPrecioSucursal(int idSUC, int idCOM)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO PRECIO_SUCURSAL(idSUC, idCOM, normal, alMayor, OFERTA) VALUES
            ('{idSUC}', '{idCOM}', '1000', '500', '750');";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        public List<PrecioSucursal> ObtenerPrecioSucursal(int idPS)
        {
            ListPS = new List<PrecioSucursal>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT * FROM PRECIO_SUCURSAL as PS WHERE PS.id = {idPS};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new PrecioSucursal()
                {
                    Id = (int)registros["id"],
                    IdSUC = Convert.ToInt32(registros["idSUC"]),
                    IdCOM = Convert.ToInt32(registros["idCOM"]),
                    Normal = (decimal)registros["normal"],
                    AlMayor = (decimal)registros["alMayor"],
                    Oferta = (decimal)registros["oferta"],     
                };
                ListPS.Add(registro);
            }

            return ListPS;
        }

        public void ActualizarPrecioSucursal(PrecioSucursal pPS)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE PRECIO_SUCURSAL SET  normal = '{pPS.Normal}', alMayor = '{pPS.AlMayor}', oferta = '{pPS.Oferta}'
            WHERE id = '{pPS.Id}';";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }

        public decimal ObtenerPrecioPorMenor(int pIdSUC, int pIdCOM)
        {
            List<decimal> precios = new List<decimal>(); 
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT normal FROM PRECIO_SUCURSAL as PS 
                        WHERE PS.idSUC = {pIdSUC} AND
                        PS.idCOM = {pIdCOM};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = (decimal)registros["normal"];
             
                precios.Add(registro);
            }

            return precios[0];
        }

        public decimal ObtenerPrecioPorMayor(int pIdSUC, int pIdCOM)
        {
            List<decimal> precios = new List<decimal>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT alMayor FROM PRECIO_SUCURSAL as PS 
                        WHERE PS.idSUC = {pIdSUC} AND
                        PS.idCOM = {pIdCOM};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = (decimal)registros["alMayor"];

                precios.Add(registro);
            }

            return precios[0];
        }
    }
}