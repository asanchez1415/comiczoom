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
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string SegNombre { get; set; }
        public string Apellido { get; set; }
        public string SegApellido { get; set; }
        public string TipoEmp { get; set; }
        public string Telefono { get; set; }
        public Rol IdRol { get; set; }

        string connectionString()
        {
            return "Server=localhost\\SQLEXPRESS;Database=comiczoom;Trusted_Connection=True;";
        }

        public Employee ListEmployees()
        {
            Employee emp = new Employee();
            using (SqlConnection connect = new SqlConnection(connectionString()))
            {
                string query = "SELECT EM.id, EM.rut, EM.nombre, EM.segNombre, EM.apellido, EM.segApellido," + 
                "REG.nombre region, PRO.nombre provincia, CMN.nombre comuna, EM.telefono," +
                "TE.nombre tipoEmp, SUC.nombre sucursal" +
                "FROM EMPLEADO as EM" +
                "INNER JOIN REGION as REG ON EM.idREG = REG.id" +
                "INNER JOIN PROVINCIA as PRO ON EM.idPRO = PRO.id" +
                "INNER JOIN COMUNA as CMN ON EM.idCMN = CMN.id" +
                "INNER JOIN TIPO_EMPLEADO as TE ON EM.idTE = TE.id" +
                "INNER JOIN SUCURSAL as SUC ON EM.idSUC = SUC.id";
                SqlCommand cmd = new SqlCommand(query, connect);

                cmd.CommandType = CommandType.Text;
                connect.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        emp = new Employee
                        {
                            Id = (int)dr["id"],
                            SUC = dr["sucursal"].ToString(),
                            Rut = dr["rut"].ToString(),
                            Nombre = dr["nombre"].ToString(),
                            SegNombre = dr["segNombre"].ToString(),
                            Apellido = dr["apellido"].ToString(),
                            SegApellido = dr["segApellido"].ToString(),
                            REG = dr["region"].ToString(),
                            PRO = dr["provincia"].ToString(),
                            CMN = dr["comuna"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            TipoEmp = dr["tipoEmp"].ToString()
                        };
                    }
                }
                connect.Close();

                return emp;
            }

        }


    }
}