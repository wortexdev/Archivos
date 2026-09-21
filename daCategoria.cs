using System.Collections.Generic;
using System.Data.SqlClient;
using Demo01.Librerias.EntidadesNegocio;

namespace Demo01.Librerias.AccesoDatos
{
    public class daCategoria
    {
        string conn = System.Configuration.ConfigurationManager
              .ConnectionStrings["NorthwindConn"].ConnectionString;

        public List<beCategoria> Listar()
        {
            List<beCategoria> lista = new List<beCategoria>();

            using (SqlConnection cn = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand("SELECT CategoryID, CategoryName, Description FROM Categories", cn))
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new beCategoria
                    {
                        CategoryID = dr.GetInt32(0),
                        CategoryName = dr.GetString(1),
                        Description = dr.IsDBNull(2) ? "" : dr.GetString(2)
                    });
                }
            }

            return lista;
        }
    }
}
