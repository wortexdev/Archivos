using System.Collections.Generic;
using Demo01.Librerias.AccesoDatos;
using Demo01.Librerias.EntidadesNegocio;

namespace Demo01.Librerias.ReglasNegocio
{
    public class brCategoria
    {
        daCategoria dal = new daCategoria();

        public List<beCategoria> Listar()
        {
            return dal.Listar();
        }
    }
}
