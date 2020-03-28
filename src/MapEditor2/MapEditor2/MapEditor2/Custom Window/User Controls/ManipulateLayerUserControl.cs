using System.Windows.Forms;

namespace MapEditor2
{
    public partial class ManipulateLayerUserControl : UserControl
    {
        string _CurrentAction;
        public string CurrentAction { get { return _CurrentAction; } }

        public ManipulateLayerUserControl(string manipulationAction, int currentLayer, int layers)
        {
            InitializeComponent();

            _CurrentAction = manipulationAction;

            label_CurrentLayer.Text = (currentLayer + 1).ToString();
            label_ManipulationType.Text = string.Format(label_ManipulationType.Text, CurrentAction);

            comboBox_Layers.Items.Clear();

            for (int x = 0; x < layers; x++)
                comboBox_Layers.Items.Add(string.Format(ApplicationStrings.Layer, x + 1));

            if (comboBox_Layers.Items.Count > 0 && comboBox_Layers.Items.Count > currentLayer)
                comboBox_Layers.SelectedIndex = currentLayer;
        }
    }
}
