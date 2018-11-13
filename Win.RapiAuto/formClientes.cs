using BL.RapiAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.RapiAuto
{
    public partial class formClientes : Form
    {
        ClientesBL _cliente;
        public formClientes()
        {
            InitializeComponent();
            _cliente = new ClientesBL();
            listaClientesBindingSource.DataSource = _cliente.ObtenerClientes();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea eliminar este cliente?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _cliente.AgregarCliente();
            listaClientesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            Cancelar.Visible = !valor;
        }

        private void Eliminar(int id)
        {
            var resultado = _cliente.EliminarCliente(id);
            if (resultado)
                listaClientesBindingSource.ResetBindings(false);
            else
                MessageBox.Show("Ocurrió un error al eliminar el cliente");
        }

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var cliente = (Clientes)listaClientesBindingSource.Current;

            var resultado = _cliente.GuardarCliente(cliente);
            if (resultado.Exitoso)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void listaClientesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
