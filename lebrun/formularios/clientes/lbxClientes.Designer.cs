namespace lebrun.formularios.facturacion
{
    partial class lbxClientes
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grupo = new System.Windows.Forms.RadioButton();
            this.descripcion = new System.Windows.Forms.RadioButton();
            this.codigo = new System.Windows.Forms.RadioButton();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmdModificarCli = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(5, 27);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(175, 20);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmdLimpiar);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.cmdSalir);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.cmdModificarCli);
            this.groupBox1.Controls.Add(this.cmdAgregar);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 401);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda de clientes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.grupo);
            this.groupBox2.Controls.Add(this.descripcion);
            this.groupBox2.Controls.Add(this.codigo);
            this.groupBox2.Controls.Add(this.cmdBuscar);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 52);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            // 
            // grupo
            // 
            this.grupo.AutoSize = true;
            this.grupo.Location = new System.Drawing.Point(156, 9);
            this.grupo.Name = "grupo";
            this.grupo.Size = new System.Drawing.Size(38, 17);
            this.grupo.TabIndex = 45;
            this.grupo.Text = "Rif";
            this.grupo.UseVisualStyleBackColor = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSize = true;
            this.descripcion.Location = new System.Drawing.Point(69, 9);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(62, 17);
            this.descripcion.TabIndex = 44;
            this.descripcion.Text = "Nombre";
            this.descripcion.UseVisualStyleBackColor = true;
            // 
            // codigo
            // 
            this.codigo.AutoSize = true;
            this.codigo.Checked = true;
            this.codigo.Location = new System.Drawing.Point(5, 9);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(58, 17);
            this.codigo.TabIndex = 43;
            this.codigo.TabStop = true;
            this.codigo.Text = "Codigo";
            this.codigo.UseVisualStyleBackColor = true;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::lebrun.Properties.Resources.Search_24x24;
            this.cmdBuscar.Location = new System.Drawing.Point(216, 11);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(45, 36);
            this.cmdBuscar.TabIndex = 1;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Image = global::lebrun.Properties.Resources.Refresh_24x24;
            this.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdLimpiar.Location = new System.Drawing.Point(641, 26);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(82, 36);
            this.cmdLimpiar.TabIndex = 6;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(15, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(796, 315);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = global::lebrun.Properties.Resources.LogOut_24x24;
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSalir.Location = new System.Drawing.Point(729, 26);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(82, 36);
            this.cmdSalir.TabIndex = 7;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // button5
            // 
            this.button5.Image = global::lebrun.Properties.Resources.Print_24x24;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button5.Location = new System.Drawing.Point(553, 26);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 36);
            this.button5.TabIndex = 5;
            this.button5.Text = "Imprimir";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = global::lebrun.Properties.Resources.Delete_24x24;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button4.Location = new System.Drawing.Point(465, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 36);
            this.button4.TabIndex = 4;
            this.button4.Text = "Eliminar";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // cmdModificarCli
            // 
            this.cmdModificarCli.Image = global::lebrun.Properties.Resources.Edit_24x24;
            this.cmdModificarCli.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdModificarCli.Location = new System.Drawing.Point(377, 26);
            this.cmdModificarCli.Name = "cmdModificarCli";
            this.cmdModificarCli.Size = new System.Drawing.Size(82, 36);
            this.cmdModificarCli.TabIndex = 3;
            this.cmdModificarCli.Text = "Modificar";
            this.cmdModificarCli.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdModificarCli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdModificarCli.UseVisualStyleBackColor = true;
            this.cmdModificarCli.Click += new System.EventHandler(this.cmdModificarCli_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = global::lebrun.Properties.Resources.Add_24x24;
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(292, 26);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(82, 36);
            this.cmdAgregar.TabIndex = 2;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // lbxClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 418);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "lbxClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lebrun - Lbx Clientes";
            this.Load += new System.EventHandler(this.lbxClientes_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.lbxClientes_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.Button cmdModificarCli;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.RadioButton grupo;
        private System.Windows.Forms.RadioButton descripcion;
        private System.Windows.Forms.RadioButton codigo;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}