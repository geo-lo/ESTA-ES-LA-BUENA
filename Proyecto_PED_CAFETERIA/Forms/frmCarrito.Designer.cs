namespace Proyecto_PED_CAFETERIA.Forms
{
    partial class frmCarrito
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
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.flowCarrito = new System.Windows.Forms.FlowLayoutPanel();
            this.flowCarrito.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.Red;
            this.btnRegresar.Location = new System.Drawing.Point(577, 314);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(108, 44);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(4, 0);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 25);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total";
            // 
            // flowCarrito
            // 
            this.flowCarrito.AutoScroll = true;
            this.flowCarrito.Controls.Add(this.lblTotal);
            this.flowCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowCarrito.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowCarrito.Location = new System.Drawing.Point(0, 0);
            this.flowCarrito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowCarrito.Name = "flowCarrito";
            this.flowCarrito.Size = new System.Drawing.Size(726, 405);
            this.flowCarrito.TabIndex = 0;
            this.flowCarrito.WrapContents = false;
            this.flowCarrito.Paint += new System.Windows.Forms.PaintEventHandler(this.flowCarrito_Paint);
            // 
            // frmCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 405);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.flowCarrito);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCarrito";
            this.Text = "frmCarrito";
            this.Load += new System.EventHandler(this.frmCarrito_Load);
            this.flowCarrito.ResumeLayout(false);
            this.flowCarrito.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.FlowLayoutPanel flowCarrito;
    }
}