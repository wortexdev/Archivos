using Demo01.Librerias.EntidadesNegocio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Demo01.Librerias.AccesoDatos
{
    public class daEmpleado
    {
        string conn = System.Configuration.ConfigurationManager
              .ConnectionStrings["NorthwindConn"].ConnectionString;

        public List<beEmpleado> Filtrar(string filtro)
        {
            List<beEmpleado> lista = new List<beEmpleado>();

            using (SqlConnection cn = new SqlConnection(conn))
            using (SqlCommand cmd = new SqlCommand("usp_FiltrarEmployees", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Filtro", filtro);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new beEmpleado
                    {
                        EmployeeID = dr.GetInt32(0),
                        FirstName = dr.GetString(1),
                        LastName = dr.GetString(2),
                        Title = dr.IsDBNull(3) ? "" : dr.GetString(3)
                    });
                }
            }

            return lista;
        }
    }
}
