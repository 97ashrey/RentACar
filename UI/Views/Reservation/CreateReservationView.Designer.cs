namespace UI.Views.Reservation
{
    partial class CreateReservationView
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
            this.lbPeriods = new System.Windows.Forms.ListBox();
            this.dateFromControl = new UI.UserControls.UCVerticalDateTimePickerGroup();
            this.dateToControl = new UI.UserControls.UCVerticalDateTimePickerGroup();
            this.priceControl = new UI.UserControls.UCVerticalTextBoxGroup();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelBtnContainer = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panelForm.SuspendLayout();
            this.panelBtnContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPeriods
            // 
            this.lbPeriods.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPeriods.FormattingEnabled = true;
            this.lbPeriods.Location = new System.Drawing.Point(0, 0);
            this.lbPeriods.Name = "lbPeriods";
            this.lbPeriods.Size = new System.Drawing.Size(395, 121);
            this.lbPeriods.TabIndex = 0;
            // 
            // dateFromControl
            // 
            this.dateFromControl.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.dateFromControl.LabelText = "Datum od:";
            this.dateFromControl.Location = new System.Drawing.Point(3, 0);
            this.dateFromControl.Name = "dateFromControl";
            this.dateFromControl.Size = new System.Drawing.Size(185, 53);
            this.dateFromControl.TabIndex = 1;
            // 
            // dateToControl
            // 
            this.dateToControl.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.dateToControl.LabelText = "Datum do:";
            this.dateToControl.Location = new System.Drawing.Point(3, 59);
            this.dateToControl.Name = "dateToControl";
            this.dateToControl.Size = new System.Drawing.Size(185, 53);
            this.dateToControl.TabIndex = 2;
            // 
            // priceControl
            // 
            this.priceControl.InputText = "";
            this.priceControl.LabelText = "Ukupna cena rezervacije:";
            this.priceControl.Location = new System.Drawing.Point(210, 59);
            this.priceControl.Name = "priceControl";
            this.priceControl.Size = new System.Drawing.Size(185, 53);
            this.priceControl.TabIndex = 3;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.dateFromControl);
            this.panelForm.Controls.Add(this.priceControl);
            this.panelForm.Controls.Add(this.dateToControl);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 121);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(395, 117);
            this.panelForm.TabIndex = 4;
            // 
            // panelBtnContainer
            // 
            this.panelBtnContainer.Controls.Add(this.btnCreate);
            this.panelBtnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBtnContainer.Location = new System.Drawing.Point(0, 238);
            this.panelBtnContainer.Name = "panelBtnContainer";
            this.panelBtnContainer.Padding = new System.Windows.Forms.Padding(10);
            this.panelBtnContainer.Size = new System.Drawing.Size(395, 63);
            this.panelBtnContainer.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate.Location = new System.Drawing.Point(10, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(375, 43);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Rezerviši";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // CreateReservationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBtnContainer);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.lbPeriods);
            this.Name = "CreateReservationView";
            this.Size = new System.Drawing.Size(395, 301);
            this.panelForm.ResumeLayout(false);
            this.panelBtnContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbPeriods;
        private UserControls.UCVerticalDateTimePickerGroup dateFromControl;
        private UserControls.UCVerticalDateTimePickerGroup dateToControl;
        private UserControls.UCVerticalTextBoxGroup priceControl;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel panelBtnContainer;
        private System.Windows.Forms.Button btnCreate;
    }
}
