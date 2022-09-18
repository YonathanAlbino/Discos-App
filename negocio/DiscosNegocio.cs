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
                comando.CommandText = "select Titulo, fechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as Estilo, T.Descripcion as Edicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id  and T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco(lector.GetString(0), (int)lector["CantidadCanciones"]);
                    //aux.Titulo = lector.GetString(0);
                    aux.FechaLanzamiento = (DateTime)lector["fechaLanzamiento"];
                    //aux.CantidadDeCanciones = (int)lector["CantidadCanciones"];

                    if (refactorizar.validarColumnaNula(lector, "UrlImagenTapa"))
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];

                    aux.Genero = new Estilo();
                    aux.Genero.Descripcion = (string)lector["Estilo"];
                    aux.Edicion = new TipoDeEdicion();
                    aux.Edicion.Descripcion = (string)lector["Edicion"];
                    
                   
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
