/* 
 * namespace Controlador
 * 
 * Autor: Prof. José Padilla Duarte
 * email: jopadu@gmail.com
 * Última modificación: 03-Octubre-2017
 * 
 * Clase ControlBD y demás controladores
 * =====================================
 * 
 * ControlBD define los atributos mínimos obligatorios para cada clase tipo Control que se encuentra
 * en este archivo de código.
 * 
 * Propósito: Clases intermediarias entre la Vista (formas/ventanas) y el Modelo (manejo de archivos y 
 *            comunicación con el DBMS).
 */

using System;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using BD_Comm_MySQL;    //Para acceder a las clases que hay en el Modelo
using Mina;


namespace Controlador
{
    #region public class ControlConfig
    /// <summary>
    /// Define el DBMS y la cadena_de_conexión que tendrá la aplicación.
    /// </summary>
    public class ControlConfig 
    {   //Atributos:
        private string _DBMS;       // El motor de base de datos 
        private string _cadconn;    // La cadena de conexión a la base de datos

        public string DBMS { get { return _DBMS; } }        //Propiedad de solo lectura
        public string cadconn { get { return _cadconn; } }  //Propiedad de solo lectura


        //Métodos:
        public ControlConfig(string DBMS, string cadconn)
        {
            this._DBMS = DBMS;
            this._cadconn = cadconn;
        }
    }
    #endregion

    public abstract class ControlBD
    {   //Atributos:
        protected BDMySQL bd;   // Objeto base de datos
        protected string iSql;

        //Métodos:
        public ControlBD()  // Constructor vacío (requisito de la herencia).
        { }

        
    }
    
    /* ControlUsuarios está listo, es lo que me tocó, no lo muevan prros.
     * ControlProductos y ControlProveedores tienen cosas de padilla, lo dejé ahí por si van a reusar el código.    
     * Les dejé abajo las clases que faltan según yo, si falta otra pues la ponen.
    */

    #region public class ControlUsuarios : ControlBD
    public class ControlUsuarios : ControlBD
    {
        public string nombre;

        public ControlUsuarios(ControlConfig _cfg)  // Constructor que asocia un archivo de configuración que ya
        {                                            // fue leído. (Para no releer el config.ini innecesariamente)
            bd = new BDMySQL(_cfg.cadconn);
        }


        /// <summary>
        /// Retorna true si el usuario y la contraseña son correctos, false si algún dato no es correcto.
        /// </summary>
        /// <param name="_usu">El usuario</param>
        /// <param name="_cve">La clave, contraseña, password, etc.</param>
        /// <returns>true/false</returns>
        public bool validarUsuario(string _usu, string _cve)
        {
           
            string error = "";

            DataRow dr = bd.Leer1Registro("SELECT * FROM usuarios WHERE cuenta = '" + _usu + "';", ref error);
            if (error.Contains("Unable to connect"))
            {
                new frmMensaje("No se detecta servidor de MySQL.", 2000, 2).ShowDialog();
                //s.Speak("No se detecta el servidor de maiesecuele");
                Application.Exit();
                return false;
            }
            if (dr == null)
            {
                if (error.Contains("Authentication"))
                {
                    new frmMensaje("Error de Autenticación. Revise la cadena de conexión.", 2500, 2).ShowDialog();
                    //s.Speak("Error de autenticación. Revise la cadena de conexción.");
                    return false;
                }
                else
                {
                    new frmMensaje("El usuario no está registrado.", 2000, 2).ShowDialog();
                  //  s.Speak("El usuario no está registrado");
                    return false;
                }
            }
            else if (error.Contains("No hay ninguna fila"))
            {
                new frmMensaje("El usuario no está registrado.", 2000, 2).ShowDialog();
                //s.Speak("El usuario no está registrado");
                return false;
            }
            else
            {
                if (obtieneMD5(_cve) == dr["clave"].ToString())
                {
                    Frame.nivel = dr["id_rolf"].ToString();
                    new frmMensaje("Bienvenido(a) " + dr["nombre"].ToString(), 100).ShowDialog();
                    //s.Speak("Bienvenido " + dr["nombre_completo"].ToString());
                    return true;
                }
                else
                {
                    new frmMensaje("Contraseña no válida.", 2000, 2).ShowDialog();
                   // s.Speak("Contraseña no válida");
                    return false;
                }
                //return true;
            }
        }

