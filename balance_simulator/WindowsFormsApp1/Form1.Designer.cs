namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btnTara = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnQuitarPlato = new System.Windows.Forms.Button();
            this.btnPonerPlato = new System.Windows.Forms.Button();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_aumentar = new System.Windows.Forms.Button();
            this.btn_disminuir = new System.Windows.Forms.Button();
            this.lblPesoinf = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPesoDat = new System.Windows.Forms.Label();
            this.lblPesoBrutoDat = new System.Windows.Forms.Label();
            this.lblPesoTaraDat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTara
            // 
            this.btnTara.Location = new System.Drawing.Point(312, 42);
            this.btnTara.Name = "btnTara";
            this.btnTara.Size = new System.Drawing.Size(75, 23);
            this.btnTara.TabIndex = 0;
            this.btnTara.Text = "Tara";
            this.btnTara.UseVisualStyleBackColor = true;
            this.btnTara.Click += new System.EventHandler(this.btnTara_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "PESO:";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.Location = new System.Drawing.Point(119, 9);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(79, 31);
            this.lblPeso.TabIndex = 2;
            this.lblPeso.Text = "0 KG";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(299, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Tara automatico";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnQuitarPlato
            // 
            this.btnQuitarPlato.Location = new System.Drawing.Point(21, 167);
            this.btnQuitarPlato.Name = "btnQuitarPlato";
            this.btnQuitarPlato.Size = new System.Drawing.Size(91, 23);
            this.btnQuitarPlato.TabIndex = 4;
            this.btnQuitarPlato.Text = "Quitar plato";
            this.btnQuitarPlato.UseVisualStyleBackColor = true;
            this.btnQuitarPlato.Click += new System.EventHandler(this.btnQuitarPlato_Click);
            // 
            // btnPonerPlato
            // 
            this.btnPonerPlato.Location = new System.Drawing.Point(21, 138);
            this.btnPonerPlato.Name = "btnPonerPlato";
            this.btnPonerPlato.Size = new System.Drawing.Size(91, 23);
            this.btnPonerPlato.TabIndex = 5;
            this.btnPonerPlato.Text = "Poner plato";
            this.btnPonerPlato.UseVisualStyleBackColor = true;
            this.btnPonerPlato.Click += new System.EventHandler(this.btnPonerPlato_Click);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(137, 140);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(75, 20);
            this.txtPeso.TabIndex = 6;
            this.txtPeso.Text = "0";
            this.txtPeso.TextChanged += new System.EventHandler(this.txtPeso_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "KG";
            // 
            // btn_aumentar
            // 
            this.btn_aumentar.Location = new System.Drawing.Point(138, 167);
            this.btn_aumentar.Name = "btn_aumentar";
            this.btn_aumentar.Size = new System.Drawing.Size(42, 23);
            this.btn_aumentar.TabIndex = 8;
            this.btn_aumentar.Text = "+";
            this.btn_aumentar.UseVisualStyleBackColor = true;
            this.btn_aumentar.Click += new System.EventHandler(this.btn_aumentar_Click);
            // 
            // btn_disminuir
            // 
            this.btn_disminuir.Location = new System.Drawing.Point(186, 167);
            this.btn_disminuir.Name = "btn_disminuir";
            this.btn_disminuir.Size = new System.Drawing.Size(41, 23);
            this.btn_disminuir.TabIndex = 9;
            this.btn_disminuir.Text = "-";
            this.btn_disminuir.UseVisualStyleBackColor = true;
            this.btn_disminuir.Click += new System.EventHandler(this.btn_disminuir_Click);
            // 
            // lblPesoinf
            // 
            this.lblPesoinf.AutoSize = true;
            this.lblPesoinf.Location = new System.Drawing.Point(333, 123);
            this.lblPesoinf.Name = "lblPesoinf";
            this.lblPesoinf.Size = new System.Drawing.Size(37, 13);
            this.lblPesoinf.TabIndex = 10;
            this.lblPesoinf.Text = "Peso: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Peso bruto: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tara: ";
            // 
            // lblPesoDat
            // 
            this.lblPesoDat.AutoSize = true;
            this.lblPesoDat.Location = new System.Drawing.Point(382, 123);
            this.lblPesoDat.Name = "lblPesoDat";
            this.lblPesoDat.Size = new System.Drawing.Size(31, 13);
            this.lblPesoDat.TabIndex = 13;
            this.lblPesoDat.Text = "0 KG";
            // 
            // lblPesoBrutoDat
            // 
            this.lblPesoBrutoDat.AutoSize = true;
            this.lblPesoBrutoDat.Location = new System.Drawing.Point(382, 147);
            this.lblPesoBrutoDat.Name = "lblPesoBrutoDat";
            this.lblPesoBrutoDat.Size = new System.Drawing.Size(31, 13);
            this.lblPesoBrutoDat.TabIndex = 14;
            this.lblPesoBrutoDat.Text = "0 KG";
            // 
            // lblPesoTaraDat
            // 
            this.lblPesoTaraDat.AutoSize = true;
            this.lblPesoTaraDat.Location = new System.Drawing.Point(382, 169);
            this.lblPesoTaraDat.Name = "lblPesoTaraDat";
            this.lblPesoTaraDat.Size = new System.Drawing.Size(31, 13);
            this.lblPesoTaraDat.TabIndex = 15;
            this.lblPesoTaraDat.Text = "0 KG";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 199);
            this.Controls.Add(this.lblPesoTaraDat);
            this.Controls.Add(this.lblPesoBrutoDat);
            this.Controls.Add(this.lblPesoDat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPesoinf);
            this.Controls.Add(this.btn_disminuir);
            this.Controls.Add(this.btn_aumentar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.btnPonerPlato);
            this.Controls.Add(this.btnQuitarPlato);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTara);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnQuitarPlato;
        private System.Windows.Forms.Button btnPonerPlato;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_aumentar;
        private System.Windows.Forms.Button btn_disminuir;
        private System.Windows.Forms.Label lblPesoinf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPesoDat;
        private System.Windows.Forms.Label lblPesoBrutoDat;
        private System.Windows.Forms.Label lblPesoTaraDat;
    }
}

