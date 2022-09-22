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

            lblEliminarGenero.Visible = false;
            btnEliminarGenero.Visible = false;
            lblAgregarGenero.Visible = false;
            txtNuevoGenero.Visible = false;
            btnNuevoGenero.Visible = false;

            lblNuevaEdicion.Visible = false;
            txtNuevaEdicion.Visible = false;
            btnAgergarEdicion.Visible = false;
            lblEliminarTipoEdicion.Visible = false;
            btnEliminarTipoEdicion.Visible = false;

            lblTipoEdicion.Location = new Point(x: 19, y: 295);
            cboTipoDeEdicion.Location = new Point(x: 151, y: 288);

            btnAceptar.Location = new Point(x: 22, y: 331);
            btnCancelar.Location = new Point(x: 122, y: 331);

            pcbImagenDiscoAlta.Location = new Point(x: 395, y: 60);
            pcbImagenDiscoAlta.Size = new Size(width: 290, height: 300);
            pcbImagenDiscoAlta.SizeMode = PictureBoxSizeMode.StretchImage;

            btnEliminarLogicoGener.Visible = false;
            btnEliminarLogicoGenero.Visible = false;

            Width = 800;
            Height = 480;
        }
        private Disco disco = null;
        private bool actualizarDgv = false;


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
                cboGenero.DataSource = estiloNegocio.listar();
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
           Estilo nuevo = new Estilo();
           EstiloNegocio negocio = new EstiloNegocio();
            try
            {
                nuevo.Descripcion = txtNuevoGenero.Text;
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
            TipoEdicionNegocio negocio = new TipoEdicionNegocio();
            TipoDeEdicion nuevo = new TipoDeEdicion();
            try
            {   
                nuevo.Descripcion = txtNuevaEdicion.Text;
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
            try
            {
                if (refactorizar.ValidarEliminacion())
                {
                    EstiloNegocio negocio = new EstiloNegocio();
                    Estilo seleccionado;
                    seleccionado = (Estilo)cboGenero.SelectedItem;
                    negocio.eliminarLogico(seleccionado.Id);
                    cboGenero.DataSource = negocio.listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
