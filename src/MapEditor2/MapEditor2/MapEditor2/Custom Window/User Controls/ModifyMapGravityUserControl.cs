using System;
using System.Windows.Forms;

namespace MapEditor2
{
    public partial class ModifyMapGravityUserControl : UserControl
    {
        #region Declarations
        float _MapGravityX;
        public float MapGravityX { get { return _MapGravityX; } }

        float _MapGravityY;
        public float MapGravityY { get { return _MapGravityY; } }

        public bool KeepModifiedGravity { get { return checkBox_KeepModifiedGravity.Checked; } }
        #endregion

        public ModifyMapGravityUserControl(float currentGravityX, float currentGravityY)
        {
            InitializeComponent();

            label_CurrentGravity.Text = string.Format("{0},{1}", currentGravityX, currentGravityY);

            textBox_GravityX.Text = currentGravityX.ToString();
            textBox_GravityY.Text = currentGravityY.ToString();
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            textBox_GravityX.Text = textBox_GravityX.Text.Replace('.', ',');
            textBox_GravityY.Text = textBox_GravityY.Text.Replace('.', ',');

            float.TryParse(textBox_GravityX.Text, out _MapGravityX);
            float.TryParse(textBox_GravityY.Text, out _MapGravityY);

            textBox_GravityX.Text = _MapGravityX.ToString();
            textBox_GravityY.Text = _MapGravityY.ToString();
        }
    }
}
