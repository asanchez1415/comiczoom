using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class Branches
    {
        // Atributos sucursal
        public int IdSUC { get; set; }
        //
        public int idREG { get; set; }
        public string REG { get; set; }
        //
        public int idPRO { get; set; }
        public string PRO { get; set; }
        //
        public int idCMN { get; set; }
        public string CMN { get; set; }
        //
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        private List<Branches> ListComboSucursal { get; set; } = new List<Branches>();

        public List<Branches> ComboSucursal()
        {
            ListComboSucursal = new List<Branches>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM SUCURSAL
            ORDER BY nombre Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Branches()
                {
                    IdSUC = (int)registros["id"],
                    Sucursal = registros["nombre"].ToString(),
                };

                ListComboSucursal.Add(registro);
            }
            connection.Close();

            return ListComboSucursal;
        }

        public List<Branches> ListarSucursales()
        {
            ListComboSucursal = new List<Branches>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT S.id, REG.nombre region, PRO.nombre provincia, 
            CMN.nombre comuna, S.nombre, S.direccion 
            FROM SUCURSAL S
            INNER JOIN REGION as REG ON  S.idREG = REG.id
            INNER JOIN PROVINCIA as PRO ON S.idPRO = PRO.id
            INNER JOIN COMUNA as CMN ON S.idCMN = CMN.id
            ORDER BY S.id Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Branches()
                {
                    IdSUC = (int)registros["id"],
                    REG = registros["region"].ToString(),
                    PRO = registros["provincia"].ToString(),
                    CMN = registros["comuna"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    Sucursal = registros["nombre"].ToString(),
                };

                ListComboSucursal.Add(registro);
            }
            connection.Close();

            return ListComboSucursal;
        }

        public void InsertarSucursal(Branches pBra)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO SUCURSAL(idREG, idPRO, idCMN, direccion, nombre)
            VALUES({pBra.idREG}, {pBra.idPRO}, {pBra.idCMN}, '{pBra.Direccion}', 
            '{pBra.Sucursal}')";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        public List<Branches> ObtenerSucursal(string pId)
        {
            int id = Convert.ToInt32(pId);
            ListComboSucursal = new List<Branches>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT * FROM SUCURSAL as P WHERE P.id = {id};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Branches()
                {
                    IdSUC = (int)registros["id"],
                    idREG = Convert.ToInt32(registros["idREG"]),
                    idPRO = Convert.ToInt32(registros["idPRO"]),
                    idCMN = Convert.ToInt32(registros["idCMN"]),
                    Direccion = registros["direccion"].ToString(),
                    Sucursal = registros["nombre"].ToString(),
                };
                ListComboSucursal.Add(registro);
            }
            connection.Close();

            return ListComboSucursal;
        }

        public void ActualizarSucursal(Branches pSuc)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE SUCURSAL SET idREG = {pSuc.idREG}, idPRO = {pSuc.idPRO}, idCMN = {pSuc.idCMN}, 
			nombre = '{pSuc.Sucursal}', direccion = '{pSuc.Direccion}'
			WHERE id = {pSuc.IdSUC};";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }
    }
}