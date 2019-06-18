namespace UI.Views.Reservation
{
    partial class MakeReservationView
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
            this.panelCarSelect = new System.Windows.Forms.Panel();
            this.panelMakeReservation = new System.Windows.Forms.Panel();
            this.ucCollapse = new UI.UserControls.UCCollapse();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelAlertContainer1 = new UI.UserControls.PanelAlertContainer();
            this.ucAlert = new UI.UserControls.UCAlert();
            this.panelMain.SuspendLayout();
            this.panelAlertContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCarSelect
            // 
            this.panelCarSelect.AutoSize = true;
            this.panelCarSelect.BackColor = System.Drawing.SystemColors.Control;
            this.panelCarSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCarSelect.Location = new System.Drawing.Point(0, 29);
            this.panelCarSelect.Name = "panelCarSelect";
            this.panelCarSelect.Padding = new System.Windows.Forms.Padding(5);
            this.panelCarSelect.Size = new System.Drawing.Size(521, 10);
            this.panelCarSelect.TabIndex = 1;
            // 
            // panelMakeReservation
            // 
            this.panelMakeReservation.AutoSize = true;
            this.panelMakeReservation.BackColor = System.Drawing.SystemColors.Control;
            this.panelMakeReservation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMakeReservation.Location = new System.Drawing.Point(0, 39);
            this.panelMakeReservation.Name = "panelMakeReservation";
            this.panelMakeReservation.Size = new System.Drawing.Size(521, 0);
            this.panelMakeReservation.TabIndex = 2;
            // 
            // ucCollapse
            // 
            this.ucCollapse.BackColor = System.Drawing.SystemColors.Control;
            this.ucCollapse.Collapsed = true;
            this.ucCollapse.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucCollapse.Heading = "Filter";
            this.ucCollapse.Location = new System.Drawing.Point(0, 0);
            this.ucCollapse.Name = "ucCollapse";
            this.ucCollapse.Size = new System.Drawing.Size(521, 29);
            this.ucCollapse.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.panelMakeReservation);
            this.panelMain.Controls.Add(this.panelCarSelect);
            this.panelMain.Controls.Add(this.ucCollapse);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(521, 426);
            this.panelMain.TabIndex = 3;
            // 
            // panelAlertContainer1
            // 
            this.panelAlertContainer1.Controls.Add(this.ucAlert);
            this.panelAlertContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlertContainer1.Location = new System.Drawing.Point(0, 432);
            this.panelAlertContainer1.Name = "panelAlertContainer1";
            this.panelAlertContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.panelAlertContainer1.Size = new System.Drawing.Size(521, 64);
            this.panelAlertContainer1.TabIndex = 4;
            // 
            // ucAlert
            // 
            this.ucAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlert.HideAutomaticaly = true;
            this.ucAlert.Interval = 2500;
            this.ucAlert.Location = new System.Drawing.Point(10, 10);
            this.ucAlert.Name = "ucAlert";
            this.ucAlert.Size = new System.Drawing.Size(501, 44);
            this.ucAlert.TabIndex = 0;
            this.ucAlert.Visible = false;
            // 
            // MakeReservationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelAlertContainer1);
            this.Controls.Add(this.panelMain);
            this.Name = "MakeReservationView";
            this.Size = new System.Drawing.Size(521, 496);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelAlertContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCCollapse ucCollapse;
        private System.Windows.Forms.Panel panelCarSelect;
        private System.Windows.Forms.Panel panelMakeReservation;
        private System.Windows.Forms.Panel panelMain;
        private UserControls.PanelAlertContainer panelAlertContainer1;
        private UserControls.UCAlert ucAlert;
    }
}
