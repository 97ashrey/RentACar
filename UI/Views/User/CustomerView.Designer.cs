namespace UI.Views.User
{
    partial class CustomerView
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnMakeReservation = new System.Windows.Forms.Button();
            this.panelSide.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.Controls.Add(this.flowLayoutPanel1);
            this.panelSide.Size = new System.Drawing.Size(170, 518);
            this.panelSide.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(630, 518);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnReservations);
            this.flowLayoutPanel1.Controls.Add(this.btnMakeReservation);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 90);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(170, 428);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnReservations
            // 
            this.btnReservations.Location = new System.Drawing.Point(13, 13);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(131, 35);
            this.btnReservations.TabIndex = 0;
            this.btnReservations.Text = "Rezervacije";
            this.btnReservations.UseVisualStyleBackColor = true;
            // 
            // btnMakeReservation
            // 
            this.btnMakeReservation.Location = new System.Drawing.Point(13, 54);
            this.btnMakeReservation.Name = "btnMakeReservation";
            this.btnMakeReservation.Size = new System.Drawing.Size(131, 35);
            this.btnMakeReservation.TabIndex = 1;
            this.btnMakeReservation.Text = "Rezervišite";
            this.btnMakeReservation.UseVisualStyleBackColor = true;
            // 
            // CustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Name = "CustomerView";
            this.Text = "CustomerView";
            this.panelSide.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnMakeReservation;
    }
}