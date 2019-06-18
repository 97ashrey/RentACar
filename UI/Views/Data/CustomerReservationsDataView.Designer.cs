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
            this.panelAlertContainer = new System.Windows.Forms.Panel();
            this.alert = new UI.UserControls.UCAlert();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelCarInfoContainer.SuspendLayout();
            this.panelAlertContainer.SuspendLayout();
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
            this.splitContainer.Panel2.Controls.Add(this.panelAlertContainer);
            this.splitContainer.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer.Panel2.Controls.Add(this.panelCarInfoContainer);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer.Size = new System.Drawing.Size(474, 464);
            this.splitContainer.SplitterDistance = 297;
            this.splitContainer.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.Location = new System.Drawing.Point(10, 60);
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
            // panelAlertContainer
            // 
            this.panelAlertContainer.Controls.Add(this.alert);
            this.panelAlertContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAlertContainer.Location = new System.Drawing.Point(10, 105);
            this.panelAlertContainer.Name = "panelAlertContainer";
            this.panelAlertContainer.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelAlertContainer.Size = new System.Drawing.Size(454, 48);
            this.panelAlertContainer.TabIndex = 2;
            // 
            // alert
            // 
            this.alert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alert.HideAutomaticaly = true;
            this.alert.Interval = 2500;
            this.alert.Location = new System.Drawing.Point(0, 10);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(454, 38);
            this.alert.TabIndex = 0;
            this.alert.Visible = false;
            // 
            // CustomerReservationsDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splitContainer);
            this.Name = "CustomerReservationsDataView";
            this.Size = new System.Drawing.Size(474, 464);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelCarInfoContainer.ResumeLayout(false);
            this.panelAlertContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panelCarInfoContainer;
        private System.Windows.Forms.Label lblCarInfo;
        private System.Windows.Forms.Panel panelAlertContainer;
        private UserControls.UCAlert alert;
    }
}
