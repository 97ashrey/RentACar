namespace UI.Views.Data
{
    partial class OffersDataView
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
            this.panelForm = new System.Windows.Forms.Panel();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.dateToControl = new UI.UserControls.UCVerticalDateTimePickerGroup();
            this.dateFromControl = new UI.UserControls.UCVerticalDateTimePickerGroup();
            this.pricePerDayControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.tlpCar = new System.Windows.Forms.TableLayoutPanel();
            this.carControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.lblCarInfo = new System.Windows.Forms.Label();
            this.panelAlertContainer1 = new UI.UserControls.PanelAlertContainer();
            this.alert = new UI.UserControls.UCAlert();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpCar.SuspendLayout();
            this.panelAlertContainer1.SuspendLayout();
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
            this.splitContainer.Panel2.Controls.Add(this.panelForm);
            this.splitContainer.Panel2.Controls.Add(this.panelAlertContainer1);
            this.splitContainer.Size = new System.Drawing.Size(549, 494);
            this.splitContainer.SplitterDistance = 256;
            this.splitContainer.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.tlpForm);
            this.panelForm.Controls.Add(this.tlpButtons);
            this.panelForm.Controls.Add(this.tlpCar);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(549, 176);
            this.panelForm.TabIndex = 1;
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 3;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpForm.Controls.Add(this.dateToControl, 1, 0);
            this.tlpForm.Controls.Add(this.dateFromControl, 0, 0);
            this.tlpForm.Controls.Add(this.pricePerDayControl, 2, 0);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 56);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 1;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Size = new System.Drawing.Size(549, 66);
            this.tlpForm.TabIndex = 3;
            // 
            // dateToControl
            // 
            this.dateToControl.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.dateToControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateToControl.LabelText = "Datum do";
            this.dateToControl.Location = new System.Drawing.Point(186, 3);
            this.dateToControl.Name = "dateToControl";
            this.dateToControl.Size = new System.Drawing.Size(177, 60);
            this.dateToControl.TabIndex = 1;
            // 
            // dateFromControl
            // 
            this.dateFromControl.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.dateFromControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromControl.LabelText = "Datum od";
            this.dateFromControl.Location = new System.Drawing.Point(3, 3);
            this.dateFromControl.Name = "dateFromControl";
            this.dateFromControl.Size = new System.Drawing.Size(177, 60);
            this.dateFromControl.TabIndex = 0;
            // 
            // pricePerDayControl
            // 
            this.pricePerDayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pricePerDayControl.InputText = "";
            this.pricePerDayControl.LabelText = "Cena po danu";
            this.pricePerDayControl.Location = new System.Drawing.Point(369, 3);
            this.pricePerDayControl.Name = "pricePerDayControl";
            this.pricePerDayControl.Size = new System.Drawing.Size(177, 60);
            this.pricePerDayControl.TabIndex = 2;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 5;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.Controls.Add(this.btnCancle, 4, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 3, 0);
            this.tlpButtons.Controls.Add(this.btnUpdate, 2, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 1, 0);
            this.tlpButtons.Controls.Add(this.btnNew, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(0, 122);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(549, 54);
            this.tlpButtons.TabIndex = 4;
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancle.Location = new System.Drawing.Point(439, 15);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(107, 23);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "Otkaži";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.Location = new System.Drawing.Point(330, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Obriši";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.Location = new System.Drawing.Point(221, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(103, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Ažuriraj";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(112, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.Location = new System.Drawing.Point(3, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(103, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Dodaj novu";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tlpCar
            // 
            this.tlpCar.ColumnCount = 2;
            this.tlpCar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.23679F));
            this.tlpCar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.76321F));
            this.tlpCar.Controls.Add(this.carControl, 0, 0);
            this.tlpCar.Controls.Add(this.lblCarInfo, 1, 0);
            this.tlpCar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCar.Location = new System.Drawing.Point(0, 0);
            this.tlpCar.Name = "tlpCar";
            this.tlpCar.RowCount = 1;
            this.tlpCar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCar.Size = new System.Drawing.Size(549, 56);
            this.tlpCar.TabIndex = 2;
            // 
            // carControl
            // 
            this.carControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carControl.LabelText = "Automobil";
            this.carControl.Location = new System.Drawing.Point(3, 3);
            this.carControl.Name = "carControl";
            this.carControl.SelectedItem = null;
            this.carControl.Size = new System.Drawing.Size(159, 50);
            this.carControl.TabIndex = 0;
            // 
            // lblCarInfo
            // 
            this.lblCarInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCarInfo.Location = new System.Drawing.Point(168, 0);
            this.lblCarInfo.Name = "lblCarInfo";
            this.lblCarInfo.Size = new System.Drawing.Size(378, 56);
            this.lblCarInfo.TabIndex = 1;
            this.lblCarInfo.Text = "{{IN Code}}";
            this.lblCarInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAlertContainer1
            // 
            this.panelAlertContainer1.Controls.Add(this.alert);
            this.panelAlertContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlertContainer1.Location = new System.Drawing.Point(0, 176);
            this.panelAlertContainer1.Name = "panelAlertContainer1";
            this.panelAlertContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.panelAlertContainer1.Size = new System.Drawing.Size(549, 58);
            this.panelAlertContainer1.TabIndex = 0;
            // 
            // alert
            // 
            this.alert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alert.HideAutomaticaly = true;
            this.alert.Interval = 2500;
            this.alert.Location = new System.Drawing.Point(10, 10);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(529, 38);
            this.alert.TabIndex = 0;
            this.alert.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // OffersDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "OffersDataView";
            this.Size = new System.Drawing.Size(549, 494);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.tlpForm.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tlpCar.ResumeLayout(false);
            this.panelAlertContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private UserControls.UCVerticalDateTimePickerGroup dateToControl;
        private UserControls.UCVerticalDateTimePickerGroup dateFromControl;
        private UserControls.UCVerticalTextBoxGroup pricePerDayControl;
        private System.Windows.Forms.TableLayoutPanel tlpCar;
        private UserControls.UCVerticalComboBoxGroup carControl;
        private System.Windows.Forms.Label lblCarInfo;
        private UserControls.PanelAlertContainer panelAlertContainer1;
        private UserControls.UCAlert alert;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
