using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; //Uso del proyecto (Dominio)
using System.Data.SqlClient; //Librebria para crear la DB
using AccesoDatos;
using acomodando;



namespace negocio
{
    public class DiscosNegocio
    {
        
        public List<Disco> listar(bool datosEliminados = false) //Select discos DB
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                if (datosEliminados)
                    comando.CommandText = "select D.Id as Id, Titulo, fechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as Estilo, T.Descripcion as Edicion, IdEstilo, IdTipoEdicion, D.Activo as eliminado from DISCOS D, ESTILOS E, TIPOSEDICION T  where D.IdEstilo = E.Id   and T.Id = D.IdTipoEdicion and D.Activo = 0  ";
                else
                {
                    comando.CommandText = "select D.Id as Id, Titulo, fechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as Estilo, T.Descripcion as Edicion, IdEstilo, IdTipoEdicion, D.Activo AS eliminado from DISCOS D, ESTILOS E, TIPOSEDICION T  where D.IdEstilo = E.Id   and T.Id = D.IdTipoEdicion and D.Activo = 1";
                } 
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    //Disco aux = new Disco(lector.GetString(0), (int)lector["CantidadCanciones"]);
                    Disco aux = new Disco();

                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["fechaLanzamiento"];
                    aux.CantidadDeCanciones = (int)lector["CantidadCanciones"];
                    aux.Eliminado = (int)lector["eliminado"];
                    

                    if (refactorizar.validarColumnaNula(lector, "UrlImagenTapa"))
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];

                    aux.Genero = new Estilo();
                    aux.Genero.Descripcion = (string)lector["Estilo"];
                    aux.Genero.Id = (int)lector["IdEstilo"];
                    aux.Edicion = new TipoDeEdicion();
                    aux.Edicion.Descripcion = (string)lector["Edicion"];
                    aux.Edicion.Id = (int)lector["IdTipoEdicion"];
                    
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
                conexion.Close();
             
            }
           

            
            
        }

        public void modificar(Disco disco)
        {
            AccesoDatosCentral datos = new AccesoDatosCentral();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @Titulo, FechaLanzamiento = @FechaLanzamiento, CantidadCanciones = @CantidadCanciones, UrlImagenTapa = @UrlImagenTapa, IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion where id = @Id;");
                datos.setearParametro("@Titulo", disco.Titulo);
                datos.setearParametro("@FechaLanzamiento", disco.FechaLanzamiento);
                datos.setearParametro("@CantidadCanciones", disco.CantidadDeCanciones);
                datos.setearParametro("@UrlImagenTapa", disco.UrlImagenTapa);
                datos.setearParametro("@IdEstilo", disco.Genero.Id);
                datos.setearParametro("@IdTipoEdicion", disco.Edicion.Id);
                datos.setearParametro("@Id", disco.Id);

                datos.ejecutarAccion();
                datos.cerrarConexion();
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

        public void agregar(Disco nuevo)
        {
            AccesoDatosCentral datos = new AccesoDatosCentral();   
            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion, UrlImagenTapa, Activo)values(@titulo, @fechaLanzamiento, @CantidadCanciones, @IdEstilo, @IdTipoEdicion, @UrlImagenTapa, @Activo)");
                datos.setearParametro("@titulo", nuevo.Titulo);
                datos.setearParametro("@fechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@CantidadCanciones", nuevo.CantidadDeCanciones);
                datos.setearParametro("@IdEstilo", nuevo.Genero.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.Edicion.Id);
                datos.setearParametro("UrlImagenTapa", nuevo.UrlImagenTapa);
                datos.setearParametro("@Activo", 1);
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

        public void restaurar(int id)
        {
            AccesoDatosCentral datos = new AccesoDatosCentral();
            try
            {
                datos.setearConsulta("update DISCOS set Activo = 1 where id = @Id");
                datos.setearParametro("@Id", id);
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

        public void eliminarFisico(int id)
        {
            try
            {
                AccesoDatosCentral datos = new AccesoDatosCentral();
                datos.setearConsulta("Delete from DISCOS where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void EliminarLogico(int Id)
        {
            AccesoDatosCentral datos = new AccesoDatosCentral();
            try
            {
                datos.setearConsulta("update DISCOS set Activo = 0 where id = @Id");
                datos.setearParametro("@Id", Id);
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

        public List<Disco> filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatosCentral datos = new AccesoDatosCentral();
            try
            {
                string consulta = "select D.Id as Id, Titulo, fechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as Estilo, T.Descripcion as Edicion, IdEstilo, IdTipoEdicion, D.Activo AS eliminado from DISCOS D, ESTILOS E, TIPOSEDICION T  where D.IdEstilo = E.Id   and T.Id = D.IdTipoEdicion and D.Activo = 1 And ";

               if(campo == "Cantidad de canciones")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "CantidadCanciones >" + filtro;
                            break;
                        case "Menor a":
                            consulta += "CantidadCanciones <" + filtro;
                            break;
                        default:
                            consulta += "CantidadCanciones =" + filtro;
                            break;
                    }
                }
                else if(campo == "Género")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "E.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "E.Descripcion like  '%" + filtro + "%' ";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "T.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "T.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "T.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    //Disco aux = new Disco(lector.GetString(0), (int)lector["CantidadCanciones"]);
                    Disco aux = new Disco();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["fechaLanzamiento"];
                    aux.CantidadDeCanciones = (int)datos.Lector["CantidadCanciones"];
                    aux.Eliminado = (int)datos.Lector["eliminado"];


                    if (refactorizar.validarColumnaNula(datos.Lector, "UrlImagenTapa"))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];

                    aux.Genero = new Estilo();
                    aux.Genero.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Genero.Id = (int)datos.Lector["IdEstilo"];
                    aux.Edicion = new TipoDeEdicion();
                    aux.Edicion.Descripcion = (string)datos.Lector["Edicion"];
                    aux.Edicion.Id = (int)datos.Lector["IdTipoEdicion"];

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
