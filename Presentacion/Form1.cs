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
            DiscosNegocio negocio = new DiscosNegocio();

            listaDisco = negocio.listar();
            dgvDiscos.DataSource = listaDisco;
            OcultarColumna();
            cargarImagen(listaDisco[0].UrlImagenTapa);
           
        }

        private void dgvEstilos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pcbDiscos.Load(imagen);
            }
            catch (Exception)
            {

                pcbDiscos.Load("https://vesaliusdental.com/wp-content/uploads/2016/10/orionthemes-placeholder-image.jpg");
            }
        }
        private void OcultarColumna()
        {
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
        }

        
        
    }

    
}
