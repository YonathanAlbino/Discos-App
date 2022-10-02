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
        private bool actualizarDgv = false;
        List<Estilo> listaEstilos = new List<Estilo>();
        private OpenFileDialog archivo = null;




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
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                    actualizarDgv = true;
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente");
                    actualizarDgv = true;
                }

                if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                {
                    try
                    {
                        string ruta = @"C:\DiscoApp";
                        string file = archivo.SafeFileName;
                        string rutaCompleta = ruta + @"\" + file;

                        if (File.Exists(rutaCompleta))
                        {
                            if (refactorizar.ValidarSiNo("La imagen que intenta guardar ya existe, ¿Desea sobreescribirla?", "Sobreescribir?"))
                                File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName, true);
                        }
                        else
                        {
                            File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                            MessageBox.Show("Imagen guardada");
                        }

                    }
                    //catch (System.IO.IOException)
                    //{
                    //    MessageBox.Show("No se pudo guardar la imagen (en la carpeta de destino) porque ya existe una con el mismo nombre");
                    //    if(refactorizar.ValidarSiNo("¿Desea sobreescribir la imagen", "Sobreescribir..."))
                    //    {
                    //        File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName, true);
                    //    }

                    //}
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                   
                    
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

                    //if(refactorizar.ValidarSiNo("Desea guardar la imagen", "Guardando imagen"))
                    //{
                    //    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                    //}
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }






          

        }
    }
}
