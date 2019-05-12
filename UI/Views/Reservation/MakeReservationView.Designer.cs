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
            this.ucCollapse = new UI.UserControls.UCCollapse();
            this.panelCarSelect = new System.Windows.Forms.Panel();
            this.panelMakeReservation = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ucCollapse
            // 
            this.ucCollapse.BackColor = System.Drawing.SystemColors.Control;
            this.ucCollapse.Collapsed = true;
            // 
            // ucCollapse.ContentPanel
            // 
            this.ucCollapse.Content.BackColor = System.Drawing.Color.White;
            this.ucCollapse.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCollapse.Content.Enabled = true;
            this.ucCollapse.Content.Location = new System.Drawing.Point(1, 0);
            this.ucCollapse.Content.Name = "ContentPanel";
            this.ucCollapse.Content.Size = new System.Drawing.Size(526, 260);
            this.ucCollapse.Content.TabIndex = 0;
            this.ucCollapse.Content.Visible = true;
            this.ucCollapse.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucCollapse.Heading = "Filter";
            this.ucCollapse.Location = new System.Drawing.Point(0, 0);
            this.ucCollapse.Name = "ucCollapse";
            this.ucCollapse.Size = new System.Drawing.Size(538, 292);
            this.ucCollapse.TabIndex = 0;
            // 
            // panelCarSelect
            // 
            this.panelCarSelect.BackColor = System.Drawing.SystemColors.Control;
            this.panelCarSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCarSelect.Location = new System.Drawing.Point(0, 292);
            this.panelCarSelect.Name = "panelCarSelect";
            this.panelCarSelect.Padding = new System.Windows.Forms.Padding(5);
            this.panelCarSelect.Size = new System.Drawing.Size(538, 86);
            this.panelCarSelect.TabIndex = 1;
            // 
            // panelMakeReservation
            // 
            this.panelMakeReservation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMakeReservation.Location = new System.Drawing.Point(0, 378);
            this.panelMakeReservation.Name = "panelMakeReservation";
            this.panelMakeReservation.Size = new System.Drawing.Size(538, 301);
            this.panelMakeReservation.TabIndex = 2;
            // 
            // MakeReservationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelMakeReservation);
            this.Controls.Add(this.panelCarSelect);
            this.Controls.Add(this.ucCollapse);
            this.Name = "MakeReservationView";
            this.Size = new System.Drawing.Size(538, 650);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCCollapse ucCollapse;
        private System.Windows.Forms.Panel panelCarSelect;
        private System.Windows.Forms.Panel panelMakeReservation;
    }
}
