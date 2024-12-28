namespace TestCredentialProvider.Forms
{
    partial class FrmTest
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
            this.BtnPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPass
            // 
            this.BtnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPass.Location = new System.Drawing.Point(149, 79);
            this.BtnPass.Name = "BtnPass";
            this.BtnPass.Size = new System.Drawing.Size(336, 152);
            this.BtnPass.TabIndex = 0;
            this.BtnPass.Text = "DEVAM ET";
            this.BtnPass.UseVisualStyleBackColor = true;
            this.BtnPass.Click += new System.EventHandler(this.BtnPass_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 311);
            this.Controls.Add(this.BtnPass);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 350);
            this.Name = "FrmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPass;
    }
}