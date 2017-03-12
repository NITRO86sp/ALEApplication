using System.Drawing;
using System.Windows.Forms;

namespace alwfx.UI.Infrastructure.Helpers
{
    /// <summary>
    /// Helper for disabling a button
    /// </summary>
    public class ButtonHelpers
    {
        public static Button Disable(Button deviceButton)
        {
            deviceButton.ForeColor = Color.White;
            deviceButton.BackColor = Color.DimGray;
            deviceButton.Enabled = false;

            return deviceButton;
        }
    }
}
