using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models.EquipoComic
{
    public class EmpleadoEquipoComic
    {
        public int Id { get; set; }
        public int IdEMP { get; set; }
        public int IdEC { get; set; }
        public DateTime fechaCreacion { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string SegApellido { get; set; }
        public string Rol { get; set; }
        public string Rut { get; set; }

        public List<EmpleadoEquipoComic> ListEEC { get; set; } = new List<EmpleadoEquipoComic>();

        public List<EmpleadoEquipoComic> ListarEEC(int idEC)
        {
            ListEEC = new List<EmpleadoEquipoComic>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT  EEC.id, EEC.idEMP, EEC.idEC, E.nombre, E.apellido, E.segApellido,
				EEC.roleq, E.rut
				FROM EMPLEADO_EQUIPO_COMIC as EEC
				INNER JOIN EMPLEADO AS E ON EEC.idEMP = E.id
                WHERE EEC.idEC like '%{idEC}%';", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new EmpleadoEquipoComic()
                {
                    Id = (int)registros["id"],
                    IdEC = (int)registros["idEC"],
                    IdEMP = (int)registros["idEMP"],
                    Nombre = registros["nombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    SegApellido = registros["segApellido"].ToString(),
                    Rut = registros["rut"].ToString(),
                    Rol = registros["roleq"].ToString(),
                };

                ListEEC.Add(registro);
            }

            connection.Close();
            return ListEEC;
        }

        public void DeleteEmpleado(int id)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"DELETE FROM EMPLEADO_EQUIPO_COMIC WHERE id = '{id}'";

            SqlCommand queryDelete = new SqlCommand(cad, connection.connectDb);

            queryDelete.ExecuteNonQuery();

            connection.Close();
        }

        public void InsertEmpleadoPorEC(int pIdEMP, int pIdEC, string pRol)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@" INSERT INTO EMPLEADO_EQUIPO_COMIC (idEMP, idEC, roleq, fechaCreacion)
                         VALUES ({pIdEMP}, {pIdEC}, '{pRol}', '{DateTime.Now.ToString("yyyy-MM-dd")}')";

            SqlCommand queryDelete = new SqlCommand(cad, connection.connectDb);

            queryDelete.ExecuteNonQuery();

            connection.Close();
        }
    }
}