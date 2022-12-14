using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using negocio;
using acomodando;
using System.IO;
using System.Configuration;

namespace Presentacion
{
    public partial class FrmAltaDisco : Form
    {
        public FrmAltaDisco()
        {
            InitializeComponent();
        }
        public FrmAltaDisco(Disco disco)
        {
            InitializeComponent();
            Text = "Modificar Disco";
            this.disco = disco;
            lblTituloAltaDisco.Text = "Modificar Disco";
            imagenAborrar.FileName = disco.UrlImagenTapa; //Se carga con la imagen del disco antes de modificar
            //imagenAEliminar = imagenAborrar.SafeFileName;
            

           
            btnEliminarGenero.Visible = false;
            lblAgregarGenero.Visible = false;
            txtNuevoGenero.Visible = false;
            btnNuevoGenero.Visible = false;

            lblNuevaEdicion.Visible = false;
            txtNuevaEdicion.Visible = false;
            btnAgergarEdicion.Visible = false;
            
            btnEliminarTipoEdicion.Visible = false;

            lblTipoEdicion.Location = new Point(x: 19, y: 295);
            cboTipoDeEdicion.Location = new Point(x: 151, y: 288);

            btnAceptar.Location = new Point(x: 22, y: 331);
            btnCancelar.Location = new Point(x: 122, y: 331);

            pcbImagenDiscoAlta.Location = new Point(x: 395, y: 60);
            pcbImagenDiscoAlta.Size = new Size(width: 290, height: 300);
            pcbImagenDiscoAlta.SizeMode = PictureBoxSizeMode.StretchImage;

          

            Width = 800;
            Height = 480;
        }

        private Disco disco = null;
        OpenFileDialog imagenAborrar = new OpenFileDialog();
        private bool actualizarDgv = false;
        List<Estilo> listaEstilos = new List<Estilo>();
        private OpenFileDialog archivo = null;
        //string imagenAEliminar;
        string ruta = @"C:\DiscoApp";




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                //Disco disco = new Disco(txtTitulo.Text, int.Parse(txtCantidadCanciones.Text));
                if (disco == null)
                    disco = new Disco();
                disco.Titulo = txtTitulo.Text;
                disco.CantidadDeCanciones = int.Parse(txtCantidadCanciones.Text);
                disco.FechaLanzamiento = dtpFechaLanzamiento.Value;
                disco.Genero = (Estilo)cboGenero.SelectedItem;
                disco.Edicion = (TipoDeEdicion)cboTipoDeEdicion.SelectedItem;
                disco.UrlImagenTapa = txtUrlImagen.Text;


