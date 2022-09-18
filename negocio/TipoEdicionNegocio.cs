using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace negocio
{
    public class TipoEdicionNegocio
    {
        public List<TipoDeEdicion> listar()
        {
            List<TipoDeEdicion> lista = new List<TipoDeEdicion>();
            AccesoDatosCentral datos = new AccesoDatosCentral();
            try
            {
                datos.setearConsulta("select Id, Descripcion from TIPOSEDICION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoDeEdicion aux = new TipoDeEdicion();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"]; 

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }
    }
}
