namespace UI.Views.Data
{
    partial class CarsDataView
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
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.shiftTypeControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.driveTypeControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.fuelTypeControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.brandControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.modelControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.createdYearControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.carBodyControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.dorCountControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.cubicCapacityControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelAlertContainer1.SuspendLayout();
            this.tlpForm.SuspendLayout();
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
            this.splitContainer.Panel2.Controls.Add(this.tlpForm);
            this.splitContainer.Size = new System.Drawing.Size(578, 484);
            this.splitContainer.SplitterDistance = 195;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 184);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 43);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancle.Location = new System.Drawing.Point(464, 10);
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
            this.btnDelete.Location = new System.Drawing.Point(348, 10);
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
            this.btnUpdate.Location = new System.Drawing.Point(233, 10);
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
            this.btnSave.Location = new System.Drawing.Point(118, 10);
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
            this.btnNew.Location = new System.Drawing.Point(3, 10);
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
            this.panelAlertContainer1.Location = new System.Drawing.Point(0, 227);
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
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 3;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpForm.Controls.Add(this.shiftTypeControl, 2, 2);
            this.tlpForm.Controls.Add(this.driveTypeControl, 2, 1);
            this.tlpForm.Controls.Add(this.fuelTypeControl, 2, 0);
            this.tlpForm.Controls.Add(this.brandControl, 0, 0);
            this.tlpForm.Controls.Add(this.modelControl, 0, 1);
            this.tlpForm.Controls.Add(this.createdYearControl, 0, 2);
            this.tlpForm.Controls.Add(this.carBodyControl, 1, 1);
            this.tlpForm.Controls.Add(this.dorCountControl, 1, 2);
            this.tlpForm.Controls.Add(this.cubicCapacityControl, 1, 0);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 3;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpForm.Size = new System.Drawing.Size(578, 184);
            this.tlpForm.TabIndex = 0;
            // 
            // shiftTypeControl
            // 
            this.shiftTypeControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shiftTypeControl.LabelText = "Menjač";
            this.shiftTypeControl.Location = new System.Drawing.Point(387, 125);
            this.shiftTypeControl.Name = "shiftTypeControl";
            this.shiftTypeControl.SelectedItem = null;
            this.shiftTypeControl.Size = new System.Drawing.Size(188, 56);
            this.shiftTypeControl.TabIndex = 8;
            // 
            // driveTypeControl
            // 
            this.driveTypeControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveTypeControl.LabelText = "Pogon";
            this.driveTypeControl.Location = new System.Drawing.Point(387, 64);
            this.driveTypeControl.Name = "driveTypeControl";
            this.driveTypeControl.SelectedItem = null;
            this.driveTypeControl.Size = new System.Drawing.Size(188, 55);
            this.driveTypeControl.TabIndex = 7;
            // 
            // fuelTypeControl
            // 
            this.fuelTypeControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fuelTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fuelTypeControl.LabelText = "Gorivo";
            this.fuelTypeControl.Location = new System.Drawing.Point(387, 3);
            this.fuelTypeControl.Name = "fuelTypeControl";
            this.fuelTypeControl.SelectedItem = null;
            this.fuelTypeControl.Size = new System.Drawing.Size(188, 55);
            this.fuelTypeControl.TabIndex = 6;
            // 
            // brandControl
            // 
            this.brandControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brandControl.InputText = "";
            this.brandControl.LabelText = "Marka";
            this.brandControl.Location = new System.Drawing.Point(3, 3);
            this.brandControl.Name = "brandControl";
            this.brandControl.Size = new System.Drawing.Size(186, 55);
            this.brandControl.TabIndex = 0;
            // 
            // modelControl
            // 
            this.modelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelControl.InputText = "";
            this.modelControl.LabelText = "Model";
            this.modelControl.Location = new System.Drawing.Point(3, 64);
            this.modelControl.Name = "modelControl";
            this.modelControl.Size = new System.Drawing.Size(186, 55);
            this.modelControl.TabIndex = 1;
            // 
            // createdYearControl
            // 
            this.createdYearControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createdYearControl.InputText = "";
            this.createdYearControl.LabelText = "Godište";
            this.createdYearControl.Location = new System.Drawing.Point(3, 125);
            this.createdYearControl.Name = "createdYearControl";
            this.createdYearControl.Size = new System.Drawing.Size(186, 56);
            this.createdYearControl.TabIndex = 2;
            // 
            // carBodyControl
            // 
            this.carBodyControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carBodyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carBodyControl.LabelText = "Karoserija";
            this.carBodyControl.Location = new System.Drawing.Point(195, 64);
            this.carBodyControl.Name = "carBodyControl";
            this.carBodyControl.SelectedItem = null;
            this.carBodyControl.Size = new System.Drawing.Size(186, 55);
            this.carBodyControl.TabIndex = 4;
            // 
            // dorCountControl
            // 
            this.dorCountControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dorCountControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dorCountControl.LabelText = "Broj vrata";
            this.dorCountControl.Location = new System.Drawing.Point(195, 125);
            this.dorCountControl.Name = "dorCountControl";
            this.dorCountControl.SelectedItem = null;
            this.dorCountControl.Size = new System.Drawing.Size(186, 56);
            this.dorCountControl.TabIndex = 5;
            // 
            // cubicCapacityControl
            // 
            this.cubicCapacityControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubicCapacityControl.InputText = "";
            this.cubicCapacityControl.LabelText = "Kubikaža";
            this.cubicCapacityControl.Location = new System.Drawing.Point(195, 3);
            this.cubicCapacityControl.Name = "cubicCapacityControl";
            this.cubicCapacityControl.Size = new System.Drawing.Size(186, 55);
            this.cubicCapacityControl.TabIndex = 3;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // CarsDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CarsDataView";
            this.Size = new System.Drawing.Size(578, 484);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelAlertContainer1.ResumeLayout(false);
            this.tlpForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private UserControls.PanelAlertContainer panelAlertContainer1;
        private UserControls.UCAlert alert;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private UserControls.UCVerticalTextBoxGroup brandControl;
        private UserControls.UCVerticalTextBoxGroup modelControl;
        private UserControls.UCVerticalTextBoxGroup createdYearControl;
        private UserControls.UCVerticalComboBoxGroup shiftTypeControl;
        private UserControls.UCVerticalComboBoxGroup driveTypeControl;
        private UserControls.UCVerticalComboBoxGroup fuelTypeControl;
        private UserControls.UCVerticalComboBoxGroup carBodyControl;
        private UserControls.UCVerticalComboBoxGroup dorCountControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private UserControls.UCVerticalTextBoxGroup cubicCapacityControl;
    }
}
