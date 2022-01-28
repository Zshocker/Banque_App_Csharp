using System.Windows.Forms;
namespace Banque_UI
{
    partial class Internal_App_Client
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
                Application.Exit();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Currency = new System.Windows.Forms.ComboBox();
            this.Verser = new System.Windows.Forms.Button();
            this.Solde_Am = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Retirer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Transactions = new System.Windows.Forms.DataGridView();
            this.Crediter = new System.Windows.Forms.Button();
            this.Amount = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a Compte";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Currency);
            this.groupBox2.Controls.Add(this.Verser);
            this.groupBox2.Controls.Add(this.Solde_Am);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Retirer);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Transactions);
            this.groupBox2.Controls.Add(this.Crediter);
            this.groupBox2.Controls.Add(this.Amount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(243, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 444);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Currency
            // 
            this.Currency.FormattingEnabled = true;
            this.Currency.Items.AddRange(new object[] {
            "MAD",
            "$",
            "Euro"});
            this.Currency.Location = new System.Drawing.Point(240, 140);
            this.Currency.Name = "Currency";
            this.Currency.Size = new System.Drawing.Size(59, 21);
            this.Currency.TabIndex = 11;
            // 
            // Verser
            // 
            this.Verser.Location = new System.Drawing.Point(107, 282);
            this.Verser.Name = "Verser";
            this.Verser.Size = new System.Drawing.Size(75, 23);
            this.Verser.TabIndex = 10;
            this.Verser.Text = "Verser";
            this.Verser.UseVisualStyleBackColor = true;
            this.Verser.Click += new System.EventHandler(this.Verser_Click);
            // 
            // Solde_Am
            // 
            this.Solde_Am.AutoSize = true;
            this.Solde_Am.Font = new System.Drawing.Font("DejaVu Serif Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solde_Am.Location = new System.Drawing.Point(81, 29);
            this.Solde_Am.Name = "Solde_Am";
            this.Solde_Am.Size = new System.Drawing.Size(0, 22);
            this.Solde_Am.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Solde :";
            // 
            // Retirer
            // 
            this.Retirer.Location = new System.Drawing.Point(107, 229);
            this.Retirer.Name = "Retirer";
            this.Retirer.Size = new System.Drawing.Size(75, 23);
            this.Retirer.TabIndex = 6;
            this.Retirer.Text = "Retirer";
            this.Retirer.UseVisualStyleBackColor = true;
            this.Retirer.Click += new System.EventHandler(this.Retirer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "All Transaction Made";
            // 
            // Transactions
            // 
            this.Transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Transactions.Location = new System.Drawing.Point(305, 50);
            this.Transactions.Name = "Transactions";
            this.Transactions.Size = new System.Drawing.Size(243, 385);
            this.Transactions.TabIndex = 4;
            // 
            // Crediter
            // 
            this.Crediter.Location = new System.Drawing.Point(107, 180);
            this.Crediter.Name = "Crediter";
            this.Crediter.Size = new System.Drawing.Size(75, 23);
            this.Crediter.TabIndex = 3;
            this.Crediter.Text = "Crediter";
            this.Crediter.UseVisualStyleBackColor = true;
            this.Crediter.Click += new System.EventHandler(this.Crediter_Click);
            // 
            // Amount
            // 
            this.Amount.Location = new System.Drawing.Point(6, 141);
            this.Amount.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(228, 20);
            this.Amount.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Internal_App_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Internal_App_Client";
            this.Text = "Internal_App_Client";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Crediter;
        private System.Windows.Forms.NumericUpDown Amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Transactions;
        private System.Windows.Forms.Button Retirer;
        private System.Windows.Forms.Label Solde_Am;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Verser;
        private System.Windows.Forms.Timer timer1;
        private ComboBox Currency;
    }
}