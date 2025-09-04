namespace lebrun.formularios.facturacion
{
    partial class lbxFacturas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdVer = new System.Windows.Forms.Button();
            this.cmdDevolucion = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(16, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(796, 283);
            this.dataGridView1.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdLimpiar);
            this.groupBox2.Controls.Add(this.cmdSalir);
            this.groupBox2.Controls.Add(this.cmdImprimir);
            this.groupBox2.Controls.Add(this.cmdVer);
            this.groupBox2.Controls.Add(this.cmdDevolucion);
            this.groupBox2.Controls.Add(this.cmdAgregar);
            this.groupBox2.Location = new System.Drawing.Point(22, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 99);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciónes de Sistema";
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Image = global::lebrun.Properties.Resources.Refresh_24x24;
            this.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdLimpiar.Location = new System.Drawing.Point(221, 15);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(82, 36);
            this.cmdLimpiar.TabIndex = 37;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            this.cmdLimpiar.MouseEnter += new System.EventHandler(this.cmdLimpiar_MouseEnter);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = global::lebrun.Properties.Resources.LogOut_24x24;
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSalir.Location = new System.Drawing.Point(222, 56);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(82, 36);
            this.cmdSalir.TabIndex = 38;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Enabled = false;
            this.cmdImprimir.Image = global::lebrun.Properties.Resources.Print_24x24;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(116, 56);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(94, 36);
            this.cmdImprimir.TabIndex = 34;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdVer
            // 
            this.cmdVer.Image = global::lebrun.Properties.Resources.Find_24x24;
            this.cmdVer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdVer.Location = new System.Drawing.Point(17, 56);
            this.cmdVer.Name = "cmdVer";
            this.cmdVer.Size = new System.Drawing.Size(88, 36);
            this.cmdVer.TabIndex = 33;
            this.cmdVer.Text = "Ver";
            this.cmdVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdVer.UseVisualStyleBackColor = true;
            this.cmdVer.Click += new System.EventHandler(this.cmdVer_Click);
            // 
            // cmdDevolucion
            // 
            this.cmdDevolucion.Enabled = false;
            this.cmdDevolucion.Image = global::lebrun.Properties.Resources._24x24_1372886216_go_back;
            this.cmdDevolucion.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdDevolucion.Location = new System.Drawing.Point(116, 14);
            this.cmdDevolucion.Name = "cmdDevolucion";
            this.cmdDevolucion.Size = new System.Drawing.Size(94, 36);
            this.cmdDevolucion.TabIndex = 32;
            this.cmdDevolucion.Text = "Devolucion";
            this.cmdDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDevolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDevolucion.UseVisualStyleBackColor = true;
            this.cmdDevolucion.Click += new System.EventHandler(this.cmdDevolucion_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Enabled = false;
            this.cmdAgregar.Image = global::lebrun.Properties.Resources.Add_24x24;
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(17, 15);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(88, 36);
            this.cmdAgregar.TabIndex = 31;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 400);
            this.progressBar1.Maximum = 6;
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(796, 18);
            this.progressBar1.TabIndex = 45;
            this.progressBar1.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Número, Cliente, Num. Fiscal";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(9, 52);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(175, 20);
            this.txtBuscar.TabIndex = 29;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::lebrun.Properties.Resources.Search_24x24;
            this.cmdBuscar.Location = new System.Drawing.Point(399, 43);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(45, 36);
            this.cmdBuscar.TabIndex = 30;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkFecha);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dateTimePicker2);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Location = new System.Drawing.Point(203, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 80);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(7, -1);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(75, 17);
            this.chkFecha.TabIndex = 43;
            this.chkFecha.Text = "Por Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Fecha Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Fecha Desde";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(81, 52);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(90, 20);
            this.dateTimePicker2.TabIndex = 40;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(90, 20);
            this.dateTimePicker1.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cmdBuscar);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(365, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 99);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones de Busqueda";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::lebrun.Properties.Resources.loading_bar;
            this.pictureBox1.Location = new System.Drawing.Point(143, 160);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(566, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // lbxFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(840, 426);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "lbxFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lebrun - ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.lbxFacturas_FormClosing);
            this.Load += new System.EventHandler(this.lbxFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdVer;
        private System.Windows.Forms.Button cmdDevolucion;
        private System.Windows.Forms.Button cmdAgregar;
        protected System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;


    }
}