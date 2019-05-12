namespace UI.Views.Reservation
{
    partial class SelectCarView
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
            this.lblCarInfo = new System.Windows.Forms.Label();
            this.carControl = new UI.UserControls.UCHorizontalComboBoxGroup();
            this.SuspendLayout();
            // 
            // lblCarInfo
            // 
            this.lblCarInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCarInfo.Location = new System.Drawing.Point(0, 0);
            this.lblCarInfo.Name = "lblCarInfo";
            this.lblCarInfo.Size = new System.Drawing.Size(310, 39);
            this.lblCarInfo.TabIndex = 0;
            this.lblCarInfo.Text = "{{IN CODE}}";
            this.lblCarInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // carControl
            // 
            this.carControl.ComboBoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carControl.LabelText = "Odaberite automobil:";
            this.carControl.Location = new System.Drawing.Point(3, 51);
            this.carControl.Name = "carControl";
            this.carControl.SelectedItem = null;
            this.carControl.Size = new System.Drawing.Size(290, 25);
            this.carControl.TabIndex = 1;
            // 
            // SelectCarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.carControl);
            this.Controls.Add(this.lblCarInfo);
            this.Name = "SelectCarView";
            this.Size = new System.Drawing.Size(310, 79);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCarInfo;
        private UserControls.UCHorizontalComboBoxGroup carControl;
    }
}
