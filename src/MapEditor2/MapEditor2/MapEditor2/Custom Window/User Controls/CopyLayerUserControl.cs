using System.Windows.Forms;

namespace MapEditor2
{
    public partial class CopyLayerUserControl : UserControl
    {
        #region Properties
        public int SourceLayer { get { return comboBox_SourceLayers.SelectedIndex; } }
        public int DestinationLayer { get { return comboBox_DestinationLayers.SelectedIndex; } }
        #endregion

        public CopyLayerUserControl(int currentLayer, int layers)
        {
            InitializeComponent();

            label_CurrentLayer.Text = (currentLayer + 1).ToString();

            comboBox_SourceLayers.Items.Clear();
            comboBox_DestinationLayers.Items.Clear();

            for (int x = 0; x < layers; x++)
            {
                comboBox_SourceLayers.Items.Add(string.Format(ApplicationStrings.Layer, x + 1));
                comboBox_DestinationLayers.Items.Add(string.Format(ApplicationStrings.Layer, x + 1));
            }

            if (comboBox_SourceLayers.Items.Count > 0 && comboBox_SourceLayers.Items.Count > currentLayer)
            {
                comboBox_SourceLayers.SelectedIndex = currentLayer;
                comboBox_DestinationLayers.SelectedIndex = currentLayer;
            }
        }
    }
}
