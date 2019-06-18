namespace UI.Views.User
{
    partial class AdminView
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
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnCars = new System.Windows.Forms.Button();
            this.btnOffers = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSide.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.Controls.Add(this.flpButtons);
            this.panelSide.Size = new System.Drawing.Size(158, 595);
            this.panelSide.Controls.SetChildIndex(this.flpButtons, 0);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(158, 0);
            this.panelMain.Size = new System.Drawing.Size(685, 595);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(13, 13);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(131, 35);
            this.btnCustomers.TabIndex = 0;
            this.btnCustomers.Text = "Korisnici";
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnCars
            // 
            this.btnCars.Location = new System.Drawing.Point(13, 54);
            this.btnCars.Name = "btnCars";
            this.btnCars.Size = new System.Drawing.Size(131, 35);
            this.btnCars.TabIndex = 1;
            this.btnCars.Text = "Automobili";
            this.btnCars.UseVisualStyleBackColor = true;
            // 
            // btnOffers
            // 
            this.btnOffers.Location = new System.Drawing.Point(13, 136);
            this.btnOffers.Name = "btnOffers";
            this.btnOffers.Size = new System.Drawing.Size(131, 35);
            this.btnOffers.TabIndex = 3;
            this.btnOffers.Text = "Ponude";
            this.btnOffers.UseVisualStyleBackColor = true;
            // 
            // btnReservations
            // 
            this.btnReservations.Location = new System.Drawing.Point(13, 95);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(131, 35);
            this.btnReservations.TabIndex = 2;
            this.btnReservations.Text = "Rezervacije";
            this.btnReservations.UseVisualStyleBackColor = true;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(13, 177);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(131, 35);
            this.btnStatistics.TabIndex = 4;
            this.btnStatistics.Text = "Statistika";
            this.btnStatistics.UseVisualStyleBackColor = true;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnCustomers);
            this.flpButtons.Controls.Add(this.btnCars);
            this.flpButtons.Controls.Add(this.btnReservations);
            this.flpButtons.Controls.Add(this.btnOffers);
            this.flpButtons.Controls.Add(this.btnStatistics);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpButtons.Location = new System.Drawing.Point(0, 90);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(10);
            this.flpButtons.Size = new System.Drawing.Size(158, 505);
            this.flpButtons.TabIndex = 1;
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 595);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminView";
            this.Text = "Rent a car - Admin";
            this.panelSide.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Button btnOffers;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
    }
}