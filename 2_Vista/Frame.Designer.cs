namespace Mina
{
    partial class Frame
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudDeAltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.activosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbx = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraciónToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem1,
            this.tiposDeProveedoresToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // tiposDeProveedoresToolStripMenuItem
            // 
            this.tiposDeProveedoresToolStripMenuItem.Name = "tiposDeProveedoresToolStripMenuItem";
            this.tiposDeProveedoresToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.tiposDeProveedoresToolStripMenuItem.Text = "Tipos de Proveedores";
            this.tiposDeProveedoresToolStripMenuItem.Click += new System.EventHandler(this.tiposDeProveedoresToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadosToolStripMenuItem,
            this.proveedoresToolStripMenuItem1,
            this.productosToolStripMenuItem});
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem1
            // 
            this.proveedoresToolStripMenuItem1.Name = "proveedoresToolStripMenuItem1";
            this.proveedoresToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.proveedoresToolStripMenuItem1.Text = "Proveedores";
            this.proveedoresToolStripMenuItem1.Click += new System.EventHandler(this.proveedoresToolStripMenuItem1_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem1,
            this.proveedoresToolStripMenuItem2,
            this.solicitudDeAltaToolStripMenuItem,
            this.solicitudDeBajaToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // productosToolStripMenuItem1
            // 
            this.productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            this.productosToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.productosToolStripMenuItem1.Text = "Productos";
            this.productosToolStripMenuItem1.Click += new System.EventHandler(this.productosToolStripMenuItem1_Click);
            // 
            // proveedoresToolStripMenuItem2
            // 
            this.proveedoresToolStripMenuItem2.Name = "proveedoresToolStripMenuItem2";
            this.proveedoresToolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
            this.proveedoresToolStripMenuItem2.Text = "Proveedores";
            this.proveedoresToolStripMenuItem2.Click += new System.EventHandler(this.proveedoresToolStripMenuItem2_Click);
            // 
            // solicitudDeAltaToolStripMenuItem
            // 
            this.solicitudDeAltaToolStripMenuItem.Name = "solicitudDeAltaToolStripMenuItem";
            this.solicitudDeAltaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.solicitudDeAltaToolStripMenuItem.Text = "Solicitud de alta";
            this.solicitudDeAltaToolStripMenuItem.Click += new System.EventHandler(this.solicitudDeAltaToolStripMenuItem_Click);
            // 
            // solicitudDeBajaToolStripMenuItem
            // 
            this.solicitudDeBajaToolStripMenuItem.Name = "solicitudDeBajaToolStripMenuItem";
            this.solicitudDeBajaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.solicitudDeBajaToolStripMenuItem.Text = "Solicitud de baja";
            this.solicitudDeBajaToolStripMenuItem.Click += new System.EventHandler(this.solicitudDeBajaToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem1
            // 
            this.usuariosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activosToolStripMenuItem,
            this.desactivadosToolStripMenuItem});
            this.usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            this.usuariosToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.usuariosToolStripMenuItem1.Text = "Usuarios";
            // 
            // activosToolStripMenuItem
            // 
            this.activosToolStripMenuItem.Name = "activosToolStripMenuItem";
            this.activosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.activosToolStripMenuItem.Text = "Activos";
            this.activosToolStripMenuItem.Click += new System.EventHandler(this.activosToolStripMenuItem_Click);
            // 
            // desactivadosToolStripMenuItem
            // 
            this.desactivadosToolStripMenuItem.Name = "desactivadosToolStripMenuItem";
            this.desactivadosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.desactivadosToolStripMenuItem.Text = "Desactivados";
            this.desactivadosToolStripMenuItem.Click += new System.EventHandler(this.desactivadosToolStripMenuItem_Click);
            // 
            // pbx
            // 
            this.pbx.Image = global::Mina.Properties.Resources.buscaminas;
            this.pbx.Location = new System.Drawing.Point(710, 332);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(497, 327);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx.TabIndex = 2;
            this.pbx.TabStop = false;
            this.pbx.Visible = false;
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 507);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mina";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem solicitudDeAltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitudDeBajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem activosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivadosToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbx;
    }
}

