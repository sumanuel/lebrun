namespace lebrun.formularios.clientes
{
    partial class lbxTipoNegocio
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
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primeraLeyendaDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segundaLeyendaDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocentajePrimeraLeyenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeSegundaLeyenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.groupBox1.Controls.Add(this.cmdModificar);
            this.groupBox1.Controls.Add(this.cmdAgregar);
            this.groupBox1.Controls.Add(this.cmdSalir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = global::lebrun.Properties.Resources._24x24_1372886216_go_back;
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdModificar.Location = new System.Drawing.Point(386, 248);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(82, 36);
            this.cmdModificar.TabIndex = 89;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = global::lebrun.Properties.Resources.Add_24x24;
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(287, 248);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(82, 36);
            this.cmdAgregar.TabIndex = 88;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = global::lebrun.Properties.Resources.LogOut_24x24;
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSalir.Location = new System.Drawing.Point(492, 248);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(82, 36);
            this.cmdSalir.TabIndex = 87;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipos Negocios";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descripcion,
            this.descuento1,
            this.descuento2,
            this.descuento3,
            this.primeraLeyendaDias,
            this.segundaLeyendaDias,
            this.activo,
            this.observaciones,
            this.pocentajePrimeraLeyenda,
            this.porcentajeSegundaLeyenda});
            this.dataGridView1.Location = new System.Drawing.Point(6, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(573, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            // 
            // descuento1
            // 
            this.descuento1.DataPropertyName = "descuento1";
            this.descuento1.HeaderText = "descuento1";
            this.descuento1.Name = "descuento1";
            this.descuento1.Visible = false;
            // 
            // descuento2
            // 
            this.descuento2.DataPropertyName = "descuento2";
            this.descuento2.HeaderText = "descuento2";
            this.descuento2.Name = "descuento2";
            this.descuento2.Visible = false;
            // 
            // descuento3
            // 
            this.descuento3.DataPropertyName = "descuento3";
            this.descuento3.HeaderText = "descuento3";
            this.descuento3.Name = "descuento3";
            this.descuento3.Visible = false;
            // 
            // primeraLeyendaDias
            // 
            this.primeraLeyendaDias.DataPropertyName = "primeraLeyendaDias";
            this.primeraLeyendaDias.HeaderText = "primeraLeyendaDias";
            this.primeraLeyendaDias.Name = "primeraLeyendaDias";
            this.primeraLeyendaDias.Visible = false;
            // 
            // segundaLeyendaDias
            // 
            this.segundaLeyendaDias.DataPropertyName = "segundaLeyendaDias";
            this.segundaLeyendaDias.HeaderText = "segundaLeyendaDias";
            this.segundaLeyendaDias.Name = "segundaLeyendaDias";
            this.segundaLeyendaDias.Visible = false;
            // 
            // activo
            // 
            this.activo.DataPropertyName = "activo";
            this.activo.HeaderText = "activo";
            this.activo.Name = "activo";
            // 
            // observaciones
            // 
            this.observaciones.DataPropertyName = "observaciones";
            this.observaciones.HeaderText = "observaciones";
            this.observaciones.Name = "observaciones";
            this.observaciones.Visible = false;
            // 
            // pocentajePrimeraLeyenda
            // 
            this.pocentajePrimeraLeyenda.DataPropertyName = "pocentajePrimeraLeyenda";
            this.pocentajePrimeraLeyenda.HeaderText = "Pocentaje P. Leyenda";
            this.pocentajePrimeraLeyenda.Name = "pocentajePrimeraLeyenda";
            this.pocentajePrimeraLeyenda.Visible = false;
            // 
            // porcentajeSegundaLeyenda
            // 
            this.porcentajeSegundaLeyenda.DataPropertyName = "porcentajeSegundaLeyenda";
            this.porcentajeSegundaLeyenda.HeaderText = "Porcentaje S. Leyenda";
            this.porcentajeSegundaLeyenda.Name = "porcentajeSegundaLeyenda";
            this.porcentajeSegundaLeyenda.Visible = false;
            // 
            // lbxTipoNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(609, 316);
            this.Controls.Add(this.groupBox1);
            this.Name = "lbxTipoNegocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lbx TipoNegocio";
            this.Load += new System.EventHandler(this.lbxTipoNegocio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.Button cmdSalir;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento2;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento3;
        private System.Windows.Forms.DataGridViewTextBoxColumn primeraLeyendaDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn segundaLeyendaDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocentajePrimeraLeyenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeSegundaLeyenda;
    }
}