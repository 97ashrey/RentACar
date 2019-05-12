namespace UI.UserControls
{
    partial class UCVerticalDateTimePickerGroup
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
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker.Location = new System.Drawing.Point(6, 25);
            this.dateTimePicker.Value = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            // 
            // UCVerticalDateTimePickerGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Date = new System.DateTime(2019, 4, 27, 0, 37, 46, 8);
            this.Name = "UCVerticalDateTimePickerGroup";
            this.Size = new System.Drawing.Size(185, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
