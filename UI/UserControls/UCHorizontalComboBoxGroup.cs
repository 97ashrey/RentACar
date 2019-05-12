using System.ComponentModel;
using System.Windows.Forms;

namespace UI.UserControls
{
    public partial class UCHorizontalComboBoxGroup : UserControl
    {
        public UCHorizontalComboBoxGroup()
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
        Description("Selected item of ComboBox")
        ]
        public object SelectedItem { get => comboBox.SelectedItem; set => comboBox.SelectedItem = value; }
        public ComboBoxStyle ComboBoxStyle { get => comboBox.DropDownStyle; set => comboBox.DropDownStyle = value; }

        public ComboBox ComboBox { get => comboBox; }
        public Label Label { get => label; }
    }
}
