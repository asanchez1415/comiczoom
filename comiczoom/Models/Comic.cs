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
        private List<string> ListComboEstado { get; set; } = new List<string>();

        //Obtener Lista de Comics

        public List<Comic> ListarComics(string pEstado, string pCategoria)
        {
            ListComics = new List<Comic>();
            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            string numEstado = pEstado;
            if(!(pEstado == null))
            {
 
                if (pEstado.Equals("En Desarrollo"))
                {
                    numEstado = "0";
                }
                else if (pEstado.Equals("En Venta"))
                {
                    numEstado = "1";
                }
                else
                {
                    numEstado = "2";
                }
            }
            

            SqlCommand querySel = new SqlCommand($@"SELECT COM.id, COM.nombre, COM.volumen, COM.estado, COM.isbn, COM.categoria, COM.fechacreacion
                FROM COMIC as COM
                WHERE COM.estado like '%{numEstado}%' AND
                COM.categoria like '%{pCategoria}%'
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
        public List<string> ComboEstado()
        {
            ListComboEstado = new List<string>();

            ConnectionDB connection = new ConnectionDB();
            SqlDataReader registros = null;
            connection.Open();

            SqlCommand querySel = new SqlCommand($@"SELECT DISTINCT COM.estado FROM COMIC as COM
                ORDER BY COM.estado Asc;", connection.connectDb);

            registros = querySel.ExecuteReader();

            while (registros.Read())
             {
                if ((int)registros["estado"] == 0)
                {
                    ListComboEstado.Add("En Desarrollo");
                }
                else if ((int)registros["estado"] == 1)
                {
                    ListComboEstado.Add("En Venta");
                }
                else
                {
                    ListComboEstado.Add("Descontinuado");
                }
             }
            connection.Close();

            return ListComboEstado;
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
        public void InsertarComic(Comic pCom)
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();

            string cad = $@"INSERT INTO COMIC(nombre, volumen, estado, isbn, categoria, fechaCreacion) VALUES
            ({pCom.Nombre}, {pCom.Volumen}, {pCom.Estado}, {pCom.Isbn}, {pCom.Categoria}, {pCom.fechaCreacion})";

            SqlCommand queryInsert = new SqlCommand(cad, connection.connectDb);
            queryInsert.ExecuteNonQuery();

            connection.Close();
        }
    }
}