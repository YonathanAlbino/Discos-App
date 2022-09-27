using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dominio;

namespace acomodando
{
    public class refactorizar
    {
        public void ocularColumnas(DataGridView grilla, string columna)
        {
            try
            {   
                grilla.Columns[columna].Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        public void cargarImagen(PictureBox pcb, string imagen)
        {
            try
            {
                pcb.Load(imagen);
            }
            catch (Exception )
            {
                pcb.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThyEKIq_a7eWEwVEoo1aTBQ6gV1KQ4BI8ojEQgnl0ITQ&s");
            }
           
        }
        public void FormatoFechaDgv(DataGridView grilla, string columna, string nuevoFormato)
        {
            try
            {
                grilla.Columns[columna].DefaultCellStyle.Format = nuevoFormato;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool validarColumnaNula(SqlDataReader lector, string columna)
        {
            try
            {
                if (!(lector[columna] is DBNull))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ValidarEliminacion()
        {
            DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static bool ValidarSiNo(string texto, string titulo)
        {
            DialogResult respuesta = MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static bool ExisteSiNoEstilo(string NuevaInclusion, ComboBox comboBox)
        {
            try
            {
                List<Estilo> verSiExiste;
                verSiExiste = (List<Estilo>)comboBox.DataSource;
                Estilo nuevo = verSiExiste.Find(x => x.Descripcion.ToUpper() == NuevaInclusion.ToUpper());
                if (nuevo != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex )
            {

                throw ex ;
            } 
        }

        public static bool existeSiNoTipoEdicion(string nuevaInclusion, ComboBox comboBox)
        {
            try
            {
                List<TipoDeEdicion> verSiExiste;
                verSiExiste = (List<TipoDeEdicion>)comboBox.DataSource;
                TipoDeEdicion nuevo = verSiExiste.Find(x => x.Descripcion.ToUpper() == nuevaInclusion.ToUpper());
                if (nuevo != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool existeSiNoGeneroEdicion (object nuevaInclusion, ComboBox comboBox)
        {
            try
            {
                bool existe;

                if (nuevaInclusion.GetType() == typeof(TipoDeEdicion))
                {
                    List<TipoDeEdicion> lista;
                    lista = (List<TipoDeEdicion>)comboBox.DataSource;
                    TipoDeEdicion nuevaEdicion = lista.Find(x => x.Descripcion.ToUpper() == nuevaInclusion.ToString().ToUpper());
                    if (nuevaEdicion != null)
                        existe = true;
                    else
                        existe = false;
                }
                else
                {
                    List<Estilo> lista;
                    lista = (List<Estilo>)comboBox.DataSource;
                    Estilo nuevoEstilo = lista.Find(x => x.Descripcion.ToUpper() == nuevaInclusion.ToString().ToUpper());
                    if (nuevoEstilo != null)
                        existe = true;
                    else
                        existe = false;
                }
                return existe;
            }
            catch (Exception ex)
            {

                throw ex;
            }










            
            
            
           // List<object> verSiExiste;
           // verSiExiste = (List<object>)comboBox.DataSource;
           //object nuevo = verSiExiste.Find(x => x.ToString().ToUpper() == nuevaInclusion.ToString());
           // if (nuevo != null)
           //     return true;
           // else
           //     return false;
        }


}
}