        public DataSet LeerUsuariosAdmin()
        {
            iSql = "select t1.id_us ID, t1.nombre, t1.cuenta, t2.nombre rol from (select id_us, nombre, ";
            iSql += "cuenta, id_rolf from usuarios where status = 'Activo' and id_rolf = 1 or id_rolf = 2 order by id_us) as t1 ";
            iSql += "inner join (select id_rol, nombre from roles) as t2 on t1.id_rolf = t2.id_rol";
            return (bd.LeerRegistros(iSql));
        }

        public DataSet LeerUsuariosAdminDesactivados()
        {
            iSql = "select t1.id_us ID, t1.nombre, t1.cuenta, t2.nombre rol from (select id_us, nombre, ";
            iSql += "cuenta, id_rolf from usuarios where status = 'Desactivado' and id_rolf = 1 or id_rolf = 2 order by id_us) as t1 ";
            iSql += "inner join (select id_rol, nombre from roles) as t2 on t1.id_rolf = t2.id_rol";
            return (bd.LeerRegistros(iSql));
        }

        public DataSet LeerUsuariosAdminDesactivados(string _dato_a_buscar)
        {
            iSql = "select t1.id_us, t1.nombre, t1.cuenta, t2.nombre from (select id_us, nombre, cuenta, ";
            iSql += "id_rolf from usuarios where status = 'Desactivado' and id_rolf <= 2 and nombre like('%" + _dato_a_buscar + "%') ";
            iSql += "order by id_us) as t1 inner join (select id_rol, nombre from roles) as t2 on t1.id_rolf = t2.id_rol;";
            return (bd.LeerRegistros(iSql));
        }

        public int SacarUsMax()
        {
            int sgte = Convert.ToInt32(bd.LeerNumerico("SELECT MAX(id_us) FROM usuarios;")) + 1;
            return (sgte);
        }

        public DataSet LeerUsuariosAdmin(string _dato_a_buscar)
        {
            iSql =  "select t1.id_us, t1.nombre, t1.cuenta, t2.nombre from (select id_us, nombre, cuenta, ";
            iSql += "id_rolf from usuarios where status = 'Activo' and id_rolf <= 2 and nombre like('%" + _dato_a_buscar + "%') ";
            iSql += "order by id_us) as t1 inner join (select id_rol, nombre from roles) as t2 on t1.id_rolf = t2.id_rol;";
            return (bd.LeerRegistros(iSql));
        }

        public DataRow localizarUsuario(string _usr)
        {
            iSql = "SELECT * FROM usuarios WHERE id_us = '" + _usr + "';";
            DataRow dr = bd.Leer1Registro(iSql);
            return (dr);
        }

        private string obtieneMD5(string _txt) {

            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(_txt));
            string result = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return result;
        }
        

        public bool insertarUsuario(object[] _datos)
        {
            _datos[3] = obtieneMD5(_datos[3].ToString()); //APLICAR CIFRADO MD5
            return bd.InsertarRegistro("usuarios", _datos);
        }

        public bool modificarUsuario(string _tbl, string[] _campos, object[] _datos, string _key, string _valorkey)
        {
            return (bd.ModificarRegistro(_tbl,_campos,_datos,_key,_valorkey));
                
        }

        public bool modificarUsuarioNuevaClave(string _tbl, string[] _campos, object[] _datos, string _key, string _valorkey)
        {
            _datos[3] = obtieneMD5(_datos[3].ToString()); //APLICAR CIFRADO MD5
            return (bd.ModificarRegistro(_tbl, _campos, _datos, _key, _valorkey));
        }

        public bool desactivarUsuario(string _usr)
        {
            return (bd.EjecutarSQL("UPDATE usuarios SET status = 'Desactivado' where id_us = '" + _usr + "';"));
        }

        public bool ActivarUsuario(string _usr)
        {
            return (bd.EjecutarSQL("UPDATE usuarios SET status = 'Activo' where id_us = '" + _usr + "';"));
        }

