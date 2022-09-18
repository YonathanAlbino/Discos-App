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
        }
        private Disco disco = null;


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
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
