using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using windowsAppNorthwind.Models;

namespace windowsAppNorthwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

            //creamos instancia de EF DbContext
            NorthwindContext Context = new NorthwindContext();
        private void btnInsertar_Click(object sender, EventArgs e)
        {

            //creamos el objeto con datos
            Shipper shipper=new Shipper() { CompanyName="Express SRL" ,Phone="(503) 555-9001"};

            //DBSet
            Context.Shippers.Add(shipper);

            //guardamos en la tabla
            int filasAfectadas = Context.SaveChanges();

            if(filasAfectadas>0)
            {
                MessageBox.Show("OK!");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //busqueda
            int id = 4;
            Shipper shiperDB = Context.Shippers.Find(id);

            //modificacion
            if(shiperDB != null)
            {
                shiperDB.CompanyName = "Express Latam SRL";
                shiperDB.Phone = "503 555 0001";
            }

            //guardar en DB
            int filasAfectadas = Context.SaveChanges();
            if(filasAfectadas>0)
            {
                MessageBox.Show("OK!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            //busca objeto en DB

            var shipperDB= Context.Shippers.Find(id);

            if(shipperDB!=null)
            {
                //remove
                Context.Shippers.Remove(shipperDB);

                //guarda cambio en DB
                Context.SaveChanges();
            }
        }

        private void btnTraerTodos_Click(object sender, EventArgs e)
        {
            List<Shipper> lista = Context.Shippers.ToList();

            gridShipper.DataSource = lista;
        }
    }
}
