using System.Windows.Forms;
using System;

namespace MapEditor2
{
    public partial class RedimensionMapSizeValuesUserControl : UserControl
    {
        #region Declarations
        public bool KeepCurrentTiles { get { return checkBox_KeepCurrentTiles.Checked; } }

        string _RedimensionProperty;
        public string RedimensionProperty { get { return _RedimensionProperty; } }

        int _PropertyWidth;
        public int PropertyWidth { get { return _PropertyWidth; } }

        int _PropertyHeight;
        public int PropertyHeight { get { return _PropertyHeight; } }
        #endregion

        public RedimensionMapSizeValuesUserControl(string redimensionProperty, int currentWidth, int currentHeight)
        {
            InitializeComponent();

            _RedimensionProperty = redimensionProperty;

            label_CurrentPropertyWidth.Text = string.Format(label_CurrentPropertyWidth.Text, _RedimensionProperty);
            label_CurrentPropertyHeight.Text = string.Format(label_CurrentPropertyHeight.Text, _RedimensionProperty);

            label_NewPropertyWidth.Text = string.Format(label_NewPropertyWidth.Text, _RedimensionProperty);
            label_NewPropertyHeight.Text = string.Format(label_NewPropertyHeight.Text, _RedimensionProperty);

            label_CurrentWidth.Text = currentWidth.ToString();
            label_CurrentHeight.Text = currentHeight.ToString();

            textBox_Width.Text = currentWidth.ToString();
            textBox_Height.Text = currentHeight.ToString();
        }

        private void textBox_Leave(object sender, System.EventArgs e)
        {
            Int32.TryParse(textBox_Width.Text, out _PropertyWidth);
            Int32.TryParse(textBox_Height.Text, out _PropertyHeight);

            textBox_Width.Text = _PropertyWidth.ToString();
            textBox_Height.Text = _PropertyHeight.ToString();
        }
    }
}
