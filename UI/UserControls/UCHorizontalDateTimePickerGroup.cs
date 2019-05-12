using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UserControls
{
    public partial class UCHorizontalDateTimePickerGroup : UserControl
    {
        public UCHorizontalDateTimePickerGroup()
        {
            InitializeComponent();
        }
        [
        Category("Extended properties"),
        Description("Text of the label.")
        ]
        public string LabelText { get => label.Text; set => label.Text = value; }
        [
        Category("Extended properties"),
        Description("Value of dateTimePicker.")
        ]
        public DateTime Date { get => dateTimePicker.Value; set => dateTimePicker.Value = value; }
        public DateTimePicker DateTimePicker { get => dateTimePicker; }
        public Label Label { get => label; }
    }
}
