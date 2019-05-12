using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace UI.UserControls
{
    public class NumberTextBox: System.Windows.Forms.TextBox
    {
        [
        Category("Extended properties"),
        Description("Sets if textbox should accept only valid decimals. Works only if 'Numbers' property is set to true.")
        ]
        public bool Decimals { get; set; } = false;

        [
        Category("Extended properties"),
        Description("Sets if textbox should accept only number values.")
        ]
        public bool Numbers { get; set; } = false;

        public NumberTextBox()
        {
            lastValue = Text;
            TextChanged += TextChangedHandler;
        }

        private void TextChangedHandler(object sender, EventArgs e)
        {
            if (Numbers)
            {
                if (Decimals)
                {
                    DecimalsOnly();
                }
                else
                {
                    NumbersOnly();
                }
            }
            
        }

        private string lastValue;
        private void DecimalsOnly()
        {
            int selectionStart = SelectionStart;
            Regex decimalsOnly = new Regex(@"^0$|^[1-9]\d*$|^\.\d+$|^0\.\d*$|^[1-9]\d*\.\d*$");
            if (Text != "" && !decimalsOnly.IsMatch(Text))
            {
                Text = lastValue;
                selectionStart -= 1;
            } else
            {
                lastValue = Text;
            }
            SelectionStart = (selectionStart < 0) ? 0 : selectionStart;
        }

        private void NumbersOnly()
        {
            int selectionStart = SelectionStart;
            Regex digitsOnly = new Regex(@"[^\d]");
            if (digitsOnly.IsMatch(Text))
            {
                Text = digitsOnly.Replace(Text, "");
                selectionStart -= 1;
            }
            SelectionStart = (selectionStart < 0) ? 0 : selectionStart;
        }
    }
}
