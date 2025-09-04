namespace lebrun.formularios.facturacion
{
    partial class frmNetoMonedaExt
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_valorDolar = new System.Windows.Forms.Label();
            this.lbl_ValorEuro = new System.Windows.Forms.Label();
            this.txt_netoDolar = new System.Windows.Forms.TextBox();
            this.txt_netoEuro = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Dolar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Euro";
            // 
            // lbl_valorDolar
            // 
            this.lbl_valorDolar.AutoSize = true;
            this.lbl_valorDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_valorDolar.Location = new System.Drawing.Point(25, 54);
            this.lbl_valorDolar.Name = "lbl_valorDolar";
            this.lbl_valorDolar.Size = new System.Drawing.Size(15, 16);
            this.lbl_valorDolar.TabIndex = 2;
            this.lbl_valorDolar.Text = "0";
            this.lbl_valorDolar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ValorEuro
            // 
            this.lbl_ValorEuro.AutoSize = true;
            this.lbl_ValorEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorEuro.Location = new System.Drawing.Point(164, 54);
            this.lbl_ValorEuro.Name = "lbl_ValorEuro";
            this.lbl_ValorEuro.Size = new System.Drawing.Size(15, 16);
            this.lbl_ValorEuro.TabIndex = 3;
            this.lbl_ValorEuro.Text = "0";
            this.lbl_ValorEuro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_netoDolar
            // 
            this.txt_netoDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_netoDolar.Location = new System.Drawing.Point(28, 91);
            this.txt_netoDolar.Name = "txt_netoDolar";
            this.txt_netoDolar.ReadOnly = true;
            this.txt_netoDolar.Size = new System.Drawing.Size(100, 22);
            this.txt_netoDolar.TabIndex = 4;
            this.txt_netoDolar.Text = "0";
            this.txt_netoDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_netoEuro
            // 
            this.txt_netoEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_netoEuro.Location = new System.Drawing.Point(157, 91);
            this.txt_netoEuro.Name = "txt_netoEuro";
            this.txt_netoEuro.ReadOnly = true;
            this.txt_netoEuro.Size = new System.Drawing.Size(100, 22);
            this.txt_netoEuro.TabIndex = 5;
            this.txt_netoEuro.Text = "0";
            this.txt_netoEuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(108, 136);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // frmNetoMonedaExt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 188);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.txt_netoEuro);
            this.Controls.Add(this.txt_netoDolar);
            this.Controls.Add(this.lbl_ValorEuro);
            this.Controls.Add(this.lbl_valorDolar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmNetoMonedaExt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neto Moneda Ext";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_valorDolar;
        private System.Windows.Forms.Label lbl_ValorEuro;
        private System.Windows.Forms.TextBox txt_netoDolar;
        private System.Windows.Forms.TextBox txt_netoEuro;
        private System.Windows.Forms.Button btn_salir;
    }
}