using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prueba.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Volumen { get; set; }
        public int intEstado { get; set; }
        public string Estado { get; set; }
        public string Isbn { get; set; }
        public string Categoria { get; set; }
        public DateTime fechaCreacion { get; set; }


        private List<Comic> ListComics { get; set; } = new List<Comic>();
        private List<string> ListComboCategoria { get; set; } = new List<string>();

        //Obtener Lista de Comics
        public List<Comic> ListarComics(string pEstado, string pCategoria)
        {
            ListComics = new List<Comic>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string numEstado;
            if (pEstado == "En Desarrollo")
            {
                numEstado = "0";
            }
            else if (pEstado == "En Venta")
            {
                numEstado = "1";
            }
            else if (pEstado == "Descontinuado")
            {
                numEstado = "2";
            }
            else
            {
                numEstado = null;
            }
            
            SqlCommand querySel = new SqlCommand($@"SELECT COM.id, COM.nombre, COM.volumen, COM.estado, COM.isbn, COM.categoria, COM.fechacreacion
                FROM COMIC as COM
                WHERE COM.estado like '%{numEstado}%' AND
                COM.categoria like '%{pCategoria}%'
                COLLATE Latin1_general_CI_AI
                ORDER BY COM.id Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
             {
                string tipoEstado;
                if((int)registros["estado"] == 0)
                {
                    tipoEstado = "En Desarrollo";
                }
                else if((int)registros["estado"] == 1)
                {
                    tipoEstado = "En Venta";
                }
                else
                {
                    tipoEstado = "Descontinuado";
                }
                var registro = new Comic()
                {
                    Id = (int)registros["id"],
                    Nombre = registros["nombre"].ToString(),
                    Volumen = (int)registros["volumen"],
                    intEstado = (int)registros["estado"],
                    Estado = tipoEstado,
                    Isbn = registros["isbn"].ToString(),
                    Categoria = registros["categoria"].ToString(),
                    fechaCreacion = (DateTime)registros["fechaCreacion"]
                };

                ListComics.Add(registro);
            }
            connection.Close();

            return ListComics;
        }

        public List<string> ComboCategoria()
        {
            ListComboCategoria = new List<string>();

            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT DISTINCT COM.categoria FROM COMIC as COM
                ORDER BY COM.categoria Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                ListComboCategoria.Add(registros["categoria"].ToString());
            }
            connection.Close();

            return ListComboCategoria;
        }
        public int InsertarComic(Comic pCom)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO COMIC(nombre, volumen, estado, isbn, categoria, fechaCreacion) VALUES
            ('{pCom.Nombre}', {pCom.Volumen}, {pCom.intEstado}, '{pCom.Isbn}', '{pCom.Categoria}', '{pCom.fechaCreacion.ToString("yyyy-MM-dd")}')
             SELECT @@IDENTITY AS id;";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);

            int idIngresado = Convert.ToInt32(queryInsert.ExecuteScalar());
            
            connection.Close();

            return idIngresado;
        }

        public List<Comic> ObtenerComic(string pId)
        {
            int id = Convert.ToInt32(pId);

            ListComics = new List<Comic>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT * FROM COMIC as COM WHERE COM.id = {id};", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
            {
                string tipoEstado;
                if ((int)registros["estado"] == 0)
                {
                    tipoEstado = "En Desarrollo";
                }
                else if ((int)registros["estado"] == 1)
                {
                    tipoEstado = "En Venta";
                }
                else
                {
                    tipoEstado = "Descontinuado";
                }

                var registro = new Comic()
                {
                    Id = (int)registros["id"],
                    Nombre = registros["nombre"].ToString(),
                    Volumen = (int)registros["volumen"],
                    intEstado = (int)registros["estado"],
                    Estado = tipoEstado,
                    Isbn = registros["isbn"].ToString(),
                    Categoria = registros["categoria"].ToString(),
                    fechaCreacion = (DateTime)registros["fechaCreacion"]

                };
                ListComics.Add(registro);
            }
            connection.Close();

            return ListComics;
        }

        public void ActualizarComic(Comic pCom)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"UPDATE COMIC SET nombre = '{pCom.Nombre}', volumen = {pCom.Volumen}, estado = {pCom.intEstado}, isbn = '{pCom.Isbn}',
            categoria = '{pCom.Categoria}' WHERE id = {pCom.Id};";

            SqlCommand queryUpdate = new SqlCommand(cad, connection.connectDb);
            queryUpdate.ExecuteNonQuery();

            connection.Close();
        }
    }
}