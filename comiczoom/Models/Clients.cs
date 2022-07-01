using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Clients
    {
        public int Id { get; set; }
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
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string SegNombre { get; set; }
        public string Apellido { get; set; }
        public string SegApellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Tipo { get; set; }

        private List<Clients> ListClientes { get; set; } = new List<Clients>();
        private List<string> ListComboRut { get; set; } = new List<string>();

        public List<Clients> ListarClientes(string pRut)
        {
            ListClientes = new List<Clients>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT CLI.id, CLI.rut, CLI.nombre, CLI.segNombre, CLI.apellido, CLI.segApellido,
                REG.nombre region, PRO.nombre provincia, CMN.nombre comuna, CLI.telefono, CLI.direccion,
                CLI.tipo
                FROM CLIENTE CLI
                INNER JOIN REGION AS REG ON CLI.idREG=REG.id
                INNER JOIN PROVINCIA AS PRO ON CLI.idPRO=PRO.id
                INNER JOIN COMUNA AS CMN ON CLI.idCMN=CMN.id
                WHERE CLI.rut LIKE '%{pRut}%' 
                COLLATE Latin1_general_CI_AI
                ORDER BY CLI.id Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                string tipoCliente;
                if(registros["tipo"].ToString() == "0")
                {
                    tipoCliente = "Particular";
                }
                else
                {
                    tipoCliente = "Empresa";
                }
                var registro = new Clients()
                {
                    Id = (int)registros["id"],
                    Rut = registros["rut"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    SegNombre = registros["segNombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    SegApellido = registros["segApellido"].ToString(),
                    REG = registros["region"].ToString(),
                    PRO = registros["provincia"].ToString(),
                    CMN = registros["comuna"].ToString(),
                    Telefono = registros["telefono"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    Tipo = tipoCliente
                };
                ListClientes.Add(registro);
            }
            connection.Close();

            return ListClientes;
        }
        public List<string> ComboRut()
        {
            ListComboRut = new List<string>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand(@"SELECT CLI.rut FROM CLIENTE AS CLI
                ORDER BY CLI.rut ASC;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                ListComboRut.Add(registros["rut"].ToString());
            }
            connection.Close();

            return ListComboRut;
        }
        public void InsertarCliente(Clients pCli)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO CLIENTE(idREG, idPRO, idCMN, nombre, segNombre, apellido, segApellido, rut, tipo, direccion, telefono)
                        VALUES ({pCli.idREG},{pCli.idPRO},{pCli.idCMN},'{pCli.Nombre}','{pCli.SegNombre}','{pCli.Apellido}','{pCli.SegApellido}',{pCli.Rut},{pCli.Tipo},'{pCli.Direccion}',{pCli.Telefono})";


            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }
        // Obtener un cliente
        public List<Clients> ObtenerClientes(string pId)
        {
            int id = Convert.ToInt32(pId);

            ListClientes = new List<Clients>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT * FROM CLIENTE as CLI WHERE CLI.id = {id};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Clients()
                {
                    Id = (int)registros["id"],
                    idREG = Convert.ToInt32(registros["idREG"]),
                    idPRO = Convert.ToInt32(registros["idPRO"]),
                    idCMN = Convert.ToInt32(registros["idCMN"]),
                    Nombre = registros["nombre"].ToString(),
                    SegNombre = registros["segNombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    SegApellido = registros["segApellido"].ToString(),
                    Rut = registros["rut"].ToString(),
                    Tipo = registros["tipo"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    Telefono = registros["telefono"].ToString()
                };
                ListClientes.Add(registro);
            }
            connection.Close();

            return ListClientes;
        }
        public void ActualizarCliente(Clients pCli)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE CLIENTE SET idREG={pCli.idREG}, idPRO={pCli.idPRO}, idCMN={pCli.idCMN}, nombre='{pCli.Nombre}',
                            segNombre='{pCli.SegNombre}',apellido='{pCli.Apellido}',segApellido='{pCli.SegApellido}',tipo={pCli.Tipo},
                            direccion='{pCli.Direccion}',telefono='{pCli.Telefono}'
                            WHERE id = {pCli.Id};";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }
    }
}