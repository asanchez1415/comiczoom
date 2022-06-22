using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        //
        public int idRUB { get; set; }
        public string RUB { get; set; }
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
        public DateTime fechaCreacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        private List<Proveedor> ListProveedores { get; set; } = new List<Proveedor>();
        private List<string> ListComboNombre { get; set; } = new List<string>();

        public List<Proveedor> ListarProveedores(string pRubro, string pNombre)
        {
            ListProveedores = new List<Proveedor>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT P.id, RUB.nombre rubro, REG.nombre region, 
            PRO.nombre provincia, CMN.nombre comuna, P.nombre, P.fechaCreacion, 
            P.direccion
            FROM PROVEEDOR P
            INNER JOIN REGION as REG ON P.idREG = REG.id
            INNER JOIN PROVINCIA as PRO ON P.idPRO = PRO.id
            INNER JOIN COMUNA as CMN ON P.idCMN = CMN.id
            INNER JOIN RUBRO as RUB ON P.idRUB = RUB.id
            WHERE P.idRUB like '%{pRubro}%' AND
            P.nombre like '%{pNombre}%' 
            COLLATE Latin1_general_CI_AI
            ORDER BY P.id Asc;";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Proveedor()
                {
                    Id = (int)registros["id"],
                    RUB = registros["rubro"].ToString(),
                    REG = registros["region"].ToString(),
                    PRO = registros["provincia"].ToString(),
                    CMN = registros["comuna"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    fechaCreacion = Convert.ToDateTime(registros["fechaCreacion"]),
                    Direccion = registros["direccion"].ToString(),
                };

                ListProveedores.Add(registro);
            }

            connection.Close();
            return ListProveedores;
        }

        public List<string> ComboNombre()
        {
            ListComboNombre = new List<string>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand(@"SELECT P.nombre FROM PROVEEDOR as P
                ORDER BY P.nombre Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                ListComboNombre.Add(registros["nombre"].ToString());
            }
            connection.Close();

            return ListComboNombre;
        }

        public void InsertarProveedor(Proveedor pPro)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO PROVEEDOR(rut, idRUB, idREG, idPRO, idCMN,
            nombre, fechaCreacion, direccion, telefono, correo) VALUES
            ('{pPro.Rut}', {pPro.idRUB}, {pPro.idREG}, {pPro.idPRO}, {pPro.idCMN}, 
            '{pPro.Nombre}', '{DateTime.Now.ToString("yyyy-MM-dd")}', '{pPro.Direccion}', 
            '{pPro.Telefono}', '{pPro.Correo}')";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        // Obtener un empleado
        public List<Proveedor> ObtenerProveedor(string pId)
        {
            int id = Convert.ToInt32(pId);

            ListProveedores = new List<Proveedor>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT * FROM PROVEEDOR as P WHERE P.id = {id};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Proveedor()
                {
                    Id = (int)registros["id"],
                    Rut = registros["rut"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    idRUB = Convert.ToInt32(registros["idRUB"]),
                    idREG = Convert.ToInt32(registros["idREG"]),
                    idPRO = Convert.ToInt32(registros["idPRO"]),
                    idCMN = Convert.ToInt32(registros["idCMN"]),
                    Telefono = registros["telefono"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    Correo = registros["correo"].ToString()
                };
                ListProveedores.Add(registro);
            }
            connection.Close();

            return ListProveedores;
        }

        public void ActualizarEmpleado(Proveedor pPro)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE PROVEEDOR SET idREG = {pPro.idREG}, idPRO = {pPro.idPRO}, idCMN = {pPro.idCMN}, 
			idRUB = {pPro.idRUB}, nombre = '{pPro.Nombre}', telefono = '{pPro.Telefono}', correo = '{pPro.Correo}',
            direccion = '{pPro.Direccion}'
			WHERE id = {pPro.Id};";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }

        private List<Proveedor> ListComboPro { get; set; } = new List<Proveedor>();
        public List<Proveedor> ComboPro()
        {
            ListComboPro = new List<Proveedor>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT id, nombre FROM PROVEEDOR;",
                connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Proveedor()
                {
                    Id = (int)registros["id"],
                    Nombre = registros["nombre"].ToString(),
                };

                ListComboPro.Add(registro);
            }
            connection.Close();

            return ListComboPro;
        }
    }
}