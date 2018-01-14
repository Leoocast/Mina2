using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Mina
{
    public partial class frmUsuariosDesactivados : Form
    {
        private ControlUsuarios ctl_usuarios = new ControlUsuarios(Frame.config);
        DataSet ds;

        public frmUsuariosDesactivados()
        {
            InitializeComponent();
            prepararForm();
        }

        private void frmUsuariosDesactivados_Load(object sender, EventArgs e)
        {

        }

        private void prepararForm()
        {
            if (txtBuscar.Text.Trim() == "")
            {
                ds = ctl_usuarios.LeerUsuariosAdminDesactivados();
            }
            else
            {
               ds = ctl_usuarios.LeerUsuariosAdminDesactivados(txtBuscar.Text);
            }
            
            dGV.DataSource = ds.Tables[0];
            Font Negrita = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            dGV.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
            dGV.ColumnHeadersDefaultCellStyle.Font = Negrita;
            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn col in dGV.Columns)
            {
                //Poner las iniciales de cada encabezado en la columna.
                col.HeaderText = col.HeaderText.Substring(0, 1).ToUpper() + col.HeaderText.Substring(1);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dGV[3, dGV.CurrentRow.Index].Value.ToString() == "desactivado")
            {
                frmActDesc frm = new frmActDesc(dGV[0, dGV.CurrentRow.Index].Value.ToString());
                frm.ShowDialog();
                if (frm.HuboCambio) prepararForm();
            }
            else
            {
                string id = dGV[0, dGV.CurrentRow.Index].Value.ToString();
                string usuario = dGV[2, dGV.CurrentRow.Index].Value.ToString();
                string nombre = dGV[1, dGV.CurrentRow.Index].Value.ToString();
                DialogResult respuesta;
                respuesta = MessageBox.Show("¿Estás seguro(a) que deseas activar el registro?" +
                    "\n\nUsuario: " + usuario + "\nNombre: " + nombre, "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    ctl_usuarios.ActivarUsuario(id);
                    prepararForm();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            prepararForm();
        }
    }
}
