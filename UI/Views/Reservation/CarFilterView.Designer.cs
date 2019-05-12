namespace UI.Views.Reservation
{
    partial class CarFilterView
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
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.driveTypeControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.dorCountControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.modelControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.shiftTypeControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.fuelTypeControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.carBodyControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.brandControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.cubicCapacityToControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.cubicCapacityFromControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.createdYearToControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.createdYearFromControl = new UI.UserControls.UCVerticalComboBoxGroup();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelBtnContainer = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpForm.SuspendLayout();
            this.panelBtnContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 4;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpForm.Controls.Add(this.driveTypeControl, 2, 1);
            this.tlpForm.Controls.Add(this.dorCountControl, 1, 1);
            this.tlpForm.Controls.Add(this.modelControl, 0, 1);
            this.tlpForm.Controls.Add(this.shiftTypeControl, 3, 0);
            this.tlpForm.Controls.Add(this.fuelTypeControl, 2, 0);
            this.tlpForm.Controls.Add(this.carBodyControl, 1, 0);
            this.tlpForm.Controls.Add(this.brandControl, 0, 0);
            this.tlpForm.Controls.Add(this.cubicCapacityToControl, 3, 2);
            this.tlpForm.Controls.Add(this.cubicCapacityFromControl, 2, 2);
            this.tlpForm.Controls.Add(this.createdYearToControl, 1, 2);
            this.tlpForm.Controls.Add(this.createdYearFromControl, 0, 2);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 3;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpForm.Size = new System.Drawing.Size(521, 202);
            this.tlpForm.TabIndex = 0;
            // 
            // driveTypeControl
            // 
            this.driveTypeControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveTypeControl.LabelText = "Pogon:";
            this.driveTypeControl.Location = new System.Drawing.Point(263, 70);
            this.driveTypeControl.Name = "driveTypeControl";
            this.driveTypeControl.SelectedItem = null;
            this.driveTypeControl.Size = new System.Drawing.Size(124, 61);
            this.driveTypeControl.TabIndex = 10;
            // 
            // dorCountControl
            // 
            this.dorCountControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dorCountControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dorCountControl.LabelText = "Broj vrata:";
            this.dorCountControl.Location = new System.Drawing.Point(133, 70);
            this.dorCountControl.Name = "dorCountControl";
            this.dorCountControl.SelectedItem = null;
            this.dorCountControl.Size = new System.Drawing.Size(124, 61);
            this.dorCountControl.TabIndex = 9;
            // 
            // modelControl
            // 
            this.modelControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelControl.LabelText = "Model:";
            this.modelControl.Location = new System.Drawing.Point(3, 70);
            this.modelControl.Name = "modelControl";
            this.modelControl.SelectedItem = null;
            this.modelControl.Size = new System.Drawing.Size(124, 61);
            this.modelControl.TabIndex = 8;
            // 
            // shiftTypeControl
            // 
            this.shiftTypeControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shiftTypeControl.LabelText = "Menjač:";
            this.shiftTypeControl.Location = new System.Drawing.Point(393, 3);
            this.shiftTypeControl.Name = "shiftTypeControl";
            this.shiftTypeControl.SelectedItem = null;
            this.shiftTypeControl.Size = new System.Drawing.Size(125, 61);
            this.shiftTypeControl.TabIndex = 7;
            // 
            // fuelTypeControl
            // 
            this.fuelTypeControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fuelTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fuelTypeControl.LabelText = "Gorivo:";
            this.fuelTypeControl.Location = new System.Drawing.Point(263, 3);
            this.fuelTypeControl.Name = "fuelTypeControl";
            this.fuelTypeControl.SelectedItem = null;
            this.fuelTypeControl.Size = new System.Drawing.Size(124, 61);
            this.fuelTypeControl.TabIndex = 6;
            // 
            // carBodyControl
            // 
            this.carBodyControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carBodyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carBodyControl.LabelText = "Karoserija:";
            this.carBodyControl.Location = new System.Drawing.Point(133, 3);
            this.carBodyControl.Name = "carBodyControl";
            this.carBodyControl.SelectedItem = null;
            this.carBodyControl.Size = new System.Drawing.Size(124, 61);
            this.carBodyControl.TabIndex = 5;
            // 
            // brandControl
            // 
            this.brandControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brandControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brandControl.LabelText = "Marka:";
            this.brandControl.Location = new System.Drawing.Point(3, 3);
            this.brandControl.Name = "brandControl";
            this.brandControl.SelectedItem = null;
            this.brandControl.Size = new System.Drawing.Size(124, 61);
            this.brandControl.TabIndex = 0;
            // 
            // cubicCapacityToControl
            // 
            this.cubicCapacityToControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cubicCapacityToControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubicCapacityToControl.LabelText = "Kubikaža do:";
            this.cubicCapacityToControl.Location = new System.Drawing.Point(393, 137);
            this.cubicCapacityToControl.Name = "cubicCapacityToControl";
            this.cubicCapacityToControl.SelectedItem = null;
            this.cubicCapacityToControl.Size = new System.Drawing.Size(125, 62);
            this.cubicCapacityToControl.TabIndex = 14;
            // 
            // cubicCapacityFromControl
            // 
            this.cubicCapacityFromControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cubicCapacityFromControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubicCapacityFromControl.LabelText = "Kubikaža od:";
            this.cubicCapacityFromControl.Location = new System.Drawing.Point(263, 137);
            this.cubicCapacityFromControl.Name = "cubicCapacityFromControl";
            this.cubicCapacityFromControl.SelectedItem = null;
            this.cubicCapacityFromControl.Size = new System.Drawing.Size(124, 62);
            this.cubicCapacityFromControl.TabIndex = 13;
            // 
            // createdYearToControl
            // 
            this.createdYearToControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.createdYearToControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createdYearToControl.LabelText = "Godište do:";
            this.createdYearToControl.Location = new System.Drawing.Point(133, 137);
            this.createdYearToControl.Name = "createdYearToControl";
            this.createdYearToControl.SelectedItem = null;
            this.createdYearToControl.Size = new System.Drawing.Size(124, 62);
            this.createdYearToControl.TabIndex = 12;
            // 
            // createdYearFromControl
            // 
            this.createdYearFromControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.createdYearFromControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createdYearFromControl.LabelText = "Godište od:";
            this.createdYearFromControl.Location = new System.Drawing.Point(3, 137);
            this.createdYearFromControl.Name = "createdYearFromControl";
            this.createdYearFromControl.SelectedItem = null;
            this.createdYearFromControl.Size = new System.Drawing.Size(124, 62);
            this.createdYearFromControl.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(10, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(501, 37);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Pronadji automobile";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelBtnContainer
            // 
            this.panelBtnContainer.Controls.Add(this.btnSearch);
            this.panelBtnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBtnContainer.Location = new System.Drawing.Point(0, 202);
            this.panelBtnContainer.Name = "panelBtnContainer";
            this.panelBtnContainer.Padding = new System.Windows.Forms.Padding(10);
            this.panelBtnContainer.Size = new System.Drawing.Size(521, 57);
            this.panelBtnContainer.TabIndex = 2;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // CarFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBtnContainer);
            this.Controls.Add(this.tlpForm);
            this.Name = "CarFilterView";
            this.Size = new System.Drawing.Size(521, 259);
            this.Load += new System.EventHandler(this.CarFilterView_Load);
            this.tlpForm.ResumeLayout(false);
            this.panelBtnContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private UserControls.UCVerticalComboBoxGroup driveTypeControl;
        private UserControls.UCVerticalComboBoxGroup dorCountControl;
        private UserControls.UCVerticalComboBoxGroup modelControl;
        private UserControls.UCVerticalComboBoxGroup shiftTypeControl;
        private UserControls.UCVerticalComboBoxGroup fuelTypeControl;
        private UserControls.UCVerticalComboBoxGroup carBodyControl;
        private UserControls.UCVerticalComboBoxGroup brandControl;
        private UserControls.UCVerticalComboBoxGroup cubicCapacityToControl;
        private UserControls.UCVerticalComboBoxGroup cubicCapacityFromControl;
        private UserControls.UCVerticalComboBoxGroup createdYearToControl;
        private UserControls.UCVerticalComboBoxGroup createdYearFromControl;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelBtnContainer;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
