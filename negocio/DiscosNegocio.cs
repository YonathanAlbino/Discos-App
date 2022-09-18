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
        public List<Disco> listar() //Select discos DB
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select D.Id as Id, Titulo, fechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as Estilo, T.Descripcion as Edicion, IdEstilo, IdTipoEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T  where D.IdEstilo = E.Id   and T.Id = D.IdTipoEdicion";
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
                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion, UrlImagenTapa)values(@titulo, @fechaLanzamiento, @CantidadCanciones, @IdEstilo, @IdTipoEdicion, @UrlImagenTapa)");
                datos.setearParametro("@titulo", nuevo.Titulo);
                datos.setearParametro("@fechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@CantidadCanciones", nuevo.CantidadDeCanciones);
                datos.setearParametro("@IdEstilo", nuevo.Genero.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.Edicion.Id);
                datos.setearParametro("UrlImagenTapa", nuevo.UrlImagenTapa);
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
    }
}
