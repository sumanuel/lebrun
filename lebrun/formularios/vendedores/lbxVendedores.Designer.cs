namespace lebrun.formularios.vendedores
{
    partial class lbxVendedores
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
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Image = global::lebrun.Properties.Resources.Refresh_24x24;
            this.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdLimpiar.Location = new System.Drawing.Point(626, 17);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(82, 36);
            this.cmdLimpiar.TabIndex = 35;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(15, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(796, 315);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = global::lebrun.Properties.Resources.LogOut_24x24;
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSalir.Location = new System.Drawing.Point(714, 17);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(82, 36);
            this.cmdSalir.TabIndex = 36;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Image = global::lebrun.Properties.Resources.Print_24x24;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(538, 17);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(82, 36);
            this.cmdImprimir.TabIndex = 34;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdImprimir.UseVisualStyleBackColor = true;
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.Image = global::lebrun.Properties.Resources.Delete_24x24;
            this.cmdEliminar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdEliminar.Location = new System.Drawing.Point(450, 17);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(82, 36);
            this.cmdEliminar.TabIndex = 33;
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEliminar.UseVisualStyleBackColor = true;
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = global::lebrun.Properties.Resources.Edit_24x24;
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdModificar.Location = new System.Drawing.Point(362, 17);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(82, 36);
            this.cmdModificar.TabIndex = 32;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdModificar.UseVisualStyleBackColor = true;
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = global::lebrun.Properties.Resources.Add_24x24;
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(277, 17);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(82, 36);
            this.cmdAgregar.TabIndex = 31;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAgregar.UseVisualStyleBackColor = true;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::lebrun.Properties.Resources.Search_24x24;
            this.cmdBuscar.Location = new System.Drawing.Point(196, 17);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(45, 36);
            this.cmdBuscar.TabIndex = 30;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(15, 33);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(175, 20);
            this.txtBuscar.TabIndex = 29;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Código Vendedor ,Nombre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdLimpiar);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.cmdSalir);
            this.groupBox1.Controls.Add(this.cmdImprimir);
            this.groupBox1.Controls.Add(this.cmdEliminar);
            this.groupBox1.Controls.Add(this.cmdModificar);
            this.groupBox1.Controls.Add(this.cmdAgregar);
            this.groupBox1.Controls.Add(this.cmdBuscar);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 395);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda Vendedores";
            // 
            // lbxVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 418);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "lbxVendedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lebrun - LbxVendedores";
            this.Load += new System.EventHandler(this.lbxVendedores_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.lbxVendedores_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}