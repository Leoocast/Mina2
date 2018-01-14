using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BD_Comm_MySQL;
using Controlador;
using Mina._3_Controlador;

namespace Mina
{
   
    public partial class Frame : Form
    {
        public static ControlConfig config =
        new ControlConfig("MySQL", "Server=localhost; database=mina_pitaya; Uid=root; pwd=cisco;");
        public static string us_log = "", nivel = "";

        public Frame()
        {
            InitializeComponent();
            pbx.BackColor = Color.Transparent;
            pbx.Parent = this;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Frame_Load(object sender, EventArgs e)
        {
            administraciónToolStripMenuItem.Visible = false;
            proveedoresToolStripMenuItem.Visible = false;
            consultasToolStripMenuItem.Visible = false;

            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            if (frm.entrar == false)
                Application.Exit();

            if (nivel == "1")
            {
                administraciónToolStripMenuItem.Visible = true;
                proveedoresToolStripMenuItem.Visible = true;
                consultasToolStripMenuItem.Visible = true;
            }

            if (nivel=="2")
            {
                proveedoresToolStripMenuItem.Visible = true;
                consultasToolStripMenuItem.Visible = true;
            }

            if (nivel == "3")
            {
               consultasToolStripMenuItem.Visible = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tiposDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposProveedor frm = new frmTiposProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados frm = new frmEmpleados();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProveedores frm = new frmProveedores();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductosBuscar frm = new frmProductosBuscar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmProveedoresBuscar frm = new frmProveedoresBuscar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void solicitudDeAltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitudAltaProv frm = new frmSolicitudAltaProv();
            frm.MdiParent = this;
            frm.Show();
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void desactivadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosDesactivados frm = new frmUsuariosDesactivados();
            frm.MdiParent = this;
            frm.Show();

        }

        private void solicitudDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitudBajaProv frm = new frmSolicitudBajaProv();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
