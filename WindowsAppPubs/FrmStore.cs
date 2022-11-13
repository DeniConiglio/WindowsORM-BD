using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.AdminDatos;
using WindowsAppPubs.Models;

namespace WindowsAppPubs
{
    public partial class frmStore : Form
    {

        public frmStore()
        {
            InitializeComponent();
        }

        private void btnMostrarLista_Click(object sender, EventArgs e)
        {
            List<Store> listaStore = DacStore.Listar();
            gridMuestra.DataSource = listaStore;

        }

        private void btnTraerUno_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            Store traerUno = DacStore.TraerUno(id);
            MessageBox.Show(traerUno.stor_name.ToString());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Store agregarStore = new Store()
            {
                stor_id = "1111",
                stor_name = "practica",
                stor_address = "pract 123",
                City = "MDP",
                State = "AR",
                Zip = "4566",

            };
            int filasAfectadas = DacStore.NuevaStore(agregarStore);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Nuevo store agregado con exito");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            Store store = DacStore.TraerUno(id);

            if (store != null)
            {
                store.stor_name = txtName.Text;
                store.stor_address = txtAddress.Text;
                store.City = txtCity.Text;
                store.State = txtState.Text;
                store.Zip = txtZip.Text;

                int filasAfectadas = DacStore.ModificarStore(store);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Modificacion exitosa");
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            Store eliminarId = new Store();

            eliminarId.stor_id = id;

            int filasAfectadas = DacStore.EliminarStore(eliminarId);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Eliminada con exito");
            }
        }

        
    }
}
