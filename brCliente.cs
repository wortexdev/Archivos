using System.Collections.Generic;
using Demo01.Librerias.AccesoDatos;
using Demo01.Librerias.EntidadesNegocio;

namespace Demo01.Librerias.ReglasNegocio
{
    public class brCliente
    {
        daCliente dal = new daCliente();

        public (List<beCliente>, int) ListarPaginado(int page, int pageSize)
            => dal.ListarPaginado(page, pageSize);

        public void Insertar(beCliente c) => dal.Insertar(c);

        public void Actualizar(beCliente c) => dal.Actualizar(c);

        public void Eliminar(string id) => dal.Eliminar(id);
    }
}
