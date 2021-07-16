using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormulariosMDI
{
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }

        private void listaUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //INICIALIZACION DE INSTANCIA
            UsuariosForm FormularioU = new UsuariosForm();

            //METODO
            FormularioU.Show();
        }

        private void FormularioP_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //DECLARACION
        private ClientesForm frmClientes;

        private void listaClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmClientes == null)
            {
                //INSTANCIADO
                frmClientes = new ClientesForm();

                frmClientes.MdiParent = this;

                //ACTIVACION DEL EVENTO CLOSING (POR MEDIO DE CODIGO)
                frmClientes.FormClosed += FrmClientes_FormClosed;

                frmClientes.Show();
            }
            else
            {
                frmClientes.Activate();
            }
        }

        //DETECTA QUE SE CERRO EL FORMULARIO Y PERMITE ABRIRLO NUEVAMENTE
        private void FrmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmClientes = null;
        }

        //ACTIVACION DE EVENTO CLOSING (POR MEDIO DE EVENTO)
        private void FormMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar el sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listaProductosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ProductosForm FormularioP = new ProductosForm();

            //FORMULARIO PADRE
            FormularioP.MdiParent = this;

            FormularioP.Show();
        }  
    }
}
