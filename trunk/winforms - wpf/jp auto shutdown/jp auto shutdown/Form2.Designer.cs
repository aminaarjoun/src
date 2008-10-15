namespace jp_auto_shutdown
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numH = new System.Windows.Forms.NumericUpDown();
            this.numM = new System.Windows.Forms.NumericUpDown();
            this.numSeg = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeg)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::jp_auto_shutdown.Properties.Resources.clock;
            this.pictureBox1.Location = new System.Drawing.Point(79, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 116);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // numH
            // 
            this.numH.Location = new System.Drawing.Point(8, 148);
            this.numH.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numH.Name = "numH";
            this.numH.Size = new System.Drawing.Size(70, 20);
            this.numH.TabIndex = 2;
            this.numH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numM
            // 
            this.numM.Location = new System.Drawing.Point(100, 148);
            this.numM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numM.Name = "numM";
            this.numM.Size = new System.Drawing.Size(70, 20);
            this.numM.TabIndex = 3;
            this.numM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numM.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numSeg
            // 
            this.numSeg.Location = new System.Drawing.Point(189, 148);
            this.numSeg.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numSeg.Name = "numSeg";
            this.numSeg.Size = new System.Drawing.Size(70, 20);
            this.numSeg.TabIndex = 4;
            this.numSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.Location = new System.Drawing.Point(39, 211);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 33);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(146, 211);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 33);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "\'";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(263, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "\'\'";
            // 
            // Form2
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.numSeg);
            this.Controls.Add(this.numM);
            this.Controls.Add(this.numH);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiempo de apagado";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numH;
        private System.Windows.Forms.NumericUpDown numM;
        private System.Windows.Forms.NumericUpDown numSeg;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}