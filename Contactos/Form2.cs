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

        //Se recarga el DataGrid con los datos actuales
        public void ListaContactos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cont.datosContacs;
        }

        //Se limpian los textbox para que se pueda escribir informacion nueva
        public void Limpiar()
        {
            txtID.Text = ""; 
            txtNombre.Text = " ";
            txtTel.Text = " ";
        }

        //Boton para Agregar el contenido de una fila tomando como referencia el ID
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se intacia la lista y se igualan a los datos que contienen los textbox
                var NC = new DatosContac()
                {
                    IdContacto = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text,
                    Telefono = txtTel.Text
                };
                cont.datosContacs.Add(NC); //Dicha informacion se añade a la lista
                ListaContactos(); 
                Limpiar(); 
                txtID.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Debe de llenar todos los campos o por lo menos ID.");
            }
        }

        //Boton para Buscar el contenido de una fila tomando como referencia el ID
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se hace un recorrido por todas las filas de la lista
                foreach (var NC in cont.datosContacs)
                {
                    if (NC.IdContacto == int.Parse(txtID.Text)) //Se encontra la coincidencia
                    {
                        lbnombre.Visible = true; //Se hacen visibles los elementos
                        txnombre.Visible = true;
                        lbtel.Visible = true;
                        txtel.Visible = true;
                        txid.Visible = true;
                        lbid.Visible = true;
                        txid.Text = NC.IdContacto.ToString(); //Se recarga el textbox con la informacion correspondiente de la fila
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

        //Boton para Editar el contenido de una fila tomando como referencia el ID
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                var NC = new DatosContac()  //Se crea una instancia de la lista para tomar los datos 
                {
                    IdContacto = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text,
                    Telefono = txtTel.Text
                };
                var posicion = dataGridView1.CurrentRow.Index; // Esta variable se usa como referencia para tomar la posicion del la fila en la lista
                if (NC.IdContacto == int.Parse(txtID.Text)) // Se compara el IdContacto con el txtID 
                {
                    dataGridView1[1, posicion].Value = txtNombre.Text; //Segun la pocision del campo se cambia el contenido
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

        //Boton para Elimiar el contenido de una fila tomando como referencia el ID
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se hace un recorrido por todas las filas de la lista
                foreach (var NC in cont.datosContacs)
                {
                    if (NC.IdContacto == int.Parse(txtID.Text)) //Se encontra la coincidencia
                    {
                        cont.datosContacs.Remove(NC); //Se elimina la fila segun el Id digitado en el txtID
                        ListaContactos(); 
                        Limpiar();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        //Boton para salir del programa
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
