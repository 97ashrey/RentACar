namespace UI.Views.Data
{
    partial class ReservationsDataView
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panelAlertContainer1 = new UI.UserControls.PanelAlertContainer();
            this.alert = new UI.UserControls.UCAlert();
            this.panelForm = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dateToControl = new UI.UserControls.UCVerticalDateTimePickerGroup();
            this.dateFromControl = new UI.UserControls.UCVerticalDateTimePickerGroup();
            this.priceControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.carControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.customerControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.lblCarInfo = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbPeriods = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelAlertContainer1.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.splitContainer.Panel2.Controls.Add(this.panelAlertContainer1);
            this.splitContainer.Panel2.Controls.Add(this.panelForm);
            this.splitContainer.Size = new System.Drawing.Size(578, 561);
            this.splitContainer.SplitterDistance = 216;
            this.splitContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancle, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNew, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 238);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 45);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancle.Location = new System.Drawing.Point(464, 11);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(110, 23);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "Otkaži";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Location = new System.Drawing.Point(348, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Obriši";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.Location = new System.Drawing.Point(233, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(109, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Ažuriraj";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(118, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.Location = new System.Drawing.Point(3, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(109, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Dodaj novi";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panelAlertContainer1
            // 
            this.panelAlertContainer1.Controls.Add(this.alert);
            this.panelAlertContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlertContainer1.Location = new System.Drawing.Point(0, 283);
            this.panelAlertContainer1.Name = "panelAlertContainer1";
            this.panelAlertContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.panelAlertContainer1.Size = new System.Drawing.Size(578, 58);
            this.panelAlertContainer1.TabIndex = 1;
            // 
            // alert
            // 
            this.alert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alert.HideAutomaticaly = true;
            this.alert.Interval = 2500;
            this.alert.Location = new System.Drawing.Point(10, 10);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(558, 38);
            this.alert.TabIndex = 0;
            this.alert.Visible = false;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.tableLayoutPanel3);
            this.panelForm.Controls.Add(this.lbPeriods);
            this.panelForm.Controls.Add(this.tableLayoutPanel2);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(578, 238);
            this.panelForm.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.dateToControl, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateFromControl, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.priceControl, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 176);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(578, 62);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dateToControl
            // 
            this.dateToControl.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.dateToControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateToControl.LabelText = "Datum do";
            this.dateToControl.Location = new System.Drawing.Point(195, 3);
            this.dateToControl.Name = "dateToControl";
            this.dateToControl.Size = new System.Drawing.Size(186, 56);
            this.dateToControl.TabIndex = 1;
            // 
            // dateFromControl
            // 
            this.dateFromControl.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.dateFromControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromControl.LabelText = "Datum od";
            this.dateFromControl.Location = new System.Drawing.Point(3, 3);
            this.dateFromControl.Name = "dateFromControl";
            this.dateFromControl.Size = new System.Drawing.Size(186, 56);
            this.dateFromControl.TabIndex = 0;
            // 
            // priceControl
            // 
            this.priceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceControl.InputText = "";
            this.priceControl.LabelText = "Cena";
            this.priceControl.Location = new System.Drawing.Point(387, 3);
            this.priceControl.Name = "priceControl";
            this.priceControl.Size = new System.Drawing.Size(188, 56);
            this.priceControl.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblCustomerInfo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.carControl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.customerControl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCarInfo, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(578, 94);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerInfo.Location = new System.Drawing.Point(292, 56);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(283, 38);
            this.lblCustomerInfo.TabIndex = 3;
            this.lblCustomerInfo.Text = "{{INCODE}}";
            this.lblCustomerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // carControl
            // 
            this.carControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.carControl.LabelText = "Automobil";
            this.carControl.Location = new System.Drawing.Point(3, 3);
            this.carControl.Name = "carControl";
            this.carControl.SelectedItem = null;
            this.carControl.Size = new System.Drawing.Size(185, 50);
            this.carControl.TabIndex = 0;
            // 
            // customerControl
            // 
            this.customerControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.customerControl.LabelText = "Kupac";
            this.customerControl.Location = new System.Drawing.Point(292, 3);
            this.customerControl.Name = "customerControl";
            this.customerControl.SelectedItem = null;
            this.customerControl.Size = new System.Drawing.Size(185, 50);
            this.customerControl.TabIndex = 1;
            // 
            // lblCarInfo
            // 
            this.lblCarInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCarInfo.Location = new System.Drawing.Point(3, 56);
            this.lblCarInfo.Name = "lblCarInfo";
            this.lblCarInfo.Size = new System.Drawing.Size(283, 38);
            this.lblCarInfo.TabIndex = 2;
            this.lblCarInfo.Text = "{{INCODE}}";
            this.lblCarInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // lbPeriods
            // 
            this.lbPeriods.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPeriods.FormattingEnabled = true;
            this.lbPeriods.Location = new System.Drawing.Point(0, 94);
            this.lbPeriods.Name = "lbPeriods";
            this.lbPeriods.Size = new System.Drawing.Size(578, 82);
            this.lbPeriods.TabIndex = 1;
            // 
            // ReservationsDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ReservationsDataView";
            this.Size = new System.Drawing.Size(578, 561);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelAlertContainer1.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private UserControls.PanelAlertContainer panelAlertContainer1;
        private UserControls.UCAlert alert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private UserControls.UCVerticalDateTimePickerGroup dateToControl;
        private UserControls.UCVerticalDateTimePickerGroup dateFromControl;
        private UserControls.UCVerticalTextBoxGroup priceControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCustomerInfo;
        private UserControls.UCVerticalComboBoxGroup carControl;
        private UserControls.UCVerticalComboBoxGroup customerControl;
        private System.Windows.Forms.Label lblCarInfo;
        private System.Windows.Forms.ListBox lbPeriods;
    }
}
