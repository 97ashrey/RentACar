namespace UI.Views.Statistics
{
    partial class StatisticsView
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
            this.gbLegend = new System.Windows.Forms.GroupBox();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.panelAlertContainer1 = new UI.UserControls.PanelAlertContainer();
            this.alert = new UI.UserControls.UCAlert();
            this.dtpControl = new UI.UserControls.UCHorizontalDateTimePickerGroup();
            this.panelAlertContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLegend
            // 
            this.gbLegend.Location = new System.Drawing.Point(13, 71);
            this.gbLegend.Name = "gbLegend";
            this.gbLegend.Size = new System.Drawing.Size(306, 327);
            this.gbLegend.TabIndex = 1;
            this.gbLegend.TabStop = false;
            this.gbLegend.Text = "Legenda";
            // 
            // panelCanvas
            // 
            this.panelCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanvas.Location = new System.Drawing.Point(325, 71);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(316, 327);
            this.panelCanvas.TabIndex = 2;
            // 
            // lblHeading
            // 
            this.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(287, 13);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(354, 55);
            this.lblHeading.TabIndex = 3;
            this.lblHeading.Text = "{{INCODE}}";
            // 
            // panelAlertContainer1
            // 
            this.panelAlertContainer1.Controls.Add(this.alert);
            this.panelAlertContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlertContainer1.Location = new System.Drawing.Point(0, 404);
            this.panelAlertContainer1.Name = "panelAlertContainer1";
            this.panelAlertContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.panelAlertContainer1.Size = new System.Drawing.Size(655, 69);
            this.panelAlertContainer1.TabIndex = 4;
            // 
            // alert
            // 
            this.alert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alert.HideAutomaticaly = true;
            this.alert.Interval = 2500;
            this.alert.Location = new System.Drawing.Point(10, 10);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(635, 49);
            this.alert.TabIndex = 0;
            this.alert.Visible = false;
            // 
            // dtpControl
            // 
            this.dtpControl.Date = new System.DateTime(2019, 5, 3, 15, 43, 28, 201);
            this.dtpControl.LabelText = "Izaberite mesec";
            this.dtpControl.Location = new System.Drawing.Point(13, 13);
            this.dtpControl.Name = "dtpControl";
            this.dtpControl.Size = new System.Drawing.Size(268, 25);
            this.dtpControl.TabIndex = 0;
            // 
            // StatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAlertContainer1);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.gbLegend);
            this.Controls.Add(this.dtpControl);
            this.Name = "StatisticsView";
            this.Size = new System.Drawing.Size(655, 473);
            this.panelAlertContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCHorizontalDateTimePickerGroup dtpControl;
        private System.Windows.Forms.GroupBox gbLegend;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblHeading;
        private UserControls.PanelAlertContainer panelAlertContainer1;
        private UserControls.UCAlert alert;
    }
}
