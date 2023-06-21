namespace Cryptography.Algorithms.Rabbit.WinTest.UI
{
    partial class FormPrincipal
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
            this.btnCifrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImagen = new System.Windows.Forms.Button();
            this.btnBytes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIVInicial = new System.Windows.Forms.TextBox();
            this.txtKeyInicial = new System.Windows.Forms.TextBox();
            this.txtBytesRabbit = new System.Windows.Forms.TextBox();
            this.txtBytesInicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbImagenRabbit = new System.Windows.Forms.PictureBox();
            this.pbImagenInicial = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenRabbit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenInicial)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCifrar
            // 
            this.btnCifrar.Location = new System.Drawing.Point(35, 657);
            this.btnCifrar.Name = "btnCifrar";
            this.btnCifrar.Size = new System.Drawing.Size(387, 47);
            this.btnCifrar.TabIndex = 12;
            this.btnCifrar.Text = "CIFRAR";
            this.btnCifrar.UseVisualStyleBackColor = true;
            this.btnCifrar.Click += new System.EventHandler(this.BtnCifrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(428, 657);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(376, 47);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImagen);
            this.tabPage1.Controls.Add(this.btnBytes);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtIVInicial);
            this.tabPage1.Controls.Add(this.txtKeyInicial);
            this.tabPage1.Controls.Add(this.txtBytesRabbit);
            this.tabPage1.Controls.Add(this.txtBytesInicial);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pbImagenRabbit);
            this.tabPage1.Controls.Add(this.pbImagenInicial);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 715);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Visualizador";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImagen
            // 
            this.btnImagen.Location = new System.Drawing.Point(19, 86);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(387, 23);
            this.btnImagen.TabIndex = 27;
            this.btnImagen.Text = "Seleccionar imagen";
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Click += new System.EventHandler(this.BtnImagen_Click);
            // 
            // btnBytes
            // 
            this.btnBytes.Location = new System.Drawing.Point(412, 86);
            this.btnBytes.Name = "btnBytes";
            this.btnBytes.Size = new System.Drawing.Size(376, 23);
            this.btnBytes.TabIndex = 28;
            this.btnBytes.Text = "Cargar Imagen desde Bytes";
            this.btnBytes.UseVisualStyleBackColor = true;
            this.btnBytes.Click += new System.EventHandler(this.BtnBytes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "IV";
            // 
            // txtIVInicial
            // 
            this.txtIVInicial.Location = new System.Drawing.Point(19, 60);
            this.txtIVInicial.Name = "txtIVInicial";
            this.txtIVInicial.Size = new System.Drawing.Size(769, 20);
            this.txtIVInicial.TabIndex = 25;
            // 
            // txtKeyInicial
            // 
            this.txtKeyInicial.Location = new System.Drawing.Point(19, 21);
            this.txtKeyInicial.Name = "txtKeyInicial";
            this.txtKeyInicial.Size = new System.Drawing.Size(769, 20);
            this.txtKeyInicial.TabIndex = 23;
            // 
            // txtBytesRabbit
            // 
            this.txtBytesRabbit.Location = new System.Drawing.Point(412, 421);
            this.txtBytesRabbit.Multiline = true;
            this.txtBytesRabbit.Name = "txtBytesRabbit";
            this.txtBytesRabbit.ReadOnly = true;
            this.txtBytesRabbit.Size = new System.Drawing.Size(376, 200);
            this.txtBytesRabbit.TabIndex = 21;
            // 
            // txtBytesInicial
            // 
            this.txtBytesInicial.Location = new System.Drawing.Point(19, 421);
            this.txtBytesInicial.Multiline = true;
            this.txtBytesInicial.Name = "txtBytesInicial";
            this.txtBytesInicial.ReadOnly = true;
            this.txtBytesInicial.Size = new System.Drawing.Size(387, 200);
            this.txtBytesInicial.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Key";
            // 
            // pbImagenRabbit
            // 
            this.pbImagenRabbit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagenRabbit.Location = new System.Drawing.Point(412, 115);
            this.pbImagenRabbit.Name = "pbImagenRabbit";
            this.pbImagenRabbit.Size = new System.Drawing.Size(376, 300);
            this.pbImagenRabbit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenRabbit.TabIndex = 22;
            this.pbImagenRabbit.TabStop = false;
            // 
            // pbImagenInicial
            // 
            this.pbImagenInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagenInicial.Location = new System.Drawing.Point(19, 115);
            this.pbImagenInicial.Name = "pbImagenInicial";
            this.pbImagenInicial.Size = new System.Drawing.Size(387, 300);
            this.pbImagenInicial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenInicial.TabIndex = 0;
            this.pbImagenInicial.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 741);
            this.tabControl1.TabIndex = 14;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 761);
            this.Controls.Add(this.btnCifrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormPrincipal";
            this.Text = "Rabbit";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenRabbit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenInicial)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCifrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.Button btnBytes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIVInicial;
        private System.Windows.Forms.TextBox txtKeyInicial;
        private System.Windows.Forms.TextBox txtBytesRabbit;
        private System.Windows.Forms.TextBox txtBytesInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbImagenRabbit;
        private System.Windows.Forms.PictureBox pbImagenInicial;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

