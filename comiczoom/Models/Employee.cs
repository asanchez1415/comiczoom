using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //
        public int IdSUC { get; set; }
        public string SUC { get; set; }
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
        public int IdRol { get; set; }
        public string TipoEmp { get; set; }
        //
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string SegNombre { get; set; }
        public string Apellido { get; set; }
        public string SegApellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        //
        public string Contrasenia { get; set; }

        private List<Employee> ListEmpleados { get; set; } = new List<Employee>();
        private List<string> ListComboRut { get; set; } = new List<string>();

        // Obtener lista de empleados
        public List<Employee> ListarEmpleados(string pRut, string pSucursal, string pCargo)
        {
            ListEmpleados = new List<Employee>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT EM.id, EM.rut, EM.nombre, EM.segNombre, EM.apellido, 
                EM.segApellido, REG.nombre region, PRO.nombre provincia, CMN.nombre comuna, EM.telefono,
                EM.direccion, TE.nombre tipoEmp, SUC.nombre sucursal, SUC.id idsuc
                FROM EMPLEADO as EM
                INNER JOIN REGION as REG ON EM.idREG = REG.id
                INNER JOIN PROVINCIA as PRO ON EM.idPRO = PRO.id
                INNER JOIN COMUNA as CMN ON EM.idCMN = CMN.id
                INNER JOIN TIPO_EMPLEADO as TE ON EM.idTE = TE.id
                INNER JOIN SUCURSAL as SUC ON EM.idSUC = SUC.id
                WHERE EM.rut like '%{pRut}%' AND
                SUC.id like '%{pSucursal}%' AND
                TE.id like '%{pCargo}%' COLLATE Latin1_general_CI_AI
                ORDER BY EM.id Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Employee()
                {
                    Id = (int)registros["id"],
                    SUC = registros["sucursal"].ToString(),
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
                    TipoEmp = registros["tipoEmp"].ToString()
                };
                ListEmpleados.Add(registro);
            }
            connection.Close();

            return ListEmpleados;
        }

        public List<string> ComboRut()
        {
            ListComboRut = new List<string>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand(@"SELECT EM.rut FROM EMPLEADO as EM
                ORDER BY EM.rut Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                ListComboRut.Add(registros["rut"].ToString());
            }
            connection.Close();

            return ListComboRut;
        }

        public void InsertarEmpleado(Employee pEmp)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO EMPLEADO(idREG, idPRO, idCMN, idSUC, idTE,	
            rut, nombre, segNombre, apellido, segApellido, telefono, correo,
            contrasenia, direccion) VALUES
            ({pEmp.idREG}, {pEmp.idPRO}, {pEmp.idCMN}, {pEmp.IdSUC}, {pEmp.IdRol}, 
            '{pEmp.Rut}', '{pEmp.Nombre}', '{pEmp.SegNombre}', '{pEmp.Apellido}', '{pEmp.SegApellido}', 
            '{pEmp.Telefono}', '{pEmp.Correo}', '{pEmp.Contrasenia}', '{pEmp.Direccion}')";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        // Obtener un empleado
        public List<Employee> ObtenerEmpleado(string pId)
        {
            int id = Convert.ToInt32(pId);

            ListEmpleados = new List<Employee>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT * FROM EMPLEADO as EM WHERE EM.id = {id};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Employee()
                {
                    Id = (int)registros["id"],
                    IdSUC = Convert.ToInt32(registros["idsuc"]),
                    Rut = registros["rut"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    SegNombre = registros["segNombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    SegApellido = registros["segApellido"].ToString(),
                    idREG = Convert.ToInt32(registros["idREG"]),
                    idPRO = Convert.ToInt32(registros["idPRO"]),
                    idCMN = Convert.ToInt32(registros["idCMN"]),
                    Telefono = registros["telefono"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    IdRol = Convert.ToInt32(registros["idTE"]),
                    Correo = registros["correo"].ToString()
                };
                ListEmpleados.Add(registro);
            }
            connection.Close();

            return ListEmpleados;
        }

        public void ActualizarEmpleado(Employee pEmp)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE EMPLEADO SET idREG = {pEmp.idREG}, idPRO = {pEmp.idPRO}, idCMN = {pEmp.idCMN}, 
			idSUC = {pEmp.IdSUC}, nombre = '{pEmp.Nombre}', segNombre = '{pEmp.SegNombre}', 
			apellido = '{pEmp.Apellido}', segApellido = '{pEmp.SegApellido}', 
			telefono = '{pEmp.Telefono}', correo = '{pEmp.Correo}', direccion = '{pEmp.Direccion}'
			WHERE id = {pEmp.Id};";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }
    }
}