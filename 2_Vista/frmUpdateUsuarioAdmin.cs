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
using Validaciones;

namespace Mina
{
    public partial class frmUpdateUsuarioAdmin : Form
    {
        //Atributos:
        private ControlUsuarios ctl_usuario = new ControlUsuarios(Frame.config);
        public bool HuboCambio = false;
        private string modo;  //Modo de la ventana(Si agregas o modificas)
        private string usuario = ""; //Usuario que se quiere modificar
        private string clave_cifrada;

        public frmUpdateUsuarioAdmin() //ORIGINAL: Agregar
        {
            InitializeComponent();
            this.modo = "Agregar";
            lblTitulo.Text = modo;
            
            cbxNivel.SelectedIndex = 0;
        }

        public frmUpdateUsuarioAdmin(string id_usuario)  //Constructor: MODIFICAR 
        {
            InitializeComponent();
            this.modo = "Modificar";
            lblTitulo.Text = modo;
            this.usuario = id_usuario;
            DataRow dr = ctl_usuario.localizarUsuario(id_usuario);
            txtName.Text = dr["nombre"].ToString();
            txtAccount.Text = dr["cuenta"].ToString();
            clave_cifrada = dr["clave"].ToString();

            if (dr["id_rolf"].ToString() == "1")
                cbxNivel.Text = "Administrador";

            if (dr["id_rolf"].ToString() == "2")
                cbxNivel.Text = "Gerente";

        }

        private void frmUpdateUsuarioAdmin_Load(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.HuboCambio = false;
            this.Close();
        }

        int nivel = 0;
        string status = "Activo";

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                new frmMensaje("Error: Hay campos en blanco.", 2000, 2).ShowDialog();
                return; //Impide que avance
            }

            if (Validar.soloLetras(txtName.Text) == false)
            {
                new frmMensaje("Error: Solo se permiten letras en el nombre.", 2000, 2).ShowDialog();
                txtName.Focus();
                return;
            }
                       

            switch (modo)
            {
                case "Agregar":

                   int idMax = ctl_usuario.SacarUsMax();

                    if (cbxNivel.Text == "Administrador")
                        nivel = 1;

                    if (cbxNivel.Text == "Gerente")
                        nivel = 2;

                    object[] datosA = {idMax, txtName.Text.Trim(), txtAccount.Text.Trim(),
                                        txtPass.Text.Trim(), status, nivel};
                    if (ctl_usuario.insertarUsuario(datosA))
                    {
                        new frmMensaje("Los datos han sido guardados", 1000).ShowDialog();
                        HuboCambio = true;
                    }
                    break;

                case "Modificar":

                   
                    if (cbxNivel.Text == "Administrador")
                        nivel = 1;

                    if (cbxNivel.Text == "Gerente")
                        nivel = 2;

                    string[] camposM = { "nombre", "cuenta", "clave", "id_rolf" };

                    if (txtPass.Text.Trim() == "") //No cambió la clave
                    {
                        object[] datosM = {txtName.Text.Trim(), txtAccount.Text.Trim(),
                                        txtPass.Text.Trim(), nivel};

                        if (ctl_usuario.modificarUsuario("usuarios", camposM, datosM, "id_us", usuario))
                        {
                            new frmMensaje("Datos actualizados", 1000).ShowDialog();
                            HuboCambio = true;
                        }
                    }
                    else
                    {//Si cambió la clave

                        object[] datosM = {txtName.Text.Trim(), txtAccount.Text.Trim(),
                                        txtPass.Text.Trim(), nivel};

                        if (ctl_usuario.modificarUsuarioNuevaClave("usuarios", camposM, datosM, "nombre", usuario))
                        {
                            new frmMensaje("Datos actualizados", 1000).ShowDialog();
                            HuboCambio = true;
                        }
                    }
                    break;
            }
            this.Close();
        }
    }
}
