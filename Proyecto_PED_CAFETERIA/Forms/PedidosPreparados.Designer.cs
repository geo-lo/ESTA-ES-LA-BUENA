namespace Proyecto_PED_CAFETERIA.Forms
{
    partial class PedidosPreparados
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
            this.dgvPreparados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreparados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreparados
            // 
            this.dgvPreparados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreparados.Location = new System.Drawing.Point(25, 91);
            this.dgvPreparados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPreparados.Name = "dgvPreparados";
            this.dgvPreparados.RowHeadersWidth = 51;
            this.dgvPreparados.RowTemplate.Height = 24;
            this.dgvPreparados.Size = new System.Drawing.Size(670, 234);
            this.dgvPreparados.TabIndex = 0;
            this.dgvPreparados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreparados_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PedidosPreparados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPreparados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PedidosPreparados";
            this.Load += new System.EventHandler(this.PedidosPreparados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreparados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreparados;
        private System.Windows.Forms.Label label1;
    }
}