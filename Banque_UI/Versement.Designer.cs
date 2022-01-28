
namespace Banque_UI
{
    partial class Versement
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Numero = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Numero)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "give the number of the Compte To transfer to";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Numero
            // 
            this.Numero.Location = new System.Drawing.Point(29, 64);
            this.Numero.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(242, 20);
            this.Numero.TabIndex = 5;
            // 
            // Versement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 193);
            this.Controls.Add(this.Numero);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Versement";
            this.Text = "Versement";
            ((System.ComponentModel.ISupportInitialize)(this.Numero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown Numero;
    }
}