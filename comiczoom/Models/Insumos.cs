using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class Insumos
    {
        public int Id { get; set; }
        //
        public string Nombre { get; set; }
        //
        public int IdRUB { get; set; }
        public string RUB { get; set; }
        //
        public string Descripcion { get; set; }
        //
        private List<Insumos> ListInsumos { get; set; } = new List<Insumos>();
        private List<string> ListComboNombre { get; set; } = new List<string>();

        public List<Insumos> ListarInsumos(string pRubroId)
        {
            ListInsumos = new List<Insumos>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string cad = $@"SELECT I.id,RUB.nombre rubro, I.nombre, I.descripcion
                        FROM INSUMO I
                        INNER JOIN RUBRO as RUB ON I.idRUB = RUB.id
                        WHERE I.idRUB like '%{pRubroId}%'
                        COLLATE Latin1_general_CI_AI
                        ORDER BY I.id Asc;";

            SqlCommand querySel = new SqlCommand(cad, connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Insumos()
                {
                    Id = (int)registros["id"],
                    RUB = registros["rubro"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    Descripcion = registros["descripcion"].ToString()
                };

                ListInsumos.Add(registro);
            }
            connection.Close();
            return ListInsumos;
        }
        public void InsertarInsumos(Insumos pIns)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO INSUMO(idRUB, nombre, descripcion) VALUES 
                         ({pIns.IdRUB},'{pIns.Nombre}','{pIns.Descripcion}');";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }

        public List<Insumos> ObtenerInsumo(string pId)
        {
            int id = Convert.ToInt32(pId);

            ListInsumos= new List<Insumos>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT * FROM INSUMO as INS WHERE INS.id = {id}", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                var registro = new Insumos()
                {
                    Id = (int)registros["id"],
                    IdRUB = (int)registros["idRUB"],
                    Nombre = registros["nombre"].ToString(),
                    Descripcion = registros["descripcion"].ToString()
                };
                ListInsumos.Add(registro);
            }
            connection.Close();

            return ListInsumos;
        }
        public void ActualizarInsumo(Insumos pIns)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE INSUMO SET idRUB = {pIns.IdRUB}, nombre = '{pIns.Nombre}', descripcion = '{pIns.Descripcion}' 
                        WHERE id = {pIns.Id};";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }
    }
}