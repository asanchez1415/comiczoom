using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace prueba.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public int IdSUC { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Contrasenia { get; set; }
        public Rol IdRol { get; set; }

        string connectionString()
        {
            return "Server=localhost\\SQLEXPRESS;Database=comiczoom;Trusted_Connection=True;";
        }

        public UserLogin Verify(string r, string c)
        {
            UserLogin user = new UserLogin();

            using (SqlConnection connect = new SqlConnection(connectionString()))
            {
                string query = "SELECT EMid, EMidSUC, EMidTE, EMrut, EMnombre, EMapellido, EMcontrasenia FROM EMPLEADO WHERE EMrut=@prut AND EMcontrasenia=@pcontrasenia";
                SqlCommand cmd = new SqlCommand(query, connect);

                cmd.Parameters.AddWithValue("@prut", r);
                cmd.Parameters.AddWithValue("@pcontrasenia", c);
                cmd.CommandType = CommandType.Text;

                connect.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        user = new UserLogin()
                        {
                            Id = (int)dr["EMid"],
                            IdSUC = (int)dr["EMidSUC"],
                            Rut = dr["EMrut"].ToString(),
                            Contrasenia = dr["EMcontrasenia"].ToString(),
                            Nombres = $"{dr["EMnombre"].ToString()} {dr["EMapellido"].ToString()}",
                            IdRol = (Rol)dr["EMidTE"]
                        };
                    }
                }

                connect.Close();

                return user;
            }

        }
    }
}