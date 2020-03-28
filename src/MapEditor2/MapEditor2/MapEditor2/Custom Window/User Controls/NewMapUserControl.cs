using System;
using System.Windows.Forms;

namespace MapEditor2
{
    public partial class NewMapUserControl : UserControl
    {
        #region Declarations
        public string MapName { get { return textBox_MapName.Text; } }

        public bool KeepCurrentTiles { get { return checkBox_KeepCurrentTiles.Checked; } }

        int _Layers;
        public int Layers { get { return _Layers; } }

        int _GravityX;
        public int GravityX { get { return _GravityX; } }

        int _GravityY;
        public int GravityY { get { return _GravityY; } }

        int _MapWidth;
        public int MapWidth { get { return _MapWidth; } }

        int _MapHeight;
        public int MapHeight { get { return _MapHeight; } }

        int _TileWidth;
        public int TileWidth { get { return _TileWidth; } }

        int _TileHeight;
        public int TileHeight { get { return _TileHeight; } }
        #endregion

        #region Constructor
        public NewMapUserControl(
            string currentMapName,
            int currentLayers,
            int currentGravityX,
            int currentGravityY,
            int currentMapWidth,
            int currentMapHeight,
            int currentTileWidth,
            int currentTileHeight)
        {
            InitializeComponent();

            textBox_MapName.Text = currentMapName;
            textBox_Layers.Text = currentLayers.ToString();
            textBox_GravityX.Text = currentGravityX.ToString();
            textBox_GravityY.Text = currentGravityY.ToString();
            textBox_MapWidth.Text = currentMapWidth.ToString();
            textBox_MapHeight.Text = currentMapHeight.ToString();
            textBox_TileWidth.Text = currentTileWidth.ToString();
            textBox_TileHeight.Text = currentTileHeight.ToString();
        }
        #endregion

        #region Events
        private void textBox_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(textBox_Layers.Text, out _Layers);
            Int32.TryParse(textBox_MapWidth.Text, out _MapWidth);
            Int32.TryParse(textBox_MapHeight.Text, out _MapHeight);
            Int32.TryParse(textBox_TileWidth.Text, out _TileWidth);
            Int32.TryParse(textBox_TileHeight.Text, out _TileHeight);
            Int32.TryParse(textBox_GravityX.Text, out _GravityX);
            Int32.TryParse(textBox_GravityY.Text, out _GravityY);

            textBox_Layers.Text = _Layers.ToString();
            textBox_MapWidth.Text = _MapWidth.ToString();
            textBox_MapHeight.Text = _MapHeight.ToString();
            textBox_TileWidth.Text = _TileWidth.ToString();
            textBox_TileHeight.Text = _TileHeight.ToString();
            textBox_GravityX.Text = _GravityX.ToString();
            textBox_GravityY.Text = _GravityY.ToString();
        }
        #endregion
    }
}
