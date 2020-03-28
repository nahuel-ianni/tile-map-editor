using System.Windows.Forms;

namespace MapEditor2
{
    public partial class AboutUserControl : UserControl
    {
        public AboutUserControl()
        {
            InitializeComponent();

            label_AboutMapEditor.Text = 
                string.Format(
                ApplicationStrings.AboutMapEditorContent,
                Application.ProductName,
                Application.ProductVersion, 
                ApplicationStrings.DesignerName, 
                ApplicationStrings.AboutMapEditorWebsites);
        }
    }
}
