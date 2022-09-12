using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; //Uso del proyecto (Dominio)
using System.Data.SqlClient; //Librebria para crear la DB


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
                    Disco aux = new Disco();
                    aux.Titulo = lector.GetString(0);
                    aux.FechaLanzamiento = (DateTime)lector["fechaLanzamiento"];
                    aux.CantidadDeCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.genero = new Estilo();
                    aux.genero.Descripcion = (string)lector["Estilo"];
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
    }
}
