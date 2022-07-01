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

        public List<EmpleadoEquipoComic> ListEEC { get; set; } = new List<EmpleadoEquipoComic>();

        public List<EmpleadoEquipoComic> ListarEEC(int idEC)
        {
            ListEEC = new List<EmpleadoEquipoComic>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT EEC.idEMP FROM EMPLEADO_EQUIPO_COMIC as EEC
                WHERE EEC.idEC like '%{idEC}%';", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new EmpleadoEquipoComic()
                {
                    IdEMP = (int)registros["idEMP"],
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
    }


}