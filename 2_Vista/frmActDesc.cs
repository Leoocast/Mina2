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
    
    public partial class frmActDesc : Form
    {
        private ControlUsuarios ctl_usuario = new ControlUsuarios(Frame.config);
        public bool HuboCambio = false;
        string nivel="", usuario="";

        public frmActDesc(string _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void frmActDesc_Load(object sender, EventArgs e)
        {
            rbGerente.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbAdmin.Checked == true)
                nivel = "Administrador";

            if (rbGerente.Checked == true)
                nivel = "Gerente";

            ctl_usuario.modificarNivel(usuario,nivel);
            HuboCambio = true;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HuboCambio = false;
            this.Close();
        }
    }
}
