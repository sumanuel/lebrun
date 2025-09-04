namespace lebrun.formularios.complementos
{
    partial class frmConsultaArticulos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grupo = new System.Windows.Forms.RadioButton();
            this.descripcion = new System.Windows.Forms.RadioButton();
            this.codigo = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblUltimoCod = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cmdSalir);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(841, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grupo);
            this.groupBox3.Controls.Add(this.descripcion);
            this.groupBox3.Controls.Add(this.codigo);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(10, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 62);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            // 
            // grupo
            // 
            this.grupo.AutoSize = true;
            this.grupo.Location = new System.Drawing.Point(161, 13);
            this.grupo.Name = "grupo";
            this.grupo.Size = new System.Drawing.Size(54, 17);
            this.grupo.TabIndex = 42;
            this.grupo.Text = "Grupo";
            this.grupo.UseVisualStyleBackColor = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSize = true;
            this.descripcion.Location = new System.Drawing.Point(74, 13);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(81, 17);
            this.descripcion.TabIndex = 41;
            this.descripcion.Text = "Descripcion";
            this.descripcion.UseVisualStyleBackColor = true;
            // 
            // codigo
            // 
            this.codigo.AutoSize = true;
            this.codigo.Checked = true;
            this.codigo.Location = new System.Drawing.Point(10, 13);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(58, 17);
            this.codigo.TabIndex = 40;
            this.codigo.TabStop = true;
            this.codigo.Text = "Codigo";
            this.codigo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::lebrun.Properties.Resources.Search_24x24;
            this.button1.Location = new System.Drawing.Point(312, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 36);
            this.button1.TabIndex = 31;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseUp);
            // 
            // cmdSalir
            // 
            this.cmdSalir.ForeColor = System.Drawing.Color.Black;
            this.cmdSalir.Image = global::lebrun.Properties.Resources.LogOut_24x24;
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalir.Location = new System.Drawing.Point(745, 26);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(79, 36);
            this.cmdSalir.TabIndex = 39;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(9, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(841, 356);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(830, 332);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // lblUltimoCod
            // 
            this.lblUltimoCod.AutoSize = true;
            this.lblUltimoCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoCod.Location = new System.Drawing.Point(19, 456);
            this.lblUltimoCod.Name = "lblUltimoCod";
            this.lblUltimoCod.Size = new System.Drawing.Size(0, 13);
            this.lblUltimoCod.TabIndex = 2;
            // 
            // frmConsultaArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 476);
            this.Controls.Add(this.lblUltimoCod);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmConsultaArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.lbxProductos_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.lbxProductos_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Label lblUltimoCod;
        private System.Windows.Forms.RadioButton grupo;
        private System.Windows.Forms.RadioButton descripcion;
        private System.Windows.Forms.RadioButton codigo;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}