using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FullScreenGameWindows
{
    public class CustomLabel
    {
        private Label label;

        public CustomLabel(string text, int fontSize, Color textColor, Point location)
        {
            // Create and set up the label
            label = new Label();
            label.Text = text;
            label.Font = new Font("Arial", fontSize, FontStyle.Bold);
            label.ForeColor = textColor;
            label.Location = location;
            label.AutoSize = true;
        }

        // Property to get the Label control
        public Label GetLabel()
        {
            return label;
        }
    }
}



