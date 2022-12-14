using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;


namespace negocio
{
    public class EstiloNegocio
    {
        public List<Estilo> listar()
        {
            List<Estilo> lista = new List<Estilo>();
            AccesoDatosCentral datos = new AccesoDatosCentral();

            try
            {
                datos.setearConsulta("select Id, Descripcion from ESTILOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilo aux = new Estilo();
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
        
        }//Select DB
        public void agregar(Estilo nuevo)
        {
            AccesoDatosCentral datos = new AccesoDatosCentral();
            try
            {
                datos.setearConsulta("insert into ESTILOS (Descripcion) values (@Descripcion)");
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.ejecutarAccion();
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

        public void eliminarFisico(Estilo estilo)
        {
            AccesoDatosCentral datos = new AccesoDatosCentral();
            try
            {
                datos.setearConsulta("delete from ESTILOS where Id = @id");
                datos.setearParametro("@id",estilo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public void eliminarLogico(int id)
        //{
        //    AccesoDatosCentral datos = new AccesoDatosCentral();
        //    try
        //    {
        //        datos.setearConsulta("update ESTILOS set Activo = 0 where id = @Id ");
        //        datos.setearParametro("@Id", id);
        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
    }
}
