namespace UI.UserControls
{
    partial class UCCollapse
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnToggle = new System.Windows.Forms.Button();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelContentBorder = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelBody.SuspendLayout();
            this.panelContentBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnToggle
            // 
            this.btnToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToggle.Image = global::UI.Properties.Resources.arrow_down;
            this.btnToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnToggle.Location = new System.Drawing.Point(0, 0);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(274, 31);
            this.btnToggle.TabIndex = 2;
            this.btnToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.panelContentBorder);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 31);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panelBody.Size = new System.Drawing.Size(274, 229);
            this.panelBody.TabIndex = 3;
            // 
            // panelContentBorder
            // 
            this.panelContentBorder.Controls.Add(this.panelContent);
            this.panelContentBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentBorder.Location = new System.Drawing.Point(5, 0);
            this.panelContentBorder.Name = "panelContentBorder";
            this.panelContentBorder.Size = new System.Drawing.Size(264, 229);
            this.panelContentBorder.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(264, 229);
            this.panelContent.TabIndex = 0;
            // 
            // UCCollapse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.btnToggle);
            this.Name = "UCCollapse";
            this.Size = new System.Drawing.Size(274, 260);
            this.Load += new System.EventHandler(this.UCCollapse_Load);
            this.panelBody.ResumeLayout(false);
            this.panelContentBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelContentBorder;
        private System.Windows.Forms.Panel panelContent;
    }
}
