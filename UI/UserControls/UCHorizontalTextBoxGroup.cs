using System.ComponentModel;
using System.Windows.Forms;

namespace UI.UserControls
{
    public partial class UCHorizontalTextBoxGroup : UserControl
    {
        public UCHorizontalTextBoxGroup()
        {
            InitializeComponent();
        }
        [
        Category("Extended properties"),
        Description("Text of the label")
        ]
        public string LabelText { get => label.Text; set => label.Text = value; }
        [
        Category("Extended properties"),
        Description("Text of the textbox")
        ]
        public string InputText { get => textBox.Text; set => textBox.Text = value; }

        public NumberTextBox TextBox { get => textBox; }
        public Label Label { get => label; }
    }
}
