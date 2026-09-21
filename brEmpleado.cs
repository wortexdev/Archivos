using System.Collections.Generic;
using Demo01.Librerias.AccesoDatos;
using Demo01.Librerias.EntidadesNegocio;

namespace Demo01.Librerias.ReglasNegocio
{
    public class brEmpleado
    {
        daEmpleado dal = new daEmpleado();

        public List<beEmpleado> Filtrar(string filtro)
        {
            return dal.Filtrar(filtro);
        }
    }
}
