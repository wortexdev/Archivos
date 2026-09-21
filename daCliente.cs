using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Demo01.Librerias.EntidadesNegocio;

namespace Demo01.Librerias.AccesoDatos
{
    public class daCliente
    {
        string conn = System.Configuration.ConfigurationManager
              .ConnectionStrings["NorthwindConn"].ConnectionString;

        public (List<beCliente> Lista, int Total) ListarPaginado(int page, int pageSize)
        {
            List<beCliente> lista = new List<beCliente>();
            int total = 0;

            using (SqlConnection cn = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand("usp_Customers_ListarPaginado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Page", page);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new beCliente
                    {
                        CustomerID = dr.GetString(0),
                        CompanyName = dr.GetString(1),
                        ContactName = dr.GetString(2),
                        City = dr.IsDBNull(3) ? "" : dr.GetString(3),
                        Country = dr.IsDBNull(4) ? "" : dr.GetString(4)
                    });
                }

                dr.NextResult();
                if (dr.Read())
                    total = dr.GetInt32(0);
            }

            return (lista, total);
        }

        public void Insertar(beCliente c)
        {
            using (SqlConnection cn = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand("usp_Customers_Insertar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", c.CustomerID);
                cmd.Parameters.AddWithValue("@CompanyName", c.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", c.ContactName);
                cmd.Parameters.AddWithValue("@City", c.City);
                cmd.Parameters.AddWithValue("@Country", c.Country);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(beCliente c)
        {
            using (SqlConnection cn = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand("usp_Customers_Actualizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", c.CustomerID);
                cmd.Parameters.AddWithValue("@CompanyName", c.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", c.ContactName);
                cmd.Parameters.AddWithValue("@City", c.City);
                cmd.Parameters.AddWithValue("@Country", c.Country);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(string id)
        {
            using (SqlConnection cn = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand("usp_Customers_Eliminar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
