namespace UI.Views.Login
{
    partial class RegisterView
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
            this.panelAlertContainer = new System.Windows.Forms.Panel();
            this.alert = new UI.UserControls.UCAlert();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dateOfBirthControl = new UI.UserControls.UCHorizontalDateTimePickerGroup();
            this.phoneControl = new UI.UserControls.UCHorizontalTextBoxGroup();
            this.umcnControl = new UI.UserControls.UCHorizontalTextBoxGroup();
            this.lastNameControl = new UI.UserControls.UCHorizontalTextBoxGroup();
            this.firstNameControl = new UI.UserControls.UCHorizontalTextBoxGroup();
            this.passwordControl = new UI.UserControls.UCHorizontalTextBoxGroup();
            this.usernameControl = new UI.UserControls.UCHorizontalTextBoxGroup();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelAlertContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAlertContainer
            // 
            this.panelAlertContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAlertContainer.Controls.Add(this.alert);
            this.panelAlertContainer.Location = new System.Drawing.Point(12, 13);
            this.panelAlertContainer.Name = "panelAlertContainer";
            this.panelAlertContainer.Size = new System.Drawing.Size(268, 52);
            this.panelAlertContainer.TabIndex = 6;
            // 
            // alert
            // 
            this.alert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alert.HideAutomaticaly = true;
            this.alert.Interval = 2500;
            this.alert.Location = new System.Drawing.Point(0, 0);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(268, 52);
            this.alert.TabIndex = 0;
            this.alert.Visible = false;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.Location = new System.Drawing.Point(14, 303);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(267, 31);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Registrujte se";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // dateOfBirthControl
            // 
            this.dateOfBirthControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateOfBirthControl.Date = new System.DateTime(2019, 4, 27, 0, 39, 44, 806);
            this.dateOfBirthControl.LabelText = "Datum rođenja";
            this.dateOfBirthControl.Location = new System.Drawing.Point(14, 273);
            this.dateOfBirthControl.Name = "dateOfBirthControl";
            this.dateOfBirthControl.Size = new System.Drawing.Size(266, 27);
            this.dateOfBirthControl.TabIndex = 6;
            // 
            // phoneControl
            // 
            this.phoneControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneControl.InputText = "";
            this.phoneControl.LabelText = "Broj telefona";
            this.phoneControl.Location = new System.Drawing.Point(12, 242);
            this.phoneControl.Name = "phoneControl";
            this.phoneControl.Size = new System.Drawing.Size(268, 25);
            this.phoneControl.TabIndex = 5;
            // 
            // umcnControl
            // 
            this.umcnControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.umcnControl.InputText = "";
            this.umcnControl.LabelText = "JMBG";
            this.umcnControl.Location = new System.Drawing.Point(12, 211);
            this.umcnControl.Name = "umcnControl";
            this.umcnControl.Size = new System.Drawing.Size(268, 25);
            this.umcnControl.TabIndex = 4;
            // 
            // lastNameControl
            // 
            this.lastNameControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameControl.InputText = "";
            this.lastNameControl.LabelText = "Prezime";
            this.lastNameControl.Location = new System.Drawing.Point(12, 180);
            this.lastNameControl.Name = "lastNameControl";
            this.lastNameControl.Size = new System.Drawing.Size(268, 25);
            this.lastNameControl.TabIndex = 3;
            // 
            // firstNameControl
            // 
            this.firstNameControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameControl.InputText = "";
            this.firstNameControl.LabelText = "Ime";
            this.firstNameControl.Location = new System.Drawing.Point(12, 146);
            this.firstNameControl.Name = "firstNameControl";
            this.firstNameControl.Size = new System.Drawing.Size(268, 25);
            this.firstNameControl.TabIndex = 2;
            // 
            // passwordControl
            // 
            this.passwordControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordControl.InputText = "";
            this.passwordControl.LabelText = "Lozinka";
            this.passwordControl.Location = new System.Drawing.Point(12, 115);
            this.passwordControl.Name = "passwordControl";
            this.passwordControl.Size = new System.Drawing.Size(268, 25);
            this.passwordControl.TabIndex = 1;
            // 
            // usernameControl
            // 
            this.usernameControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameControl.InputText = "";
            this.usernameControl.LabelText = "Korisničko ime";
            this.usernameControl.Location = new System.Drawing.Point(12, 83);
            this.usernameControl.Name = "usernameControl";
            this.usernameControl.Size = new System.Drawing.Size(268, 26);
            this.usernameControl.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // RegisterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 343);
            this.Controls.Add(this.dateOfBirthControl);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.panelAlertContainer);
            this.Controls.Add(this.phoneControl);
            this.Controls.Add(this.umcnControl);
            this.Controls.Add(this.lastNameControl);
            this.Controls.Add(this.firstNameControl);
            this.Controls.Add(this.passwordControl);
            this.Controls.Add(this.usernameControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterView";
            this.Text = "RegisterView";
            this.panelAlertContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCHorizontalTextBoxGroup usernameControl;
        private UserControls.UCHorizontalTextBoxGroup passwordControl;
        private UserControls.UCHorizontalTextBoxGroup firstNameControl;
        private UserControls.UCHorizontalTextBoxGroup lastNameControl;
        private UserControls.UCHorizontalTextBoxGroup umcnControl;
        private UserControls.UCHorizontalTextBoxGroup phoneControl;
        private System.Windows.Forms.Panel panelAlertContainer;
        private UserControls.UCAlert alert;
        private System.Windows.Forms.Button btnRegister;
        private UserControls.UCHorizontalDateTimePickerGroup dateOfBirthControl;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}