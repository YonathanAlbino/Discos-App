using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio; //Inclusion proyecto Dominio
using negocio; //Inclusion proyecto negocio
using acomodando;





namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Disco> listaDisco;
        private List<Disco> listaDiscosEliminados = new List<Disco>();
        private refactorizar ajuste = new refactorizar();
        private List<ComboBox> listacomboBox = new List<ComboBox>();
        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Cantidad de canciones");
            cboCampo.Items.Add("Género");
            cboCampo.Items.Add("Edición");

        }

        private void cargar()
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                refactorizar ajuste = new refactorizar();

                listaDisco = negocio.listar();
                dgvDiscos.DataSource = listaDisco;

                
               
                if(listaDisco.Count > 0)
                ajuste.cargarImagen(pcbDiscos, listaDisco[0].UrlImagenTapa);
                
                ajuste.ocularColumnas(dgvDiscos, "UrlImagenTapa");
                ajuste.ocularColumnas(dgvDiscos, "Id");
                ajuste.ocularColumnas(dgvDiscos, "Eliminado");
                ajuste.FormatoFechaDgv(dgvDiscos, "fechaLanzamiento", "dd-MM-yyyy");
                dgvDiscos.Columns["fechaLanzamiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnRestaurar.Visible = false;
                lblCerrarDiscosEliminados.Visible = false;
                btnEliminarFisico.Visible = false;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvEstilos_SelectionChanged(object sender, EventArgs e)
        {
            refactorizar ajuste = new refactorizar();
            if(dgvDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                ajuste.cargarImagen(pcbDiscos, seleccionado.UrlImagenTapa);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaDisco alta = new FrmAltaDisco();
            alta.ShowDialog();
            if (alta.actuclizarDgv())
                cargar();


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            try
            {
                seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                FrmAltaDisco modificar = new FrmAltaDisco(seleccionado);
                modificar.ShowDialog();
                if (modificar.actuclizarDgv())
                    cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void eliminar(bool logico = false)
        {
            Disco seleccionado;
            try
            {
                if (refactorizar.ValidarEliminacion())
                {
                    DiscosNegocio negocio = new DiscosNegocio();
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    if (logico)
                        negocio.EliminarLogico(seleccionado.Id);
                    else
                    {
                        negocio.eliminarFisico(seleccionado.Id);
                        
                    }


                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                if(refactorizar.ValidarSiNo("¿Esta seguro que desea borrar el disco de forma permanente?....", "Eliminando...."))
                {
                    Disco seleccionado;
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    negocio.eliminarFisico(seleccionado.Id);
                    dgvDiscos.DataSource = null;
                    dgvDiscos.DataSource = negocio.listar(true);
                    ajuste.ocularColumnas(dgvDiscos, "UrlImagenTapa");
                    ajuste.ocularColumnas(dgvDiscos, "Id");
                    ajuste.ocularColumnas(dgvDiscos, "Eliminado");
                    ajuste.FormatoFechaDgv(dgvDiscos, "fechaLanzamiento", "dd-MM-yyyy");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void btnVerDiscosEliminados_Click(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                dgvDiscos.DataSource = negocio.listar(true);
                
                btnRestaurar.Visible = true;
                lblCerrarDiscosEliminados.Visible = true;
                btnEliminarLogico.Visible = false;
                btnEliminarFisico.Visible = true;
                btnRestaurar.Location = new Point(x: 328, y: 374); 
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {   DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                dgvDiscos.DataSource = negocio.listar();
                lblCerrarDiscosEliminados.Visible = false;
                btnRestaurar.Visible = false;
                btnEliminarLogico.Visible = true;
                btnEliminarFisico.Visible = false;
                btnAgregar.Enabled = true;
                btnModificar.Enabled = true;
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                if (refactorizar.ValidarSiNo("¿Esta seguro que quiere restaurar el disco?", "Restaurar")){
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    negocio.restaurar(seleccionado.Id);
                    dgvDiscos.DataSource = negocio.listar(true);
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if(cboCampo.SelectedItem.ToString() == "Cantidad de canciones")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("El filtro de busqueda se encuentra vacio");
                    return true;
                }
                if (!(refactorizar.soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Ingrese solo numeros para filtrar por un campo númerico");
                    return true;
                }
            }
            return false;
        }
        
        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                listacomboBox.Add(cboCampo);
                listacomboBox.Add(cboCriterio);
                if (refactorizar.verificarCombos(listacomboBox))
                {
                    MessageBox.Show("Almenos uno de los desplegables se encuentra vacio");
                    return;
                }
                
                if(validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvDiscos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
           
        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada;
            string filtro = txtFiltroRapido.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaDisco.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Genero.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaDisco;
            }

            //dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listaFiltrada;

            ajuste.ocularColumnas(dgvDiscos, "UrlImagenTapa");
            ajuste.ocularColumnas(dgvDiscos, "Id");
            ajuste.ocularColumnas(dgvDiscos, "Eliminado");
            ajuste.FormatoFechaDgv(dgvDiscos, "fechaLanzamiento", "dd-MM-yyyy");
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string campo = cboCampo.SelectedItem.ToString();
            
            if(campo == "Cantidad de canciones")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Igual a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Mayor a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    
}
    

    