        public bool modificarNivel(string _usr, string _nivel)
        {
            return (bd.EjecutarSQL("UPDATE usuarios SET nivel = '" +_nivel + "' where nombre = '" + _usr + "';"));
        }

    }
    #endregion

    #region public class ControlProductos : ControlBD
    public class ControlProductos : ControlBD
    {
        public ControlProductos(ControlConfig _cfg)
        {
            bd = new BDMySQL(_cfg.cadconn);
        }

        public DataSet leerProductos()
        {
            iSql = "SELECT * FROM productos ORDER BY codigo;";
            return (bd.LeerRegistros(iSql));
        }

        public DataSet leerProductos(string _dato_a_buscar)
        {
            iSql = "SELECT * FROM productos WHERE descripcion LIKE('" + _dato_a_buscar + "%') ORDER BY codigo;";
            return (bd.LeerRegistros(iSql));
        }

        public int sigCodigoProducto()
        {
            int sgte = Convert.ToInt32(bd.LeerNumerico("SELECT MAX(codigo) FROM productos;")) + 1;
            return (sgte);
        }

        public DataRow localizarProducto(int _codigo)
        {
            DataRow dr = bd.Leer1Registro("SELECT * FROM productos WHERE codigo = " + _codigo + ";");
            return (dr);
        }

        public DataRow localizarProducto(int _codigo, ref string _error)
        {
            DataRow dr = bd.Leer1Registro("SELECT * FROM productos WHERE codigo = " + _codigo + ";", ref _error);
            return (dr);
        }

        public bool insertarProducto(object[] _datos)
        {
            return (bd.InsertarRegistro("productos", _datos));
        }

        public bool modificarProducto(string[] _campos, object[] _datos, string _key, object _valkey)
        {
            return (bd.ModificarRegistro("productos", _campos, _datos, _key, _valkey));
        }

        public bool eliminarProducto(int _codigo)
        {
            return (bd.EjecutarSQL("DELETE FROM productos WHERE codigo = '" + _codigo + "';"));
        }

        public DataSet clavesDeProveedores(ref ComboBox _cbo)
        {
            DataSet ds = bd.LeerRegistros("SELECT clave FROM proveedores ORDER BY clave;");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _cbo.Items.Add(dr[0].ToString());
            }
            return (ds);
        }

    
    }
    #endregion

    #region public class ControlProveedores : ControlBD
    public class ControlProveedores : ControlBD
    {
        public ControlProveedores(ControlConfig _cfg)
        {
            bd = new BDMySQL(_cfg.cadconn);
        }

        public DataSet leerProveedores()
        {
            iSql = "SELECT * FROM proveedores ORDER BY razon_social;";
            return (bd.LeerRegistros(iSql));
        }

        public DataSet leerProveedores(string _dato_a_buscar)
        {
            iSql = "SELECT * FROM proveedores WHERE razon_social LIKE('" + _dato_a_buscar + "%') or clave LIKE('" + _dato_a_buscar + "%') ORDER BY clave;";
            return (bd.LeerRegistros(iSql));
        }

        public int sigCodigoProducto()
        {
            int sgte = Convert.ToInt32(bd.LeerNumerico("SELECT MAX(codigo) FROM productos;")) + 1;
            return (sgte);
        }

        public DataRow localizarProveedor(string _codigo)
        {
            DataRow dr = bd.Leer1Registro("SELECT * FROM proveedores WHERE clave = '" + _codigo + "';");
            return (dr);
        }

        public DataRow localizarProvedor(string _usr)
        {
            iSql = "SELECT * FROM proveedores WHERE clave = '" + _usr + "';";
            DataRow dr = bd.Leer1Registro(iSql);
            return (dr);
        }

        public bool insertarProveedor(object[] _datos)
        {
            return (bd.InsertarRegistro("proveedores", _datos));
        }

        public bool modificarProveedores(string _tbl, string[] _campos, object[] _datos, string _key, string _valorkey)
        {
            return (bd.ModificarRegistro(_tbl, _campos, _datos, _key, _valorkey));

        }

        public bool eliminarProveedores(string _codigo)
        {
            return (bd.EjecutarSQL("DELETE FROM proveedores WHERE clave = '" + _codigo + "';"));
        }

        public DataSet clavesDeProveedores(ref ComboBox _cbo)
        {
            DataSet ds = bd.LeerRegistros("SELECT clave FROM proveedores ORDER BY clave;");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _cbo.Items.Add(dr[0].ToString());
            }
            return (ds);
        }

          

    }
    #endregion

    //public class ControlEmpleados (Es la misma wea que ControlUsuarios, cambian las consultas, según yo xd)

    //public class TiposProveedor

    //public class Solicitudes

    
}