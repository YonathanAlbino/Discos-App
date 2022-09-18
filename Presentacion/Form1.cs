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

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();

        }

        private void cargar()
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                refactorizar ajuste = new refactorizar();

                listaDisco = negocio.listar();
                dgvDiscos.DataSource = listaDisco;
                ajuste.cargarImagen(pcbDiscos, listaDisco[0].UrlImagenTapa);
                ajuste.ocularColumnas(dgvDiscos, "UrlImagenTapa");
                ajuste.ocularColumnas(dgvDiscos, "Id");
                ajuste.FormatoFechaDgv(dgvDiscos, "fechaLanzamiento", "dd-MM-yyyy");
                dgvDiscos.Columns["fechaLanzamiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        
        private void dgvEstilos_SelectionChanged(object sender, EventArgs e)
        {
            refactorizar ajuste = new refactorizar();
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            ajuste.cargarImagen(pcbDiscos, seleccionado.UrlImagenTapa);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaDisco alta = new FrmAltaDisco();
            alta.ShowDialog();
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
                cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }

    
}
