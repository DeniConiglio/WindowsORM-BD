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
    public partial class FrmAuthor : Form
    {
        public FrmAuthor()
        {
            InitializeComponent();
        }

        private void btnMostrarLista_Click(object sender, EventArgs e)
        {
            List<Author> listaAutores = DacAuthor.Listar();
            gridMostrar.DataSource = listaAutores;
        }

        private void btnTraerUno_Click(object sender, EventArgs e)
        {
            Author traeAuthor = DacAuthor.TraerUno("5555");
            MessageBox.Show($"{traeAuthor.au_lname}");

        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {


            Author nuevoAutor = new Author()
            {
                au_id = "5555",
                au_lname = "Nitro",
                au_fname = "geno",
                Phone = "22366555444",
                address = "alsina 1233",
                City = "MDP",
                State = "AR",
                Zip = "7895",
                Contract = true,

            };

            int filasAfectadas = DacAuthor.AgregarAutor(nuevoAutor);
            if (filasAfectadas > 0)
            {
                MessageBox.Show($"Autor agregado con exito");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            Author author = new Author();

            author.au_id = id;

            int filasAfectadas = DacAuthor.EliminarAutor(author);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Fila eliminada");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            Author authorModificar = DacAuthor.TraerUno(id);




            if (authorModificar.au_id == id)
            {
                authorModificar.au_lname = txtName.Text;
                authorModificar.address = txtAddress.Text;
            }

            int filasAfectadas = DacAuthor.ModificarAutor(authorModificar);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Fila modificada con exito");
            }
        }

        
    }
}