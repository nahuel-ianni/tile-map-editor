using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using TileMapLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor2
{
    public partial class LevelEditor : Form
    {
        #region Declarations
        public LevelEditorGame Game;

        private CustomWindow _CustomWindow;
        private ColorDialog _ColorDialog;
        private SaveFileDialog _SaveFileDialog;
        private OpenFileDialog _OpenFileDialog;

        private enum ManipulateLayerActions { Clear, Fill, Hide, Remove }
        private enum RedimensionMapSizeValuesTypes { Map, Tile }

        private string _MapName;
        private string _FormattedMapName
        {
            get { return _MapName; }
            set
            {
                _MapName = value.Split('.')[0];
                this.Text = string.Format("{0} - {1}", _MapName, Application.ProductName);
            }
        }

        private string _FileName = string.Empty;
        private string _AuxiliarFileName = Application.StartupPath + @"\AuxiliarMap.xml";

        private float _GravityX = 0;
        private float _GravityY = 0;

        private float _CurrentLayerAutoScrollingX = 0;
        private float _CurrentLayerAutoScrollingY = 0;

        private System.Drawing.Rectangle _TileSheetSelection = new System.Drawing.Rectangle(0, 0, 0, 0);

        private Vector2 _InitialTileSheetSelection = Vector2.Zero;
        private Vector2 _FinalTileSheetSelection = Vector2.Zero;

        private int _SelectedHorizontalTiles = 0;
        private int _SelectedVerticalTiles = 0;

        private System.Collections.Generic.List<StringWriter> _UndoCollection = new System.Collections.Generic.List<StringWriter>();
        private System.Collections.Generic.List<StringWriter> _RedoCollection = new System.Collections.Generic.List<StringWriter>();

        Vector2 _FillingRectangleMousePosition = Vector2.Zero;
        private int _MaxUndoRedoItems = 20;
        #endregion

        #region Constructor
        public LevelEditor()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        #region Custom Window Events
        private void button_Accept_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            #region AboutUserControl
            if (_CustomWindow.groupBox_Content.Controls.ContainsKey(typeof(AboutUserControl).Name))
                CustomWindow_FormClosing(null, null);
            #endregion

            #region AddLayerUserControl
            if (_CustomWindow.groupBox_Content.Controls.ContainsKey(typeof(AddLayerUserControl).Name))
            {
                AddLayerUserControl _AddLayerUserControl = (AddLayerUserControl)_CustomWindow.groupBox_Content.Controls[typeof(AddLayerUserControl).Name];

                CreateSerializableTileMap(null, _UndoCollection);

                TileMap.AddLayer(
                    (int)MathHelper.Clamp(_AddLayerUserControl.comboBox_Layers.SelectedIndex, 0, TileMap.MapLayers - 1),
                    _AddLayerUserControl.InsertAheadSelectedLayer);
                TileMap.CurrentLayer = 0;

                CustomWindow_FormClosing(null, null);
            }
            #endregion

            #region CopyLayerUserControl
            if (_CustomWindow.groupBox_Content.Controls.ContainsKey(typeof(CopyLayerUserControl).Name) &&
                ShowYesNoMessageBox(ApplicationStrings.CopyLayerMsgBoxText) == DialogResult.Yes)
            {
                CopyLayerUserControl _CopyLayerUserControl = ((CopyLayerUserControl)_CustomWindow.groupBox_Content.Controls[typeof(CopyLayerUserControl).Name]);

                CreateSerializableTileMap(TileMap.MapLayerCollection[_CopyLayerUserControl.DestinationLayer].LayerNumber, _UndoCollection);

                TileMap.CopyLayer(_CopyLayerUserControl.SourceLayer, _CopyLayerUserControl.DestinationLayer);

                CustomWindow_FormClosing(null, null);
            }
            #endregion

            #region ManipulateLayerUserControl
            if (_CustomWindow.groupBox_Content.Controls.ContainsKey(typeof(ManipulateLayerUserControl).Name))
            {
                ManipulateLayerUserControl _ManipulateLayerUserControl = (ManipulateLayerUserControl)_CustomWindow.groupBox_Content.Controls[typeof(ManipulateLayerUserControl).Name];

                int _Layer = (int)MathHelper.Clamp(
                        _ManipulateLayerUserControl.comboBox_Layers.SelectedIndex,
                        0,
                        TileMap.MapLayers - 1);

                switch (_ManipulateLayerUserControl.CurrentAction)
                {
                    case "Clear":
                        #region Clear Layer
                        if (ShowYesNoMessageBox(ApplicationStrings.CleanLayerMsgBoxText) == DialogResult.Yes)
                        {
                            CreateSerializableTileMap(_Layer, _UndoCollection);

                            TileMap.ClearLayer(_Layer);
                        }
                        #endregion
                        break;

                    case "Fill":
                        #region Fill Layer
                        if (ShowYesNoMessageBox(ApplicationStrings.FillLayerMsgBoxText) == DialogResult.Yes)
                        {
                            CreateSerializableTileMap(_Layer, _UndoCollection);

                            FillLayer(_Layer);
                        }
                        #endregion
                        break;

                    case "Hide":
                        #region Hide Layer
                        CreateSerializableTileMap(_Layer, _UndoCollection);

                        TileMap.MapLayerCollection[_Layer].ShowLayer = false;
                        #endregion
                        break;

                    case "Remove":
                        #region Remove Layer
                        if (ShowYesNoMessageBox(ApplicationStrings.RemoveLayerMsgBoxText) == DialogResult.Yes)
                        {
                            CreateSerializableTileMap(null, _UndoCollection);

                            TileMap.RemoveLayer(_Layer);

                            TileMap.CurrentLayer = 0;
                        }
                        #endregion
                        break;
                }

                CustomWindow_FormClosing(null, null);
            }
            #endregion

            #region ModifyMapGravityUserControl
            if (_CustomWindow.groupBox_Content.Controls.ContainsKey(typeof(ModifyMapGravityUserControl).Name))
            {
                ModifyMapGravityUserControl _ModifyMapGravityUserControl =
                    ((ModifyMapGravityUserControl)_CustomWindow.groupBox_Content.Controls[typeof(ModifyMapGravityUserControl).Name]);

                CreateSerializableTileMap(null, _UndoCollection);

                TileMap.ModifyMapGravity(_ModifyMapGravityUserControl.MapGravityX, _ModifyMapGravityUserControl.MapGravityY, _ModifyMapGravityUserControl.KeepModifiedGravity);

                CustomWindow_FormClosing(null, null);
            }
            #endregion

            #region NewMapUserControl
            if (_CustomWindow.groupBox_Content.Controls.ContainsKey(typeof(NewMapUserControl).Name))
            {
                NewMapUserControl _NewMapUserControl = ((NewMapUserControl)_CustomWindow.groupBox_Content.Controls[typeof(NewMapUserControl).Name]);

                _UndoCollection.Clear();
                _RedoCollection.Clear();

                CreateSerializableTileMap(null, _UndoCollection);

                _FormattedMapName = _NewMapUserControl.MapName;
                _FileName = string.Empty;

                if (TileMap.MapLayers != _NewMapUserControl.Layers)
                {
                    // Removes the spared layers
                    if (TileMap.MapLayers > _NewMapUserControl.Layers)
                        for (int z = _NewMapUserControl.Layers; z <= TileMap.MapLayers; z++)
                            TileMap.RemoveLayer(z);
                    else
                    {
                        // Adds the new layers.
                        for (int z = TileMap.MapLayers; z < _NewMapUserControl.Layers; z++)
                            TileMap.AddLayer();
                    }
                }

                if (TileMap.Gravity.X != _NewMapUserControl.GravityX ||
                    TileMap.Gravity.Y != _NewMapUserControl.GravityY)
                    TileMap.ModifyMapGravity(new Vector2(_NewMapUserControl.GravityX, _NewMapUserControl.GravityY), false);

                if (TileMap.TileWidth != _NewMapUserControl.TileWidth ||
                    TileMap.TileHeight != _NewMapUserControl.TileHeight)
                {
                    TileMap.RedimensionTileSize(_NewMapUserControl.TileWidth, _NewMapUserControl.TileHeight);

                    // Raises the drawing of the pictureBox in order to redraw the grid in front of the tiles so it shows the new tile size.
                    pictureBox_TileSheet.Invalidate();
                }

                if (TileMap.MapWidth != _NewMapUserControl.MapWidth ||
                    TileMap.MapHeight != _NewMapUserControl.MapHeight)
                    TileMap.RedimensionMapSize(_NewMapUserControl.MapWidth, _NewMapUserControl.MapHeight);

                if (!_NewMapUserControl.KeepCurrentTiles)
                    TileMap.ClearMap();

                TileMap.CurrentLayer = 0;

                FixScrollBarScales();

                CustomWindow_FormClosing(null, null);
            }
            #endregion

            #region RedimensionMapSizeValuesUserControl
            if (_CustomWindow.groupBox_Content.Controls.ContainsKey(typeof(RedimensionMapSizeValuesUserControl).Name))
            {
                RedimensionMapSizeValuesUserControl _RedimensionMapSizeValuesUserControl = ((RedimensionMapSizeValuesUserControl)_CustomWindow.groupBox_Content.Controls[typeof(RedimensionMapSizeValuesUserControl).Name]);

                if (_RedimensionMapSizeValuesUserControl.PropertyWidth > 0 || _RedimensionMapSizeValuesUserControl.PropertyHeight > 0)
                {
                    CreateSerializableTileMap(null, _UndoCollection);

                    switch (_RedimensionMapSizeValuesUserControl.RedimensionProperty)
                    {
                        case "Map":
                            TileMap.RedimensionMapSize(_RedimensionMapSizeValuesUserControl.PropertyWidth, _RedimensionMapSizeValuesUserControl.PropertyHeight);
                            break;

                        case "Tile":
                            TileMap.RedimensionTileSize(_RedimensionMapSizeValuesUserControl.PropertyWidth, _RedimensionMapSizeValuesUserControl.PropertyHeight);

                            // Raises the drawing of the pictureBox in order to redraw the grid in front of the tiles so it shows the new tile size.
                            pictureBox_TileSheet.Invalidate();
                            break;
                    }

                    FixScrollBarScales();

                    if (!_RedimensionMapSizeValuesUserControl.KeepCurrentTiles)
                        TileMap.ClearMap();
                }

                CustomWindow_FormClosing(null, null);
            }
            #endregion
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            CustomWindow_FormClosing(null, null);
        }

        private void CustomWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;

            _CustomWindow.button_Accept.Click -= new EventHandler(button_Accept_Click);
            _CustomWindow.button_Cancel.Click -= new EventHandler(button_Cancel_Click);
            _CustomWindow.FormClosing -= new FormClosingEventHandler(CustomWindow_FormClosing);
            _CustomWindow.Close();
        }

        private void CustomWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;        // It is here so that it will focus the Form (and won't minimize it).
            _CustomWindow.FormClosed -= new FormClosedEventHandler(CustomWindow_FormClosed);
        }
        #endregion

        #region Form Events
        // When the form is selected as the current application in Windows OS.
        private void LevelEditor_Activated(object sender, EventArgs e)
        {
            this.Enabled = true;
            //this.WindowState = _LastFormWindowState;
        }

        // When the form is not selected as the current application in Windows OS.
        private void LevelEditor_Deactivate(object sender, EventArgs e)
        {
            //_LastFormWindowState = this.WindowState;
            this.Enabled = false;
            //this.WindowState = FormWindowState.Minimized;
        }

        private void LevelEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApplication();
        }

        private void LevelEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.Enabled = MapHasPendingChanges();
        }

        private void LevelEditor_Load(object sender, EventArgs e)
        {
            TileMap.EditorMode = true;
            _FormattedMapName = ApplicationStrings.UnknownMap;

            _ColorDialog = new ColorDialog();
            _ColorDialog.AllowFullOpen = true;

            ResetCodeValuesCombo();

            #region File Dialog
            _OpenFileDialog = new OpenFileDialog();
            _OpenFileDialog.Multiselect = false;
            _OpenFileDialog.InitialDirectory = Application.StartupPath;
            _OpenFileDialog.RestoreDirectory = true;

            _SaveFileDialog = new SaveFileDialog();
            _SaveFileDialog.Title = ApplicationStrings.SaveMap;
            _SaveFileDialog.DefaultExt = ".XML";
            _SaveFileDialog.AddExtension = true;
            _SaveFileDialog.FileName = ApplicationStrings.SimpleMapName;
            _SaveFileDialog.Filter = ApplicationStrings.XmlFileFilter;
            _SaveFileDialog.InitialDirectory = Application.StartupPath;
            _SaveFileDialog.RestoreDirectory = true;
            #endregion
        }

        // Executed only once, when the base form is first shown (ended loading up).
        private void LevelEditor_Shown(object sender, EventArgs e)
        {
            LoadTileSheet(Application.StartupPath + @"\Content\Textures\BasicTiles.png");

            pctSurface_MouseDown(null, null);

            _UndoCollection.Clear();
            _RedoCollection.Clear();
            Game.HasPendingChanges = false;
        }
        #endregion

        #region Form Controls Events
        private void GameUpdate_Timer_Tick(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                // Executes the Update method of the game1 class.
                Game.Tick();

                ShowGameParameters(Camera.ScreenToWorld(new Vector2(Mouse.GetState().X, Mouse.GetState().Y)));

                CheckControlsState();
            }
        }

        #region Game's Picture Box
        private void pctSurface_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Enabled)
            {
                // Setting all layer tiles as not passable
                if (e != null &&
                    e.Button == System.Windows.Forms.MouseButtons.Right &&
                    Game.ApplyPassableToAllLayers == true &&
                    Game.EditingFillRectangle == false &&
                    Game.EditingGravity == false &&
                    Game.SetPassable == false &&
                    Game.EditingCode == false)
                {
                    CreateSerializableTileMap(null, _UndoCollection);
                }
                else
                    CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);

                if (e != null &&
                    e.Button == System.Windows.Forms.MouseButtons.Right &&
                    Game.EditingFillRectangle == true)
                    _FillingRectangleMousePosition = new Vector2(e.X, e.Y);
            }
        }

        private void pctSurface_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Enabled &&
                e != null &&
                e.Button == System.Windows.Forms.MouseButtons.Right &&
                Game.EditingFillRectangle == true)
            {
                if (_FillingRectangleMousePosition.X < e.X)
                {
                    Game.FillingRectangleStartingCell.X = (int)_FillingRectangleMousePosition.X;
                    Game.FillingRectangleEndingCell.X = e.X;
                }
                else
                {
                    Game.FillingRectangleStartingCell.X = e.X;
                    Game.FillingRectangleEndingCell.X = (int)_FillingRectangleMousePosition.X;
                }

                if (_FillingRectangleMousePosition.Y < e.Y)
                {
                    Game.FillingRectangleStartingCell.Y = (int)_FillingRectangleMousePosition.Y;
                    Game.FillingRectangleEndingCell.Y = e.Y;
                }
                else
                {
                    Game.FillingRectangleStartingCell.Y = e.Y;
                    Game.FillingRectangleEndingCell.Y = (int)_FillingRectangleMousePosition.Y;
                }

                Game.FillingRectangleStartingCell.X = MathHelper.Clamp(TileMap.GetCellByPixelX((int)Camera.ScreenToWorld(Game.FillingRectangleStartingCell).X), 0, TileMap.MapWidth - 1);
                Game.FillingRectangleStartingCell.Y = MathHelper.Clamp(TileMap.GetCellByPixelY((int)Camera.ScreenToWorld(Game.FillingRectangleStartingCell).Y), 0, TileMap.MapHeight - 1);

                Game.FillingRectangleEndingCell.X = MathHelper.Clamp(TileMap.GetCellByPixelX((int)Camera.ScreenToWorld(Game.FillingRectangleEndingCell).X), 0, TileMap.MapWidth - 1);
                Game.FillingRectangleEndingCell.Y = MathHelper.Clamp(TileMap.GetCellByPixelY((int)Camera.ScreenToWorld(Game.FillingRectangleEndingCell).Y), 0, TileMap.MapHeight - 1);

                Game.FillingRectangle =
                    new Microsoft.Xna.Framework.Rectangle(
                        (int)(Camera.WorldToScreen(new Vector2(Game.FillingRectangleStartingCell.X * TileMap.TileWidth, Game.FillingRectangleStartingCell.Y * TileMap.TileHeight)).X),
                        (int)(Camera.WorldToScreen(new Vector2(Game.FillingRectangleStartingCell.X * TileMap.TileWidth, Game.FillingRectangleStartingCell.Y * TileMap.TileHeight)).Y),
                        (int)(Game.FillingRectangleEndingCell.X - Game.FillingRectangleStartingCell.X + 1) * TileMap.TileWidth,
                        (int)(Game.FillingRectangleEndingCell.Y - Game.FillingRectangleStartingCell.Y + 1) * TileMap.TileHeight);
            }
        }
        #endregion

        #region Tile Sheet Picture Box
        private void pictureBox_TileSheet_MouseDown(object sender, MouseEventArgs e)
        {
            _InitialTileSheetSelection.X = MathHelper.Clamp((int)Math.Floor((double)e.X / TileMap.TileWidth), 0, (TileMap.TileSheet.Width - TileMap.TileWidth) / TileMap.TileWidth);
            _InitialTileSheetSelection.Y = MathHelper.Clamp((int)Math.Floor((double)e.Y / TileMap.TileHeight), 0, (TileMap.TileSheet.Height - TileMap.TileHeight) / TileMap.TileHeight);
        }

        private void pictureBox_TileSheet_MouseUp(object sender, MouseEventArgs e)
        {
            _FinalTileSheetSelection.X = MathHelper.Clamp((int)Math.Floor((double)e.X / TileMap.TileWidth), 0, (TileMap.TileSheet.Width - TileMap.TileWidth) / TileMap.TileWidth);
            _FinalTileSheetSelection.Y = MathHelper.Clamp((int)Math.Floor((double)e.Y / TileMap.TileHeight), 0, (TileMap.TileSheet.Height - TileMap.TileHeight) / TileMap.TileHeight);

            // Calculate how many Horizontal tiles where selected.
            if (_InitialTileSheetSelection.X >= _FinalTileSheetSelection.X)
                _SelectedHorizontalTiles = (int)(_InitialTileSheetSelection.X - _FinalTileSheetSelection.X) + 1;
            else
                _SelectedHorizontalTiles = (int)(_FinalTileSheetSelection.X - _InitialTileSheetSelection.X) + 1;

            // Calculate how many Vertical tiles where selected.
            if (_InitialTileSheetSelection.Y >= _FinalTileSheetSelection.Y)
                _SelectedVerticalTiles = (int)(_InitialTileSheetSelection.Y - _FinalTileSheetSelection.Y) + 1;
            else
                _SelectedVerticalTiles = (int)(_FinalTileSheetSelection.Y - _InitialTileSheetSelection.Y) + 1;

            #region One Tile Selected
            if (_SelectedHorizontalTiles == 1 &&
                _SelectedVerticalTiles == 1)
            {
                _TileSheetSelection = new System.Drawing.Rectangle(
                    (int)_FinalTileSheetSelection.X,
                    (int)_FinalTileSheetSelection.Y,
                    1,
                    1);

                Game.DrawTile = GetTileNumber((int)_FinalTileSheetSelection.X, (int)_FinalTileSheetSelection.Y);
                Game.DrawTileCollection = null;
            }
            #endregion

            #region Multiple Tiles Selected
            else
            {
                int _RectangleXPosition = 0, _RectangleYPosition = 0;

                if (_InitialTileSheetSelection.X > _FinalTileSheetSelection.X)
                    _RectangleXPosition = (int)_FinalTileSheetSelection.X;
                else
                    _RectangleXPosition = (int)_InitialTileSheetSelection.X;

                if (_InitialTileSheetSelection.Y > _FinalTileSheetSelection.Y)
                    _RectangleYPosition = (int)_FinalTileSheetSelection.Y;
                else
                    _RectangleYPosition = (int)_InitialTileSheetSelection.Y;

                _TileSheetSelection = new System.Drawing.Rectangle(
                    _RectangleXPosition,
                    _RectangleYPosition,
                    1,
                    1);

                Game.DrawTile = -1;
                Game.DrawTileCollection = new int[_SelectedHorizontalTiles, _SelectedVerticalTiles];

                int _CurrentXValue = 0;
                int _CurrentYValue = 0;

                for (int x = _RectangleXPosition; x < (_RectangleXPosition + _SelectedHorizontalTiles); x++)
                {
                    for (int y = _RectangleYPosition; y < (_RectangleYPosition + _SelectedVerticalTiles); y++)
                    {
                        Game.DrawTileCollection[_CurrentXValue, _CurrentYValue] = GetTileNumber(x, y);
                        _CurrentYValue++;
                    }

                    _CurrentXValue++;
                    _CurrentYValue = 0;
                }
            }
            #endregion

            pictureBox_TileSheet.Invalidate();
        }

        private void pictureBox_TileSheet_Paint(object sender, PaintEventArgs e)
        {
            Pen _Grid_Pen = new Pen(System.Drawing.Color.White);

            for (int y = 0; y < pictureBox_TileSheet.Height; y += TileMap.TileWidth)
                e.Graphics.DrawLine(_Grid_Pen, 0, y, pictureBox_TileSheet.Width, y);

            for (int x = 0; x < pictureBox_TileSheet.Width; x += TileMap.TileWidth)
                e.Graphics.DrawLine(_Grid_Pen, x, 0, x, pictureBox_TileSheet.Height);

            Pen _Rectangle_Pen = new Pen(System.Drawing.Color.Orchid, 2.5f);

            e.Graphics.DrawRectangle(
                _Rectangle_Pen,
                _TileSheetSelection.X * TileMap.TileWidth + 1,
                _TileSheetSelection.Y * TileMap.TileHeight + 1,
                _TileSheetSelection.Width * TileMap.TileWidth * _SelectedHorizontalTiles - 3f,
                _TileSheetSelection.Height * TileMap.TileHeight * _SelectedVerticalTiles - 3f);
        }
        #endregion

        private void ScrollBar_pctSurface_Scroll(object sender, ScrollEventArgs e)
        {
            Game.FillingRectangle = Microsoft.Xna.Framework.Rectangle.Empty;
        }

        private void tabControl_Editor_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Tab Map
            if (tabControl_Editor.SelectedTab == tabPage_Map)
            {
                // Saves the TextBox content into the Xml File.
                try
                {
                    FileInfo _FileInfo = new FileInfo(_AuxiliarFileName);
                    StreamWriter _StreamWriter = _FileInfo.CreateText();

                    _StreamWriter.Write(richTextBox_XML.Text);
                    _StreamWriter.Close();
                }
                catch
                {
                    return;
                }

                // Loads the map from the file in order to get any change.
                try
                {
                    TileMap.LoadMap(new FileStream(_AuxiliarFileName, FileMode.Open));
                }
                catch { }
            }
            #endregion

            #region Tab XML
            if (tabControl_Editor.SelectedTab == tabPage_XML)
            {
                // Saves the map, creating it's corresponding file if it doesn't exists.
                TileMap.SaveMap(new FileStream(_AuxiliarFileName, FileMode.Create));

                // Gets the xml content of the map file.
                if (_AuxiliarFileName != string.Empty)
                    richTextBox_XML.Text = GetMapXmlString(_AuxiliarFileName);
            }
            #endregion
        }
        #endregion

        #region Menu Strip Events
        #region Edit
        private void addCodesToCodeValuesComboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenFileDialog.Title = ApplicationStrings.LoadCodeValueFile;
            _OpenFileDialog.Filter = ApplicationStrings.CodeValueFileFilter;

            if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string _CurrentLine = string.Empty;
                    string _CodeValues = string.Empty;

                    System.IO.StreamReader _File = new System.IO.StreamReader(_OpenFileDialog.FileName);

                    while ((_CurrentLine = _File.ReadLine()) != null)
                        _CodeValues = _CodeValues + ";" + _CurrentLine;

                    _File.Close();

                    AddCodeValuesCombo(_CodeValues.Split(';'));
                }
                catch
                {
                    ShowOKMessageBox(ApplicationStrings.ErrorReadingFile);
                }
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestorePreviousState(_RedoCollection, _UndoCollection);
        }

        private void resetCodeValuesComboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetCodeValuesCombo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestorePreviousState(_UndoCollection, _RedoCollection);
        }
        #endregion

        #region File
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMap();
        }

        private void loadNewTileSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewTileSheet();
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void saveMapAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMapFileAs();
        }
        #endregion

        #region Help
        private void aboutMapEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new AboutUserControl(), ApplicationStrings.AboutMapEditorCustomWindowTitle);
        }
        #endregion

        #region Layer
        private void addLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new AddLayerUserControl(TileMap.CurrentLayer, TileMap.MapLayers), true, ApplicationStrings.AddLayerCustomWindowTitle);
        }

        private void clearCurrentLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowYesNoMessageBox(ApplicationStrings.CleanCurrentLayerMsgBoxText) == DialogResult.Yes)
            {
                CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);
                TileMap.ClearLayer(TileMap.CurrentLayer);
            }
        }

        private void clearLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new ManipulateLayerUserControl(ManipulateLayerActions.Clear.ToString(), TileMap.CurrentLayer, TileMap.MapLayers), true, ApplicationStrings.ClearLayerCustomWindowTitle);
        }

        private void copyLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new CopyLayerUserControl(TileMap.CurrentLayer, TileMap.MapLayers), true, ApplicationStrings.CopyLayerCustomWindowTitle);
        }

        private void fillCurrentLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowYesNoMessageBox(ApplicationStrings.FillLayerMsgBoxText) == DialogResult.Yes)
            {
                CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);
                FillLayer(TileMap.CurrentLayer);
            }
        }

        private void fillLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new ManipulateLayerUserControl(ManipulateLayerActions.Fill.ToString(), TileMap.CurrentLayer, TileMap.MapLayers), true, ApplicationStrings.FillLayerCustomWindowTitle);
        }

        private void hideLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new ManipulateLayerUserControl(ManipulateLayerActions.Hide.ToString(), TileMap.CurrentLayer, TileMap.MapLayers), true, ApplicationStrings.HideLayerCustomWindowTitle);
        }

        private void removeCurrentLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowYesNoMessageBox(ApplicationStrings.RemoveCurrentLayerMsgBoxText) == DialogResult.Yes)
            {
                CreateSerializableTileMap(null, _UndoCollection);
                TileMap.RemoveLayer(TileMap.CurrentLayer);
            }
        }

        private void removeLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new ManipulateLayerUserControl(ManipulateLayerActions.Remove.ToString(), TileMap.CurrentLayer, TileMap.MapLayers), true, ApplicationStrings.RemoveLayerCustomWindowTitle);
        }
        #endregion

        #region Map
        private void applyPassableToAllLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyPassableToAllLayersToolStripMenuItem.Checked = !applyPassableToAllLayersToolStripMenuItem.Checked;
            Game.ApplyPassableToAllLayers = !Game.ApplyPassableToAllLayers;
        }

        private void clearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowYesNoMessageBox(ApplicationStrings.CleanMapMsgBoxText) == DialogResult.Yes)
            {
                CreateSerializableTileMap(null, _UndoCollection);
                TileMap.ClearMap();
            }
        }

        private void modifyMapGravityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomWindow(new ModifyMapGravityUserControl((int)TileMap.Gravity.X, (int)TileMap.Gravity.Y), true, ApplicationStrings.ModifyMapGravityCustomWindowTitle);
        }

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewMap();
        }

        private void redimensionMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowYesNoMessageBox(ApplicationStrings.RedimensionMapSizeMsgBoxText) == DialogResult.Yes)
                ShowCustomWindow(new RedimensionMapSizeValuesUserControl(RedimensionMapSizeValuesTypes.Map.ToString(), TileMap.MapWidth, TileMap.MapHeight), true, ApplicationStrings.RedimensionMapSizeCustomWindowTitle);
        }

        private void redimensionTileSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowYesNoMessageBox(string.Format(ApplicationStrings.RedimensionTileSizeMsgBoxText, TileMap.TileWidth, TileMap.TileHeight)) == DialogResult.Yes)
                ShowCustomWindow(new RedimensionMapSizeValuesUserControl(RedimensionMapSizeValuesTypes.Tile.ToString(), TileMap.TileWidth, TileMap.TileHeight), true, ApplicationStrings.RedimensionTileSizeCustomWindowTitle);
        }
        #endregion

        #region View
        private void codeValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeValuesToolStripMenuItem.Checked = !codeValuesToolStripMenuItem.Checked;
            TileMap.ShowCodeValues = !TileMap.ShowCodeValues;
        }

        private void gravityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gravityToolStripMenuItem.Checked = !gravityToolStripMenuItem.Checked;
            TileMap.ShowSquareGravity = !TileMap.ShowSquareGravity;
        }

        private void hideCurrentLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);

            hideCurrentLayerToolStripMenuItem.Checked = !hideCurrentLayerToolStripMenuItem.Checked;
            TileMap.MapLayerCollection[TileMap.CurrentLayer].ShowLayer = !TileMap.MapLayerCollection[TileMap.CurrentLayer].ShowLayer;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineToolStripMenuItem.Checked = !lineToolStripMenuItem.Checked;
            TileMap.ShowLinedGrid = !TileMap.ShowLinedGrid;

            pointedToolStripMenuItem.Checked = false;
            TileMap.ShowPointedGrid = false;
        }

        private void passableBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passableBlocksToolStripMenuItem.Checked = !passableBlocksToolStripMenuItem.Checked;
            TileMap.ShowPassableBlocks = !TileMap.ShowPassableBlocks;
        }

        private void pointedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pointedToolStripMenuItem.Checked = !pointedToolStripMenuItem.Checked;
            TileMap.ShowPointedGrid = !TileMap.ShowPointedGrid;

            lineToolStripMenuItem.Checked = false;
            TileMap.ShowLinedGrid = false;
        }

        private void showAllLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSerializableTileMap(null, _UndoCollection);

            TileMap.ShowAllLayers();
        }

        private void tilePreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tilePreviewToolStripMenuItem.Checked = !tilePreviewToolStripMenuItem.Checked;
            Game.ShowTilePreview = !Game.ShowTilePreview;
        }
        #endregion
        #endregion

        #region Tool Strip Events
        #region Buttons
        private void toolStripButton_CodeValue_Click(object sender, EventArgs e)
        {
            ResetToolStripEditingButtons();

            toolStripButton_CodeValue.Checked = !toolStripButton_CodeValue.Checked;
            Game.EditingCode = toolStripButton_CodeValue.Checked;

            toolStripTextBox_CodeValue.Enabled = toolStripButton_CodeValue.Checked;
        }

        private void toolStripButton_FillRectangle_Click(object sender, EventArgs e)
        {
            ResetToolStripEditingButtons();

            toolStripButton_FillRectangle.Checked = !toolStripButton_FillRectangle.Checked;
            Game.EditingFillRectangle = toolStripButton_FillRectangle.Checked;
        }

        private void toolStripButton_Gravity_Click(object sender, EventArgs e)
        {
            Game.CurrentGravity = new Vector2(_GravityX, _GravityY);

            ResetToolStripEditingButtons();

            toolStripButton_Gravity.Checked = !toolStripButton_Gravity.Checked;
            Game.EditingGravity = toolStripButton_Gravity.Checked;

            toolStripTextBox_GravityX.Enabled = toolStripTextBox_GravityY.Enabled = toolStripButton_Gravity.Checked;
        }

        private void toolStripButton_LoadMap_Click(object sender, EventArgs e)
        {
            LoadMap();
        }

        private void toolStripButton_LoadTileSheet_Click(object sender, EventArgs e)
        {
            LoadNewTileSheet();
        }

        private void toolStripButton_NewMap_Click(object sender, EventArgs e)
        {
            CreateNewMap();
        }

        private void toolStripButton_Redo_Click(object sender, EventArgs e)
        {
            RestorePreviousState(_RedoCollection, _UndoCollection);
        }

        private void toolStripButton_SaveMap_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void toolStripButton_SwitchNextLayer_Click(object sender, EventArgs e)
        {
            TileMap.CurrentLayer = (int)MathHelper.Clamp(TileMap.CurrentLayer + 1, 0, TileMap.MapLayers - 1);

            toolStripTextBox_AlphaValue.Text = TileMap.MapLayerCollection[TileMap.CurrentLayer].AlphaValue.ToString();
        }

        private void toolStripButton_SwitchPreviousLayer_Click(object sender, EventArgs e)
        {
            TileMap.CurrentLayer = (int)MathHelper.Clamp(TileMap.CurrentLayer - 1, 0, TileMap.MapLayers - 1);

            toolStripTextBox_AlphaValue.Text = TileMap.MapLayerCollection[TileMap.CurrentLayer].AlphaValue.ToString();
        }

        private void toolStripButton_TintColor_Click(object sender, EventArgs e)
        {
            // Selects from the pallete the current layer's tint color.
            _ColorDialog.Color = System.Drawing.Color.FromArgb(
                TileMap.MapLayerCollection[TileMap.CurrentLayer].TintColor.A,
                TileMap.MapLayerCollection[TileMap.CurrentLayer].TintColor.R,
                TileMap.MapLayerCollection[TileMap.CurrentLayer].TintColor.G,
                TileMap.MapLayerCollection[TileMap.CurrentLayer].TintColor.B);

            // Takes the selected color when the ColorDialog is closed.
            if (_ColorDialog.ShowDialog() == DialogResult.OK)
            {
                CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);
                TileMap.MapLayerCollection[TileMap.CurrentLayer].TintColor = new Microsoft.Xna.Framework.Color(_ColorDialog.Color.R, _ColorDialog.Color.G, _ColorDialog.Color.B);
            }
        }

        private void toolStripButton_ToggleAutoScrolling_Click(object sender, EventArgs e)
        {
            CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);

            toolStripButton_ToggleAutoScrolling.Checked = !toolStripButton_ToggleAutoScrolling.Checked;
            TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrolling = !TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrolling;

            toolStripTextBox_AutoScrollingX.Enabled = toolStripButton_ToggleAutoScrolling.Checked;
            toolStripTextBox_AutoScrollingY.Enabled = toolStripButton_ToggleAutoScrolling.Checked;
        }

        private void toolStripButton_TogglePassable_Click(object sender, EventArgs e)
        {
            ResetToolStripEditingButtons();

            toolStripButton_TogglePassable.Checked = !toolStripButton_TogglePassable.Checked;
            Game.SetPassable = !toolStripButton_TogglePassable.Checked;
        }

        private void toolStripButton_Undo_Click(object sender, EventArgs e)
        {
            RestorePreviousState(_UndoCollection, _RedoCollection);
        }
        #endregion

        #region Combo
        private void toolStripComboBox_CodeValues_DropDown(object sender, EventArgs e)
        {
            Game.CheckUpdateMethod = false;
        }

        private void toolStripComboBox_CodeValues_DropDownClosed(object sender, EventArgs e)
        {
            Game.CheckUpdateMethod = true;
        }

        private void toolStripComboBox_CodeValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox_CodeValues.Items[toolStripComboBox_CodeValues.SelectedIndex].ToString())
            {
                case "Clean":
                    toolStripTextBox_CodeValue.Text = string.Empty;
                    break;

                case "Enemy":
                    toolStripTextBox_CodeValue.Text = "ENEMY";
                    break;

                case "Enemy Block":
                    toolStripTextBox_CodeValue.Text = "BLOCK";
                    break;

                case "Finish":
                    toolStripTextBox_CodeValue.Text = "FINISH";
                    break;

                case "Lethal":
                    toolStripTextBox_CodeValue.Text = "DEAD";
                    break;

                case "Start":
                    toolStripTextBox_CodeValue.Text = "START";
                    break;

                default:
                    toolStripTextBox_CodeValue.Text = toolStripComboBox_CodeValues.Items[toolStripComboBox_CodeValues.SelectedIndex].ToString();
                    break;
            }

            toolStripTextBox_CodeValue_Leave(null, null);
        }
        #endregion

        #region Text Box
        private void toolStripTextBox_AutoScrolling_Leave(object sender, EventArgs e)
        {
            if (((ToolStripTextBox)sender).Text != string.Empty)
            {
                toolStripTextBox_AutoScrollingX.Text = toolStripTextBox_AutoScrollingX.Text.Replace('.', ',');
                toolStripTextBox_AutoScrollingY.Text = toolStripTextBox_AutoScrollingY.Text.Replace('.', ',');

                float.TryParse(toolStripTextBox_AutoScrollingX.Text, out _CurrentLayerAutoScrollingX);
                float.TryParse(toolStripTextBox_AutoScrollingY.Text, out _CurrentLayerAutoScrollingY);

                toolStripTextBox_AutoScrollingX.Text = _CurrentLayerAutoScrollingX.ToString();
                toolStripTextBox_AutoScrollingY.Text = _CurrentLayerAutoScrollingY.ToString();

                CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);

                TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrollingVelocity = new Vector2(_CurrentLayerAutoScrollingX, _CurrentLayerAutoScrollingY);
            }
        }

        private void toolStripTextBox_AlphaValue_Leave(object sender, EventArgs e)
        {
            if (toolStripTextBox_AlphaValue.Text != string.Empty)
            {
                toolStripTextBox_AlphaValue.Text = toolStripTextBox_AlphaValue.Text.Replace('.', ',');

                float _AlphaValue = TileMap.MapLayerCollection[TileMap.CurrentLayer].AlphaValue;
                float.TryParse(toolStripTextBox_AlphaValue.Text, out _AlphaValue);

                CreateSerializableTileMap(TileMap.CurrentLayer, _UndoCollection);

                if (_AlphaValue > 1)
                    _AlphaValue /= 100;

                TileMap.MapLayerCollection[TileMap.CurrentLayer].AlphaValue = MathHelper.Clamp(_AlphaValue, 0.0f, 1.0f);
                toolStripTextBox_AlphaValue.Text = TileMap.MapLayerCollection[TileMap.CurrentLayer].AlphaValue.ToString();
            }
        }

        private void toolStripTextBox_CodeValue_Leave(object sender, EventArgs e)
        {
            Game.CurrentCodeValue = toolStripTextBox_CodeValue.Text;
            toolStripButton_CodeValue.Checked = false;

            toolStripButton_CodeValue_Click(null, null);
        }

        private void toolStripTextBox_Gravity_Leave(object sender, EventArgs e)
        {
            if (((ToolStripTextBox)sender).Text != string.Empty)
            {
                toolStripTextBox_GravityX.Text = toolStripTextBox_GravityX.Text.Replace('.', ',');
                toolStripTextBox_GravityY.Text = toolStripTextBox_GravityY.Text.Replace('.', ',');

                float.TryParse(toolStripTextBox_GravityX.Text, out _GravityX);
                float.TryParse(toolStripTextBox_GravityY.Text, out _GravityY);

                toolStripTextBox_GravityX.Text = _GravityX.ToString();
                toolStripTextBox_GravityY.Text = _GravityY.ToString();

                Game.CurrentGravity = new Vector2(_GravityX, _GravityY);

                // The false value is setted so the Event set it as "Checked".
                toolStripButton_Gravity.Checked = false;

                toolStripButton_Gravity_Click(null, null);
            }
        }
        #endregion

        #region Mouse Buttons
        private void toolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            Game.CheckUpdateMethod = false;
        }

        private void toolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            Game.CheckUpdateMethod = true;
        }
        #endregion
        #endregion
        #endregion

        #region Private Methods
        #region Custom Windows Methods
        private void ShowCustomWindow(UserControl userControl, string windowTitle)
        {
            ShowCustomWindow(userControl, false, windowTitle, string.Empty);
        }

        private void ShowCustomWindow(UserControl userControl, bool cancelButtonVisible, string windowTitle)
        {
            ShowCustomWindow(userControl, cancelButtonVisible, windowTitle, string.Empty);
        }

        private void ShowCustomWindow(UserControl userControl, bool cancelButtonVisible, string windowTitle, string groupBoxTitle)
        {
            _CustomWindow = new CustomWindow(userControl, cancelButtonVisible, windowTitle, groupBoxTitle);

            _CustomWindow.button_Accept.Click += new EventHandler(button_Accept_Click);
            _CustomWindow.button_Cancel.Click += new EventHandler(button_Cancel_Click);
            _CustomWindow.FormClosed += new FormClosedEventHandler(CustomWindow_FormClosed);
            _CustomWindow.FormClosing += new FormClosingEventHandler(CustomWindow_FormClosing);
            _CustomWindow.Show();
        }

        private DialogResult ShowOKMessageBox(string message)
        {
            return MessageBox.Show(message, ApplicationStrings.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private DialogResult ShowYesNoMessageBox(string message)
        {
            return MessageBox.Show(message, ApplicationStrings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }
        #endregion

        #region File Dialog Private Methods
        private void OpenMapFile()
        {
            _OpenFileDialog.Title = ApplicationStrings.LoadMap;
            _OpenFileDialog.Filter = ApplicationStrings.XmlFileFilter;

            if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
                OpenMapFile(_OpenFileDialog.FileName);
        }

        private void OpenMapFile(string fileName)
        {
            bool operationSuccessful = true;
            try
            {
                operationSuccessful = TileMap.LoadMap(new FileStream(fileName, FileMode.Open));

                _FormattedMapName = System.IO.Path.GetFileName(fileName);
                _FileName = fileName;
            }
            catch
            {
                TileMap.ClearMap();
                operationSuccessful = false;
            }

            if (!operationSuccessful)
                ShowOKMessageBox(ApplicationStrings.UnableToLoadFile);
            else
            {
                TileMap.CurrentLayer = 0;
                FixScrollBarScales();

                _UndoCollection.Clear();
                _RedoCollection.Clear();
                Game.HasPendingChanges = false;
            }
        }

        private void OpenTileSheetFile()
        {
            _OpenFileDialog.Title = ApplicationStrings.LoadTileSheet;
            _OpenFileDialog.Filter = ApplicationStrings.TileSheetFileFilter;

            if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
                LoadTileSheet(_OpenFileDialog.FileName);
        }

        private void SaveMapFile()
        {
            TileMap.SaveMap(new FileStream(_FileName, FileMode.Create));

            _UndoCollection.Clear();
            _RedoCollection.Clear();
            Game.HasPendingChanges = false;
        }

        private void SaveMapFileAs()
        {
            if (!string.IsNullOrEmpty(_FileName))
                _SaveFileDialog.FileName = System.IO.Path.GetFileName(_FileName);

            if (_SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _FormattedMapName = System.IO.Path.GetFileName(_SaveFileDialog.FileName);
                _FileName = _SaveFileDialog.FileName;
                SaveMapFile();
            }
        }
        #endregion

        #region General Map Editor Methods
        private void AddCodeValuesCombo(string[] codeValues)
        {
            for (int x = 0; x < codeValues.Length; x++)
            {
                if (codeValues[x] == ApplicationStrings.ClearComboKey)
                {
                    toolStripComboBox_CodeValues.Items.Clear();
                    continue;
                }

                toolStripComboBox_CodeValues.Items.Add(codeValues[x]);
            }
        }

        private Texture2D BitmapToTexture2D(GraphicsDevice graphicsDevice, Bitmap bitmapImage)
        {
            // Buffer size is size of color array multiplied by 4 because each pixel has four color bytes.
            int bufferSize = bitmapImage.Height * bitmapImage.Width * 4;

            // Create new memory stream and save image to stream so we don't have to save and read file.
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bufferSize);
            bitmapImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            // Creates a texture from IO.Stream - our memory stream.
            return Texture2D.FromStream(graphicsDevice, memoryStream);
        }

        private void CheckControlsState()
        {
            if (this.Enabled)
            {
                // It checks/unchecks the toolStripMenuItem accordingly to the visibility of the layer on the TileMap.
                hideCurrentLayerToolStripMenuItem.Checked = !TileMap.MapLayerCollection[TileMap.CurrentLayer].ShowLayer;

                toolStripButton_ToggleAutoScrolling.Checked = TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrolling;

                toolStripButton_SwitchNextLayer.Enabled = TileMap.CurrentLayer < TileMap.MapLayers - 1;
                toolStripButton_SwitchPreviousLayer.Enabled = TileMap.CurrentLayer > 0;

                clearLayerToolStripMenuItem.Enabled = TileMap.MapLayers > 1;
                copyLayerToolStripMenuItem.Enabled = TileMap.MapLayers > 1;
                removeCurrentLayerToolStripMenuItem.Enabled = TileMap.MapLayers > 1;
                removeLayerToolStripMenuItem.Enabled = TileMap.MapLayers > 1;

                undoToolStripMenuItem.Enabled = toolStripButton_Undo.Enabled = _UndoCollection.Count > 0;
                redoToolStripMenuItem.Enabled = toolStripButton_Redo.Enabled = _RedoCollection.Count > 0;

                toolStripButton_SaveMap.Enabled = saveMapToolStripMenuItem.Enabled = _UndoCollection.Count > 0 || Game.HasPendingChanges;

                toolStripTextBox_AutoScrollingX.Enabled = toolStripTextBox_AutoScrollingY.Enabled = toolStripButton_ToggleAutoScrolling.Checked;
            }
        }

        private void CreateNewMap()
        {
            if (!MapHasPendingChanges())
                ShowCustomWindow(
                    new NewMapUserControl(
                        _FormattedMapName,
                        TileMap.MapLayers,
                        (int)TileMap.Gravity.X,
                        (int)TileMap.Gravity.Y,
                        TileMap.MapWidth,
                        TileMap.MapHeight,
                        TileMap.TileWidth,
                        TileMap.TileHeight),
                    true,
                    ApplicationStrings.NewMapCustomWindowTitle);
        }

        private void ExitApplication()
        {
            Game.Exit();
            Application.Exit();
        }

        private void FillLayer(int layerNumber)
        {
            CreateSerializableTileMap(layerNumber, _UndoCollection);

            if (Game.DrawTile > -1)
                TileMap.FillLayer(layerNumber, Game.DrawTile);
            else
                TileMap.FillLayer(layerNumber, Game.DrawTileCollection);
        }

        private void FixScrollBarScales()
        {
            Camera.ViewPortWidth = pctSurface.Width;
            Camera.ViewPortHeight = pctSurface.Height;
            Camera.Move(Vector2.Zero);

            vScrollBar_pctSurface.Minimum = 0;
            vScrollBar_pctSurface.Maximum = Camera.WorldRectangle.Height - Camera.ViewPortHeight > 0 ? Camera.WorldRectangle.Height - Camera.ViewPortHeight : 0;

            hScrollBar_pctSurface.Minimum = 0;
            hScrollBar_pctSurface.Maximum = Camera.WorldRectangle.Width - Camera.ViewPortWidth > 0 ? Camera.WorldRectangle.Width - Camera.ViewPortWidth : 0;
        }

        private int GetTileNumber(int positionX, int positionY)
        {
            if (positionX == 0)         // If we are taking one of the tiles on the first column we multiply the y value (row) per total tiles per row.
                return (int)positionY * TileMap.TilesPerRow;
            else if (positionY == 0)    // If we are taking a tile from the first row we use the X value.
                return (int)positionX;
            else                        // If taking a random tile, we calculate how many tiles are before the selected one.
                return (int)((TileMap.TilesPerRow * positionY) + positionX);
        }

        private void LoadMap()
        {
            if (!MapHasPendingChanges())
                OpenMapFile();
        }

        private void LoadNewTileSheet()
        {
            if (TileMap.TileSheet != null &&
                ShowYesNoMessageBox(ApplicationStrings.LoadNewTileSheetMsgBoxText) != DialogResult.Yes)
                return;

            _TileSheetSelection = new System.Drawing.Rectangle(0, 0, 0, 0);
            OpenTileSheetFile();
        }

        private void LoadTileSheet(string fileName)
        {
            try
            {
                TileMap.TileSheet = BitmapToTexture2D(Game.GraphicsDevice, new Bitmap(fileName));
                pictureBox_TileSheet.Image = new Bitmap(fileName);
                pictureBox_TileSheet.Size = new System.Drawing.Size(TileMap.TileSheet.Width, TileMap.TileSheet.Height);
            }
            catch
            {
                ShowOKMessageBox(ApplicationStrings.ErrorTileSheet);
            }

            TileMap.CurrentLayer = 0;
        }

        private bool MapHasPendingChanges()
        {
            return Game.HasPendingChanges &&
                   ShowYesNoMessageBox(ApplicationStrings.PendingChanges) == System.Windows.Forms.DialogResult.No;
        }

        private void ResetCodeValuesCombo()
        {
            toolStripComboBox_CodeValues.Items.Clear();
            toolStripComboBox_CodeValues.Items.Add(ApplicationStrings.Clean);
            //toolStripComboBox_CodeValues.Items.Add(ApplicationStrings.Enemy);
            toolStripComboBox_CodeValues.Items.Add(ApplicationStrings.EnemyBlocking);
            toolStripComboBox_CodeValues.Items.Add(ApplicationStrings.Finish);
            toolStripComboBox_CodeValues.Items.Add(ApplicationStrings.Lethal);
            toolStripComboBox_CodeValues.Items.Add(ApplicationStrings.Start);

            toolStripTextBox_CodeValue.Text = string.Empty;
        }

        private void ResetToolStripEditingButtons()
        {
            toolStripButton_Gravity.Checked = false;
            toolStripButton_CodeValue.Checked = false;
            toolStripButton_TogglePassable.Checked = false;
            toolStripButton_FillRectangle.Checked = false;

            Game.EditingFillRectangle = false;
            Game.EditingGravity = false;
            Game.EditingCode = false;
            Game.SetPassable = true;

            Game.FillingRectangle = Microsoft.Xna.Framework.Rectangle.Empty;

            toolStripTextBox_CodeValue.Enabled = false;
            toolStripTextBox_GravityX.Enabled = toolStripTextBox_GravityY.Enabled = false;
        }

        private void SaveMap()
        {
            if (_FormattedMapName != string.Empty && _FormattedMapName != ApplicationStrings.UnknownMap)
                _SaveFileDialog.FileName = _FormattedMapName + ".XML";

            if (!string.IsNullOrEmpty(_FileName))
                SaveMapFile();
            else
                SaveMapFileAs();
        }

        private void ShowGameParameters(Vector2 mouseLocation)
        {
            toolStripLabel_CurrentLayer.Text = string.Format("{0} / {1}", (TileMap.CurrentLayer + 1).ToString(), TileMap.MapLayers.ToString());

            label_LayerVisibility.Text = TileMap.MapLayerCollection[TileMap.CurrentLayer].ShowLayer.ToString();

            if (!toolStripTextBox_AlphaValue.Focused &&
                (toolStripTextBox_AlphaValue.Text == string.Empty || toolStripTextBox_AlphaValue.Text != TileMap.MapLayerCollection[TileMap.CurrentLayer].AlphaValue.ToString()))
                toolStripTextBox_AlphaValue.Text = TileMap.MapLayerCollection[TileMap.CurrentLayer].AlphaValue.ToString();

            if (!toolStripTextBox_GravityX.Focused && toolStripTextBox_GravityX.Text == string.Empty)
                toolStripTextBox_GravityX.Text = TileMap.Gravity.X.ToString();

            if (!toolStripTextBox_GravityY.Focused && toolStripTextBox_GravityY.Text == string.Empty)
                toolStripTextBox_GravityY.Text = TileMap.Gravity.Y.ToString();

            if (!toolStripTextBox_AutoScrollingX.Focused &&
                (toolStripTextBox_AutoScrollingX.Text == string.Empty || toolStripTextBox_AutoScrollingX.Text != TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrollingVelocity.X.ToString()))
                toolStripTextBox_AutoScrollingX.Text = TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrollingVelocity.X.ToString();

            if (!toolStripTextBox_AutoScrollingY.Focused &&
                (toolStripTextBox_AutoScrollingY.Text == string.Empty || toolStripTextBox_AutoScrollingY.Text != TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrollingVelocity.Y.ToString()))
                toolStripTextBox_AutoScrollingY.Text = TileMap.MapLayerCollection[TileMap.CurrentLayer].AutoScrollingVelocity.Y.ToString();

            // It checks the Camera's ViewPort in case the pointer is outside the real Game screen AND WorldRectangle in case the map is smaller than the Game screen.
            if (tabControl_Editor.SelectedTab == tabPage_Map &&
                Camera.ViewPort.Contains((int)mouseLocation.X, (int)mouseLocation.Y) &&
                Camera.WorldRectangle.Contains((int)mouseLocation.X, (int)mouseLocation.Y))
            {
                Vector2 currentCell = TileMap.GetCellByPixel(new Vector2(mouseLocation.X, mouseLocation.Y));
                label_MapCell.Text = string.Format(ApplicationStrings.Coordinates, currentCell.X, currentCell.Y);

                Vector2 currentCellCenter = TileMap.GetCellCenter(currentCell);
                label_MapCoordinates.Text = string.Format(ApplicationStrings.Coordinates, currentCellCenter.X, currentCellCenter.Y);

                MapSquare mapSquare = TileMap.GetMapSquareAtCell((int)currentCell.X, (int)currentCell.Y, TileMap.CurrentLayer);

                if (mapSquare != null)
                {
                    label_SquareCode.Text = mapSquare.CodeValue;
                    label_SquarePassable.Text = mapSquare.Passable.ToString();
                }
            }
            else
            {
                label_MapCell.Text =
                    label_MapCoordinates.Text =
                    label_SquareCode.Text =
                    label_SquarePassable.Text = ApplicationStrings.Line;
            }
        }
        #endregion

        #region Serialization On Memory
        private void CreateSerializableTileMap(int? layerNumber, System.Collections.Generic.List<StringWriter> changedList)
        {
            Game.HasPendingChanges = true;

            MapLayer[] _MapLayer;

            if (layerNumber != null)
            {
                _MapLayer = new MapLayer[1];
                _MapLayer[0] = TileMap.MapLayerCollection[layerNumber.Value];
            }
            else
                _MapLayer = TileMap.MapLayerCollection;

            changedList.Add(SerializeChanges(
                new SerializableTileMap(TileMap.MapLayers, TileMap.MapWidth, TileMap.MapHeight, TileMap.TileWidth, TileMap.TileHeight, TileMap.Gravity, _MapLayer)));

            if (changedList.Count > _MaxUndoRedoItems)
                changedList.RemoveAt(0);
        }

        private SerializableTileMap DeserializeChanges(StringWriter serializedTileMap)
        {
            System.Xml.Serialization.XmlSerializer _XmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SerializableTileMap));
            return _XmlSerializer.Deserialize(new StringReader(serializedTileMap.ToString())) as SerializableTileMap;
        }

        private void RestorePreviousState(System.Collections.Generic.List<StringWriter> previousStateList, System.Collections.Generic.List<StringWriter> currentStateList)
        {
            if (previousStateList.Count > 0)
            {
                CreateSerializableTileMap(null, currentStateList);

                SerializableTileMap _SerializableTileMap = DeserializeChanges(previousStateList[previousStateList.Count - 1]);

                #region Restoration
                if (_SerializableTileMap.SerializableMapLayerCollection.Length == 1)
                    TileMap.LoadLayer(_SerializableTileMap, 0);
                else if (_SerializableTileMap.SerializableMapLayerCollection.Length > 1)
                    TileMap.LoadMap(_SerializableTileMap);
                #endregion

                previousStateList.RemoveAt(previousStateList.Count - 1);
            }
        }

        private StringWriter SerializeChanges(SerializableTileMap serializableTileMap)
        {
            StringWriter _StringWriter = new StringWriter();

            System.Xml.Serialization.XmlSerializer _XmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SerializableTileMap));
            _XmlSerializer.Serialize(_StringWriter, serializableTileMap);

            return _StringWriter;
        }
        #endregion

        #region XML Content Creator
        public string GetMapXmlString(string fileName)
        {
            // Load the xml file into XmlDocument object.
            System.Xml.XmlDocument _XmlDocument = new System.Xml.XmlDocument();

            try
            {
                _XmlDocument.Load(fileName);
            }
            catch (System.Xml.XmlException e)
            {
                return e.Message;
            }

            string _FormattedXmlDocument = string.Empty;

            foreach (System.Xml.XmlNode xmlNode in _XmlDocument.ChildNodes)
                _FormattedXmlDocument = _FormattedXmlDocument + FormatXml(xmlNode) + "\n";

            return _FormattedXmlDocument;
        }

        private string FormatXml(System.Xml.XmlNode xmlNode)
        {
            System.Text.StringBuilder _XmlNode = new System.Text.StringBuilder();

            // We will use _StringWriter to push the formated xml into our StringBuilder _XmlNode.
            using (StringWriter _StringWriter = new StringWriter(_XmlNode))
            {
                // We will use the Formatting of our _XmlTextWriter to provide our indentation.
                using (System.Xml.XmlTextWriter _XmlTextWriter = new System.Xml.XmlTextWriter(_StringWriter))
                {
                    _XmlTextWriter.Formatting = System.Xml.Formatting.Indented;
                    xmlNode.WriteTo(_XmlTextWriter);
                }
            }

            return _XmlNode.ToString();
        }
        #endregion
        #endregion        
    }
}