namespace UI.Views.Data
{
    partial class CustomersDataView
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.firstNameControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.lastNameControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.dateOfBirthControl = new UI.UserControls.UCVerticalDateTimePickerGroup();
            this.umcnControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.phoneControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.alert = new UI.UserControls.UCAlert();
            this.panelAlertContainer1 = new UI.UserControls.PanelAlertContainer();
            this.panelForm = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panelAlertContainer1.SuspendLayout();
            this.panelForm.SuspendLayout();
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
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer.Panel2.Controls.Add(this.panelForm);
            this.splitContainer.Panel2.Controls.Add(this.panelAlertContainer1);
            this.splitContainer.Size = new System.Drawing.Size(583, 502);
            this.splitContainer.SplitterDistance = 274;
            this.splitContainer.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancle, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNew, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 122);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 44);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancle.Location = new System.Drawing.Point(456, 10);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(106, 23);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "Otkaži";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Location = new System.Drawing.Point(309, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Obriši";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.Location = new System.Drawing.Point(19, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(106, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Registruj korisnika";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.Location = new System.Drawing.Point(164, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Ažuriraj";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // firstNameControl
            // 
            this.firstNameControl.InputText = "";
            this.firstNameControl.LabelText = "Ime";
            this.firstNameControl.Location = new System.Drawing.Point(3, 3);
            this.firstNameControl.Name = "firstNameControl";
            this.firstNameControl.Size = new System.Drawing.Size(188, 53);
            this.firstNameControl.TabIndex = 1;
            // 
            // lastNameControl
            // 
            this.lastNameControl.InputText = "";
            this.lastNameControl.LabelText = "Prezime";
            this.lastNameControl.Location = new System.Drawing.Point(197, 3);
            this.lastNameControl.Name = "lastNameControl";
            this.lastNameControl.Size = new System.Drawing.Size(188, 53);
            this.lastNameControl.TabIndex = 2;
            // 
            // dateOfBirthControl
            // 
            this.dateOfBirthControl.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.dateOfBirthControl.LabelText = "Datum rodjenja";
            this.dateOfBirthControl.Location = new System.Drawing.Point(391, 3);
            this.dateOfBirthControl.Name = "dateOfBirthControl";
            this.dateOfBirthControl.Size = new System.Drawing.Size(186, 53);
            this.dateOfBirthControl.TabIndex = 3;
            // 
            // umcnControl
            // 
            this.umcnControl.InputText = "";
            this.umcnControl.LabelText = "JMBG";
            this.umcnControl.Location = new System.Drawing.Point(3, 64);
            this.umcnControl.Name = "umcnControl";
            this.umcnControl.Size = new System.Drawing.Size(188, 53);
            this.umcnControl.TabIndex = 4;
            // 
            // phoneControl
            // 
            this.phoneControl.InputText = "";
            this.phoneControl.LabelText = "Broj telefona";
            this.phoneControl.Location = new System.Drawing.Point(197, 64);
            this.phoneControl.Name = "phoneControl";
            this.phoneControl.Size = new System.Drawing.Size(188, 53);
            this.phoneControl.TabIndex = 5;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // alert
            // 
            this.alert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alert.HideAutomaticaly = true;
            this.alert.Interval = 2500;
            this.alert.Location = new System.Drawing.Point(10, 10);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(563, 38);
            this.alert.TabIndex = 11;
            this.alert.Visible = false;
            // 
            // panelAlertContainer1
            // 
            this.panelAlertContainer1.Controls.Add(this.alert);
            this.panelAlertContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlertContainer1.Location = new System.Drawing.Point(0, 166);
            this.panelAlertContainer1.Name = "panelAlertContainer1";
            this.panelAlertContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.panelAlertContainer1.Size = new System.Drawing.Size(583, 58);
            this.panelAlertContainer1.TabIndex = 12;
            // 
            // panelForm
            // 
            this.panelForm.ColumnCount = 3;
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelForm.Controls.Add(this.dateOfBirthControl, 2, 0);
            this.panelForm.Controls.Add(this.firstNameControl, 0, 0);
            this.panelForm.Controls.Add(this.phoneControl, 1, 1);
            this.panelForm.Controls.Add(this.lastNameControl, 1, 0);
            this.panelForm.Controls.Add(this.umcnControl, 0, 1);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.RowCount = 2;
            this.panelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelForm.Size = new System.Drawing.Size(583, 122);
            this.panelForm.TabIndex = 13;
            // 
            // CustomersDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CustomersDataView";
            this.Size = new System.Drawing.Size(583, 502);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panelAlertContainer1.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private UserControls.UCVerticalTextBoxGroup firstNameControl;
        private UserControls.UCVerticalTextBoxGroup lastNameControl;
        private UserControls.UCVerticalDateTimePickerGroup dateOfBirthControl;
        private UserControls.UCVerticalTextBoxGroup umcnControl;
        private UserControls.UCVerticalTextBoxGroup phoneControl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private UserControls.UCAlert alert;
        private UserControls.PanelAlertContainer panelAlertContainer1;
        private System.Windows.Forms.TableLayoutPanel panelForm;
    }
}
