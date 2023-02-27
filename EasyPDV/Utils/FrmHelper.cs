using System.Windows.Forms;

namespace EasyPDV.Utils
{
    public class FrmHelper
    {
        public static void OpenIfIsNot(string screenText, Form form)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == screenText)
                {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false)
            {
                form.Show();
            }
        }
    }
}
