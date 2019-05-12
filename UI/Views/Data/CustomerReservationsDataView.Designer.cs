namespace UI.Views.Data
{
    partial class CustomerReservationsDataView
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelCarInfoContainer = new System.Windows.Forms.Panel();
            this.lblCarInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelCarInfoContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer.Panel2.Controls.Add(this.panelCarInfoContainer);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer.Size = new System.Drawing.Size(474, 405);
            this.splitContainer.SplitterDistance = 260;
            this.splitContainer.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(10, 86);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(454, 45);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Ukinite rezervaciju";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // panelCarInfoContainer
            // 
            this.panelCarInfoContainer.Controls.Add(this.lblCarInfo);
            this.panelCarInfoContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCarInfoContainer.Location = new System.Drawing.Point(10, 10);
            this.panelCarInfoContainer.Name = "panelCarInfoContainer";
            this.panelCarInfoContainer.Size = new System.Drawing.Size(454, 50);
            this.panelCarInfoContainer.TabIndex = 1;
            // 
            // lblCarInfo
            // 
            this.lblCarInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCarInfo.Location = new System.Drawing.Point(0, 0);
            this.lblCarInfo.Name = "lblCarInfo";
            this.lblCarInfo.Size = new System.Drawing.Size(454, 50);
            this.lblCarInfo.TabIndex = 0;
            this.lblCarInfo.Text = "{{INCODE}}";
            this.lblCarInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CustomerReservationsDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CustomerReservationsDataView";
            this.Size = new System.Drawing.Size(474, 405);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelCarInfoContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panelCarInfoContainer;
        private System.Windows.Forms.Label lblCarInfo;
    }
}
