using System.Windows.Forms;

namespace MapEditor2
{
    public partial class AddLayerUserControl : UserControl
    {
        public bool InsertAheadSelectedLayer { get { return radioButton_Ahead.Checked; } }

        public AddLayerUserControl(int currentLayer, int layers)
        {
            InitializeComponent();

            label_CurrentLayer.Text = (currentLayer + 1).ToString();

            comboBox_Layers.Items.Clear();

            for (int x = 0; x < layers; x++)
                comboBox_Layers.Items.Add(string.Format(ApplicationStrings.Layer, x + 1));

            if (comboBox_Layers.Items.Count > 0 && comboBox_Layers.Items.Count > currentLayer)
                comboBox_Layers.SelectedIndex = currentLayer;
        }
    }
}
