using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor2
{
    public partial class CustomWindow : Form
    {
        #region Constructor
        public CustomWindow(UserControl userControl)
        {
            InitializeComponent();

            Initialize(userControl, false, String.Empty, String.Empty);
        }

        public CustomWindow(UserControl userControl, bool cancelButtonVisible)
        {
            InitializeComponent();

            Initialize(userControl, cancelButtonVisible, String.Empty, String.Empty);
        }

        public CustomWindow(UserControl userControl, string windowTitle)
        {
            InitializeComponent();

            Initialize(userControl, false, windowTitle, String.Empty);
        }

        public CustomWindow(UserControl userControl, string windowTitle, string groupBoxTitle)
        {
            InitializeComponent();

            Initialize(userControl, false, windowTitle, groupBoxTitle);
        }

        public CustomWindow(UserControl userControl, bool cancelButtonVisible, string windowTitle, string groupBoxTitle)
        {
            InitializeComponent();

            Initialize(userControl, cancelButtonVisible, windowTitle, groupBoxTitle);
        }
        #endregion

        #region Initialization
        void Initialize(UserControl userControl, bool cancelButtonVisible, string windowTitle, string groupBoxTitle)
        {
            userControl.Location = new Point(13, 15);

            groupBox_Content.Text = groupBoxTitle;
            groupBox_Content.Controls.Clear();
            groupBox_Content.Controls.Add(userControl);

            this.Text = windowTitle;
            this.Size = new System.Drawing.Size(userControl.Width + 50, userControl.Height + 100);

            button_Cancel.Visible = cancelButtonVisible;
        }
        #endregion
    }
}
