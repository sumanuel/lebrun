namespace lebrun.formularios.bancos
{
    partial class frmBancos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCasillero = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.txtTelf1 = new System.Windows.Forms.TextBox();
            this.txtTelf2 = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 151);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Observaciones";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(8, 19);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(720, 123);
            this.txtObservacion.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Image = global::lebrun.Properties.Resources.LogOut_24x24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(637, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 21;
            this.button1.Text = "    Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::lebrun.Properties.Resources.Check_24x24;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.Location = new System.Drawing.Point(489, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = " Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.txtCasillero);
            this.groupBox2.Controls.Add(this.txtClave);
            this.groupBox2.Controls.Add(this.txtLogin);
            this.groupBox2.Controls.Add(this.txtWeb);
            this.groupBox2.Controls.Add(this.txtTelf1);
            this.groupBox2.Controls.Add(this.txtTelf2);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.cmbEstatus);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.groupBox2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 191);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // txtCasillero
            // 
            this.txtCasillero.Location = new System.Drawing.Point(416, 146);
            this.txtCasillero.Name = "txtCasillero";
            this.txtCasillero.Size = new System.Drawing.Size(100, 20);
            this.txtCasillero.TabIndex = 9;
            this.txtCasillero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(218, 146);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(89, 20);
            this.txtClave.TabIndex = 8;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(74, 146);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(98, 20);
            this.txtLogin.TabIndex = 7;
            this.txtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(74, 104);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(233, 20);
            this.txtWeb.TabIndex = 5;
            this.txtWeb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtTelf1
            // 
            this.txtTelf1.Location = new System.Drawing.Point(368, 63);
            this.txtTelf1.Name = "txtTelf1";
            this.txtTelf1.Size = new System.Drawing.Size(100, 20);
            this.txtTelf1.TabIndex = 3;
            this.txtTelf1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtTelf2
            // 
            this.txtTelf2.Location = new System.Drawing.Point(551, 63);
            this.txtTelf2.Name = "txtTelf2";
            this.txtTelf2.Size = new System.Drawing.Size(100, 20);
            this.txtTelf2.TabIndex = 4;
            this.txtTelf2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(74, 63);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(233, 20);
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(233, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(418, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(74, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(98, 20);
            this.txtCodigo.TabIndex = 23;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstatus.Location = new System.Drawing.Point(368, 103);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(100, 21);
            this.cmbEstatus.TabIndex = 6;
            this.cmbEstatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Casillero Postal";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Clave";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Login";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Web";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Estatus";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Telefono 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Telefono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Direccion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Codigo";
            // 
            // frmBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(758, 426);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bancos";
            this.Load += new System.EventHandler(this.frmBancos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCasillero;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.TextBox txtTelf1;
        private System.Windows.Forms.TextBox txtTelf2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNombre;
    }
}