                if (disco.Id != 0) {
                    try
                    {
                        if (imagenAborrar.FileName != disco.UrlImagenTapa) //Si la imagen que se guardo en el constructor es distinta a la que se termino guardando en el disco, significa que se quiere modificar
                        {
                            if (File.Exists(refactorizar.obtenerRuta(ruta, imagenAborrar.SafeFileName))) //Verifica si la imagen anterior continua en la carpeta
                            {
                                if (refactorizar.ValidarSiNo("¿Desea borrar la imagen anterior?", "Borrar imagen?"))
                                {
                                    File.Delete(refactorizar.obtenerRuta(ruta, imagenAborrar.SafeFileName));
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontro la anterior imagen guardada");
                            }

                            if (File.Exists(refactorizar.obtenerRuta(ruta, archivo.SafeFileName))) //Verifica si el nuevo archivo ya existe en la carpeta
                            {
                                if (refactorizar.ValidarSiNo("Ya existe un archivo con el mismo nombre, desea sobreescribirlo?", "Sobreescribir"))
                                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName, true);
                            }
                            else
                            {
                                File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName); // Si la imagen nueva no existe, la copia directamente
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                    actualizarDgv = true;
                }
                else
                {

                    if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                    {
                        try
                        {
                            if (File.Exists(refactorizar.obtenerRuta(ruta, archivo.SafeFileName))) //Verifica si la imagen que se va a cargar ya existe en la carpeta
                            {
                                if (refactorizar.ValidarSiNo("La imagen que intenta guardar ya existe, ¿Desea sobreescribirla?", "Sobreescribir?"))
                                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName, true);
                            }
                            else
                            {
                                File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName); // Si la imagen nueva no existe, la copia directamente
                                MessageBox.Show("Imagen guardada");
                            }

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente");
                    actualizarDgv = true;
                }

              
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }

        public bool actuclizarDgv()
        {
            return actualizarDgv;
        }

        private void FrmAltaDisco_Load(object sender, EventArgs e)
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();
            refactorizar ajustes = new refactorizar();
            try
            {
                listaEstilos = estiloNegocio.listar();
                cboGenero.DataSource = listaEstilos; //estiloNegocio.listar();
                cboGenero.ValueMember = "Id";
                cboGenero.DisplayMember = "Descripcion";
                cboTipoDeEdicion.DataSource = tipoEdicionNegocio.listar();
                cboTipoDeEdicion.ValueMember = "Id";
                cboTipoDeEdicion.DisplayMember = "Descripcion";

                if(disco != null)
                {
                    
                    txtTitulo.Text = disco.Titulo;
                    dtpFechaLanzamiento.Value = disco.FechaLanzamiento;
                    txtCantidadCanciones.Text = disco.CantidadDeCanciones.ToString();
                    txtUrlImagen.Text = disco.UrlImagenTapa;
                    ajustes.cargarImagen(pcbImagenDiscoAlta, disco.UrlImagenTapa);
                    cboGenero.SelectedValue = disco.Genero.Id;
                    cboTipoDeEdicion.SelectedValue = disco.Edicion.Id;
                  
                    
                }
                  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            try
            {
                refactorizar ajustes = new refactorizar();
                ajustes.cargarImagen(pcbImagenDiscoAlta, txtUrlImagen.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        
        private void txtCantidadCanciones_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void btnNuevoGenero_Click(object sender, EventArgs e)
        {
            try
            {
                Estilo nuevo = new Estilo();
                nuevo.Descripcion = txtNuevoGenero.Text;

                if(refactorizar.existeSiNoGeneroEdicion(nuevo, cboGenero))
                {
                    MessageBox.Show("Ya existe un genero con ese nombre");
                    return;
                }

                EstiloNegocio negocio = new EstiloNegocio();
                negocio.agregar(nuevo);
                MessageBox.Show("Nuevo genero agregado");
                cboGenero.DataSource = negocio.listar();
                txtNuevoGenero.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarGenero_Click(object sender, EventArgs e)
        {
            Estilo seleccionado;
            EstiloNegocio negocio = new EstiloNegocio();
            try
            {
                if (refactorizar.ValidarEliminacion())
                {
                    seleccionado = (Estilo)cboGenero.SelectedItem;
                    negocio.eliminarFisico(seleccionado);
                    cboGenero.DataSource = negocio.listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgergarEdicion_Click(object sender, EventArgs e)
        {
            try
            {
                TipoDeEdicion nuevo = new TipoDeEdicion();
                nuevo.Descripcion = txtNuevaEdicion.Text;

                if(refactorizar.existeSiNoGeneroEdicion(nuevo, cboTipoDeEdicion))
                {
                    MessageBox.Show("Ya existe un tipo de edición con ese nombre");
                    return;
                }

                TipoEdicionNegocio negocio = new TipoEdicionNegocio();
                negocio.agregarTipoEdicion(nuevo);
                MessageBox.Show("Nuevo tipo de edición agregado");
                cboTipoDeEdicion.DataSource = negocio.listar();
                txtNuevaEdicion.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarTipoEdicion_Click(object sender, EventArgs e)
        {
            TipoDeEdicion seleccionado;
            TipoEdicionNegocio negocio = new TipoEdicionNegocio();
            try
            {
                if (refactorizar.ValidarEliminacion())
                {
                    seleccionado = (TipoDeEdicion)cboTipoDeEdicion.SelectedItem;
                    negocio.eliminarTipoEdicion(seleccionado);
                    cboTipoDeEdicion.DataSource = negocio.listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarLogicoGenero_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            refactorizar ajustes = new refactorizar();

            try
            {
                archivo.Filter = "jpg|*.jpg| png perrito|*.png";

                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    txtUrlImagen.Text = archivo.FileName;
                    ajustes.cargarImagen(pcbImagenDiscoAlta, archivo.FileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }






          

        }
    }
}
