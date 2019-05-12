namespace UI.Views.Login
{
    partial class LoginView
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
            this.components = new System.ComponentModel.Container();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblNoAccount = new System.Windows.Forms.Label();
            this.panelAlertContainer = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkNoAccount = new System.Windows.Forms.LinkLabel();
            this.alert = new UI.UserControls.UCAlert();
            this.passwordControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.usernameControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.panelAlertContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Location = new System.Drawing.Point(13, 196);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(286, 32);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Ulogujte se";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblNoAccount
            // 
            this.lblNoAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoAccount.Location = new System.Drawing.Point(12, 244);
            this.lblNoAccount.Name = "lblNoAccount";
            this.lblNoAccount.Size = new System.Drawing.Size(287, 26);
            this.lblNoAccount.TabIndex = 3;
            this.lblNoAccount.Text = "Nemate nalog?";
            this.lblNoAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAlertContainer
            // 
            this.panelAlertContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAlertContainer.Controls.Add(this.alert);
            this.panelAlertContainer.Location = new System.Drawing.Point(15, 13);
            this.panelAlertContainer.Name = "panelAlertContainer";
            this.panelAlertContainer.Size = new System.Drawing.Size(284, 54);
            this.panelAlertContainer.TabIndex = 5;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // linkNoAccount
            // 
            this.linkNoAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkNoAccount.Location = new System.Drawing.Point(12, 270);
            this.linkNoAccount.Name = "linkNoAccount";
            this.linkNoAccount.Size = new System.Drawing.Size(287, 23);
            this.linkNoAccount.TabIndex = 6;
            this.linkNoAccount.TabStop = true;
            this.linkNoAccount.Text = "Registrujte se";
            this.linkNoAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkNoAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNoAccount_LinkClicked);
            // 
            // alert
            // 
            this.alert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alert.HideAutomaticaly = true;
            this.alert.Interval = 2500;
            this.alert.Location = new System.Drawing.Point(0, 0);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(284, 54);
            this.alert.TabIndex = 0;
            this.alert.Visible = false;
            // 
            // passwordControl
            // 
            this.passwordControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordControl.InputText = "";
            this.passwordControl.LabelText = "Lozinka";
            this.passwordControl.Location = new System.Drawing.Point(13, 130);
            this.passwordControl.Name = "passwordControl";
            this.passwordControl.Size = new System.Drawing.Size(286, 51);
            this.passwordControl.TabIndex = 1;
            // 
            // usernameControl
            // 
            this.usernameControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameControl.InputText = "";
            this.usernameControl.LabelText = "Korisničko ime";
            this.usernameControl.Location = new System.Drawing.Point(12, 73);
            this.usernameControl.Name = "usernameControl";
            this.usernameControl.Size = new System.Drawing.Size(287, 51);
            this.usernameControl.TabIndex = 0;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 302);
            this.Controls.Add(this.linkNoAccount);
            this.Controls.Add(this.panelAlertContainer);
            this.Controls.Add(this.lblNoAccount);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.passwordControl);
            this.Controls.Add(this.usernameControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.Text = "Rent a car - Logovanje";
            this.panelAlertContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCVerticalTextBoxGroup usernameControl;
        private UserControls.UCVerticalTextBoxGroup passwordControl;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblNoAccount;
        private System.Windows.Forms.Panel panelAlertContainer;
        private UserControls.UCAlert alert;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel linkNoAccount;
    }
}