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

namespace Mina._3_Controlador
{
    public partial class frmLogin : Form
    {
        private ControlUsuarios Usuario = new ControlUsuarios(Frame.config);
        private int intentos = 0;
        public bool entrar = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtCuenta.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCuenta.Text.Trim() == "" || txtContra.Text.Trim() == "")
            {
                MessageBox.Show("Hay campos en blanco");
                Console.Beep();
            }
            else
            {
                intentos++;
                entrar = Usuario.validarUsuario(txtCuenta.Text.Trim(), txtContra.Text.Trim());
                if (entrar)
                {
                    Frame.us_log = this.txtCuenta.Text.Trim();
                    this.Close();
                }
                if (intentos == 3)
                {
                    this.Close();
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
