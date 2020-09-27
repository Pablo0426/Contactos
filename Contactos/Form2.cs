using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contactos.Directorio;

namespace Contactos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Contacto cont = new Contacto();

        private void Form2_Load(object sender, EventArgs e)
        {
            ListaContactos();
        }

        public void ListaContactos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cont.datosContacs;
        }

        public void Limpiar()
        {
            txtID.Text = ""; 
            txtNombre.Text = " ";
            txtTel.Text = " ";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var NC = new DatosContac()
                {
                    IdContacto = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text,
                    Telefono = txtTel.Text
                };
                cont.datosContacs.Add(NC);
                ListaContactos();
                Limpiar();
                txtID.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Debe de llenar todos los campos o por lo menos ID.");;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var NC in cont.datosContacs)
                {
                    if (NC.IdContacto == int.Parse(txtID.Text))
                    {
                        lbnombre.Visible = true;
                        txnombre.Visible = true;
                        lbtel.Visible = true;
                        txtel.Visible = true;
                        txid.Visible = true;
                        lbid.Visible = true;
                        txid.Text = NC.IdContacto.ToString();
                        txnombre.Text = NC.Nombre;
                        txtel.Text = NC.Telefono;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                var NC = new DatosContac()
                {
                    IdContacto = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text,
                    Telefono = txtTel.Text
                };
                var posicion = dataGridView1.CurrentRow.Index;
                if (NC.IdContacto == int.Parse(txtID.Text))
                {
                    dataGridView1[1, posicion].Value = txtNombre.Text;
                    dataGridView1[2, posicion].Value = txtTel.Text;
                    Limpiar();
                    txtID.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var NC in cont.datosContacs)
                {
                    if (NC.IdContacto == int.Parse(txtID.Text))
                    {
                        cont.datosContacs.Remove(NC);
                        ListaContactos();
                    }
                }
                //int n = int.Parse(txtID.Text) - 1;
                //cont.datosContacs.RemoveAt(n);
                //ListaContactos();
            }
            catch (Exception)
            {
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
