namespace MapEditor2
{
    partial class LevelEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.tabControl_Editor = new System.Windows.Forms.TabControl();
            this.tabPage_Map = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.vScrollBar_pctSurface = new System.Windows.Forms.VScrollBar();
            this.hScrollBar_pctSurface = new System.Windows.Forms.HScrollBar();
            this.pctSurface = new System.Windows.Forms.PictureBox();
            this.tabPage_XML = new System.Windows.Forms.TabPage();
            this.richTextBox_XML = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_LayerVisibility = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_SquarePassable = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_SquareCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_MapCell = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_MapCoordinates = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadNewTileSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.addCodesToCodeValuesComboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCodeValuesComboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilePreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.passableBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gravityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideCurrentLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redimensionMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redimensionTileSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.modifyMapGravityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyPassableToAllLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.fillLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillCurrentLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCurrentLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMapEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_NewMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_LoadMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_SaveMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_LoadTileSheet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Undo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_SwitchPreviousLayer = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_CurrentLayer = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_SwitchNextLayer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_TintColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_AlphaValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ToggleAutoScrolling = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox_AutoScrollingX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_AutoScrollingY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_TogglePassable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FillRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Gravity = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox_GravityX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_GravityY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_CodeValue = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox_CodeValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox_CodeValues = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.GameUpdate_Timer = new System.Windows.Forms.Timer(this.components);
            this.panel_TileSheet = new System.Windows.Forms.Panel();
            this.pictureBox_TileSheet = new System.Windows.Forms.PictureBox();
            this.tabControl_Editor.SuspendLayout();
            this.tabPage_Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).BeginInit();
            this.tabPage_XML.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel_TileSheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TileSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Editor
            // 
            this.tabControl_Editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Editor.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl_Editor.Controls.Add(this.tabPage_Map);
            this.tabControl_Editor.Controls.Add(this.tabPage_XML);
            this.tabControl_Editor.Location = new System.Drawing.Point(0, 52);
            this.tabControl_Editor.Name = "tabControl_Editor";
            this.tabControl_Editor.SelectedIndex = 0;
            this.tabControl_Editor.Size = new System.Drawing.Size(662, 558);
            this.tabControl_Editor.TabIndex = 1;
            this.tabControl_Editor.SelectedIndexChanged += new System.EventHandler(this.tabControl_Editor_SelectedIndexChanged);
            // 
            // tabPage_Map
            // 
            this.tabPage_Map.Controls.Add(this.label3);
            this.tabPage_Map.Controls.Add(this.vScrollBar_pctSurface);
            this.tabPage_Map.Controls.Add(this.hScrollBar_pctSurface);
            this.tabPage_Map.Controls.Add(this.pctSurface);
            this.tabPage_Map.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Map.Name = "tabPage_Map";
            this.tabPage_Map.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Map.Size = new System.Drawing.Size(654, 529);
            this.tabPage_Map.TabIndex = 0;
            this.tabPage_Map.Text = "MAP";
            this.tabPage_Map.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(636, 511);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = " ";
            // 
            // vScrollBar_pctSurface
            // 
            this.vScrollBar_pctSurface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar_pctSurface.LargeChange = 2;
            this.vScrollBar_pctSurface.Location = new System.Drawing.Point(635, 0);
            this.vScrollBar_pctSurface.Name = "vScrollBar_pctSurface";
            this.vScrollBar_pctSurface.Size = new System.Drawing.Size(17, 508);
            this.vScrollBar_pctSurface.SmallChange = 2;
            this.vScrollBar_pctSurface.TabIndex = 2;
            this.vScrollBar_pctSurface.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_pctSurface_Scroll);
            // 
            // hScrollBar_pctSurface
            // 
            this.hScrollBar_pctSurface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar_pctSurface.LargeChange = 2;
            this.hScrollBar_pctSurface.Location = new System.Drawing.Point(0, 511);
            this.hScrollBar_pctSurface.Name = "hScrollBar_pctSurface";
            this.hScrollBar_pctSurface.Size = new System.Drawing.Size(632, 17);
            this.hScrollBar_pctSurface.SmallChange = 2;
            this.hScrollBar_pctSurface.TabIndex = 1;
            this.hScrollBar_pctSurface.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_pctSurface_Scroll);
            // 
            // pctSurface
            // 
            this.pctSurface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctSurface.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pctSurface.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctSurface.Location = new System.Drawing.Point(0, 0);
            this.pctSurface.Name = "pctSurface";
            this.pctSurface.Size = new System.Drawing.Size(632, 508);
            this.pctSurface.TabIndex = 0;
            this.pctSurface.TabStop = false;
            this.pctSurface.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctSurface_MouseDown);
            this.pctSurface.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctSurface_MouseUp);
            // 
            // tabPage_XML
            // 
            this.tabPage_XML.Controls.Add(this.richTextBox_XML);
            this.tabPage_XML.Location = new System.Drawing.Point(4, 25);
            this.tabPage_XML.Name = "tabPage_XML";
            this.tabPage_XML.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_XML.Size = new System.Drawing.Size(654, 529);
            this.tabPage_XML.TabIndex = 1;
            this.tabPage_XML.Text = "XML";
            this.tabPage_XML.UseVisualStyleBackColor = true;
            // 
            // richTextBox_XML
            // 
            this.richTextBox_XML.AcceptsTab = true;
            this.richTextBox_XML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_XML.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox_XML.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_XML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.richTextBox_XML.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_XML.Name = "richTextBox_XML";
            this.richTextBox_XML.Size = new System.Drawing.Size(655, 490);
            this.richTextBox_XML.TabIndex = 0;
            this.richTextBox_XML.Text = global::MapEditor2.ApplicationStrings.Clear;
            this.richTextBox_XML.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label_LayerVisibility);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label_SquarePassable);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label_SquareCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label_MapCell);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label_MapCoordinates);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(1, 606);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(933, 35);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label_LayerVisibility
            // 
            this.label_LayerVisibility.AutoSize = true;
            this.label_LayerVisibility.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LayerVisibility.ForeColor = System.Drawing.Color.Black;
            this.label_LayerVisibility.Location = new System.Drawing.Point(446, 14);
            this.label_LayerVisibility.Name = "label_LayerVisibility";
            this.label_LayerVisibility.Size = new System.Drawing.Size(16, 13);
            this.label_LayerVisibility.TabIndex = 52;
            this.label_LayerVisibility.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(375, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Visible layer:";
            // 
            // label_SquarePassable
            // 
            this.label_SquarePassable.AutoSize = true;
            this.label_SquarePassable.Location = new System.Drawing.Point(791, 14);
            this.label_SquarePassable.Name = "label_SquarePassable";
            this.label_SquarePassable.Size = new System.Drawing.Size(16, 13);
            this.label_SquarePassable.TabIndex = 48;
            this.label_SquarePassable.Text = "---";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(720, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Passable:";
            // 
            // label_SquareCode
            // 
            this.label_SquareCode.AutoSize = true;
            this.label_SquareCode.Location = new System.Drawing.Point(624, 14);
            this.label_SquareCode.Name = "label_SquareCode";
            this.label_SquareCode.Size = new System.Drawing.Size(16, 13);
            this.label_SquareCode.TabIndex = 46;
            this.label_SquareCode.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Code Value:";
            // 
            // label_MapCell
            // 
            this.label_MapCell.AutoSize = true;
            this.label_MapCell.Location = new System.Drawing.Point(67, 14);
            this.label_MapCell.Name = "label_MapCell";
            this.label_MapCell.Size = new System.Drawing.Size(16, 13);
            this.label_MapCell.TabIndex = 38;
            this.label_MapCell.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Map cell:";
            // 
            // label_MapCoordinates
            // 
            this.label_MapCoordinates.AutoSize = true;
            this.label_MapCoordinates.Location = new System.Drawing.Point(259, 14);
            this.label_MapCoordinates.Name = "label_MapCoordinates";
            this.label_MapCoordinates.Size = new System.Drawing.Size(16, 13);
            this.label_MapCoordinates.TabIndex = 36;
            this.label_MapCoordinates.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Map coordinates:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.layerToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(934, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.saveMapAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadNewTileSheetToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.newMapToolStripMenuItem.Text = "New Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            this.newMapToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.newMapToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.loadMapToolStripMenuItem.Text = "Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            this.loadMapToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.loadMapToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            this.saveMapToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.saveMapToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // saveMapAsToolStripMenuItem
            // 
            this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
            this.saveMapAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.saveMapAsToolStripMenuItem.Text = "Save Map As...";
            this.saveMapAsToolStripMenuItem.Click += new System.EventHandler(this.saveMapAsToolStripMenuItem_Click);
            this.saveMapAsToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.saveMapAsToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 6);
            // 
            // loadNewTileSheetToolStripMenuItem
            // 
            this.loadNewTileSheetToolStripMenuItem.Name = "loadNewTileSheetToolStripMenuItem";
            this.loadNewTileSheetToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.loadNewTileSheetToolStripMenuItem.Text = "Load new Tile Sheet";
            this.loadNewTileSheetToolStripMenuItem.Click += new System.EventHandler(this.loadNewTileSheetToolStripMenuItem_Click);
            this.loadNewTileSheetToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.loadNewTileSheetToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(219, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.exitToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.exitToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem5,
            this.addCodesToCodeValuesComboToolStripMenuItem,
            this.resetCodeValuesComboToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            this.undoToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.undoToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            this.redoToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.redoToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(254, 6);
            // 
            // addCodesToCodeValuesComboToolStripMenuItem
            // 
            this.addCodesToCodeValuesComboToolStripMenuItem.Name = "addCodesToCodeValuesComboToolStripMenuItem";
            this.addCodesToCodeValuesComboToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.addCodesToCodeValuesComboToolStripMenuItem.Text = "Add Codes to Code Values Combo";
            this.addCodesToCodeValuesComboToolStripMenuItem.ToolTipText = "Insert Key to clean combo values: INSTRUCTION: EMPTY CODE VALUES COMBO ITEMS.";
            this.addCodesToCodeValuesComboToolStripMenuItem.Click += new System.EventHandler(this.addCodesToCodeValuesComboToolStripMenuItem_Click);
            this.addCodesToCodeValuesComboToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.addCodesToCodeValuesComboToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // resetCodeValuesComboToolStripMenuItem
            // 
            this.resetCodeValuesComboToolStripMenuItem.Name = "resetCodeValuesComboToolStripMenuItem";
            this.resetCodeValuesComboToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.resetCodeValuesComboToolStripMenuItem.Text = "Reset Code Values Combo";
            this.resetCodeValuesComboToolStripMenuItem.Click += new System.EventHandler(this.resetCodeValuesComboToolStripMenuItem_Click);
            this.resetCodeValuesComboToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.resetCodeValuesComboToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.tilePreviewToolStripMenuItem,
            this.toolStripMenuItem8,
            this.passableBlocksToolStripMenuItem,
            this.codeValuesToolStripMenuItem,
            this.gravityToolStripMenuItem,
            this.toolStripMenuItem9,
            this.showAllLayersToolStripMenuItem,
            this.hideLayerToolStripMenuItem,
            this.hideCurrentLayerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.pointedToolStripMenuItem});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.gridToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.lineToolStripMenuItem.Text = "Lined";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            this.lineToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.lineToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // pointedToolStripMenuItem
            // 
            this.pointedToolStripMenuItem.Name = "pointedToolStripMenuItem";
            this.pointedToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.pointedToolStripMenuItem.Text = "Pointed";
            this.pointedToolStripMenuItem.Click += new System.EventHandler(this.pointedToolStripMenuItem_Click);
            this.pointedToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.pointedToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // tilePreviewToolStripMenuItem
            // 
            this.tilePreviewToolStripMenuItem.Checked = true;
            this.tilePreviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tilePreviewToolStripMenuItem.Name = "tilePreviewToolStripMenuItem";
            this.tilePreviewToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.tilePreviewToolStripMenuItem.Text = "Tile Preview";
            this.tilePreviewToolStripMenuItem.Click += new System.EventHandler(this.tilePreviewToolStripMenuItem_Click);
            this.tilePreviewToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.tilePreviewToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(170, 6);
            // 
            // passableBlocksToolStripMenuItem
            // 
            this.passableBlocksToolStripMenuItem.Checked = true;
            this.passableBlocksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.passableBlocksToolStripMenuItem.Name = "passableBlocksToolStripMenuItem";
            this.passableBlocksToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.passableBlocksToolStripMenuItem.Text = "Passable Blocks";
            this.passableBlocksToolStripMenuItem.Click += new System.EventHandler(this.passableBlocksToolStripMenuItem_Click);
            this.passableBlocksToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.passableBlocksToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // codeValuesToolStripMenuItem
            // 
            this.codeValuesToolStripMenuItem.Checked = true;
            this.codeValuesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.codeValuesToolStripMenuItem.Name = "codeValuesToolStripMenuItem";
            this.codeValuesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.codeValuesToolStripMenuItem.Text = "Code Values";
            this.codeValuesToolStripMenuItem.Click += new System.EventHandler(this.codeValuesToolStripMenuItem_Click);
            this.codeValuesToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.codeValuesToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // gravityToolStripMenuItem
            // 
            this.gravityToolStripMenuItem.Name = "gravityToolStripMenuItem";
            this.gravityToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.gravityToolStripMenuItem.Text = "Gravity";
            this.gravityToolStripMenuItem.Click += new System.EventHandler(this.gravityToolStripMenuItem_Click);
            this.gravityToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.gravityToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(170, 6);
            // 
            // showAllLayersToolStripMenuItem
            // 
            this.showAllLayersToolStripMenuItem.Name = "showAllLayersToolStripMenuItem";
            this.showAllLayersToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.showAllLayersToolStripMenuItem.Text = "Show All Layers";
            this.showAllLayersToolStripMenuItem.Click += new System.EventHandler(this.showAllLayersToolStripMenuItem_Click);
            this.showAllLayersToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.showAllLayersToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // hideLayerToolStripMenuItem
            // 
            this.hideLayerToolStripMenuItem.Name = "hideLayerToolStripMenuItem";
            this.hideLayerToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.hideLayerToolStripMenuItem.Text = "Hide Layer";
            this.hideLayerToolStripMenuItem.Click += new System.EventHandler(this.hideLayerToolStripMenuItem_Click);
            this.hideLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.hideLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // hideCurrentLayerToolStripMenuItem
            // 
            this.hideCurrentLayerToolStripMenuItem.Name = "hideCurrentLayerToolStripMenuItem";
            this.hideCurrentLayerToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.hideCurrentLayerToolStripMenuItem.Text = "Hide Current Layer";
            this.hideCurrentLayerToolStripMenuItem.Click += new System.EventHandler(this.hideCurrentLayerToolStripMenuItem_Click);
            this.hideCurrentLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.hideCurrentLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redimensionMapToolStripMenuItem,
            this.redimensionTileSizeToolStripMenuItem,
            this.toolStripMenuItem3,
            this.clearMapToolStripMenuItem,
            this.toolStripMenuItem4,
            this.modifyMapGravityToolStripMenuItem,
            this.applyPassableToAllLayersToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "&Map";
            // 
            // redimensionMapToolStripMenuItem
            // 
            this.redimensionMapToolStripMenuItem.Name = "redimensionMapToolStripMenuItem";
            this.redimensionMapToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.redimensionMapToolStripMenuItem.Text = "Redimension Map Size";
            this.redimensionMapToolStripMenuItem.Click += new System.EventHandler(this.redimensionMapToolStripMenuItem_Click);
            this.redimensionMapToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.redimensionMapToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // redimensionTileSizeToolStripMenuItem
            // 
            this.redimensionTileSizeToolStripMenuItem.Name = "redimensionTileSizeToolStripMenuItem";
            this.redimensionTileSizeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.redimensionTileSizeToolStripMenuItem.Text = "Redimension Tile Size";
            this.redimensionTileSizeToolStripMenuItem.Click += new System.EventHandler(this.redimensionTileSizeToolStripMenuItem_Click);
            this.redimensionTileSizeToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.redimensionTileSizeToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(215, 6);
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.clearMapToolStripMenuItem.Text = "Clear Map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            this.clearMapToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.clearMapToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(215, 6);
            // 
            // modifyMapGravityToolStripMenuItem
            // 
            this.modifyMapGravityToolStripMenuItem.Name = "modifyMapGravityToolStripMenuItem";
            this.modifyMapGravityToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.modifyMapGravityToolStripMenuItem.Text = "Modify Map Gravity";
            this.modifyMapGravityToolStripMenuItem.Click += new System.EventHandler(this.modifyMapGravityToolStripMenuItem_Click);
            this.modifyMapGravityToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.modifyMapGravityToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // applyPassableToAllLayersToolStripMenuItem
            // 
            this.applyPassableToAllLayersToolStripMenuItem.Checked = true;
            this.applyPassableToAllLayersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.applyPassableToAllLayersToolStripMenuItem.Name = "applyPassableToAllLayersToolStripMenuItem";
            this.applyPassableToAllLayersToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.applyPassableToAllLayersToolStripMenuItem.Text = "Apply Passable to all Layers";
            this.applyPassableToAllLayersToolStripMenuItem.Click += new System.EventHandler(this.applyPassableToAllLayersToolStripMenuItem_Click);
            this.applyPassableToAllLayersToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.applyPassableToAllLayersToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // layerToolStripMenuItem
            // 
            this.layerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLayerToolStripMenuItem,
            this.removeLayerToolStripMenuItem,
            this.removeCurrentLayerToolStripMenuItem,
            this.toolStripMenuItem6,
            this.fillLayerToolStripMenuItem,
            this.fillCurrentLayerToolStripMenuItem,
            this.copyLayerToolStripMenuItem,
            this.clearLayerToolStripMenuItem,
            this.clearCurrentLayerToolStripMenuItem});
            this.layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            this.layerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.layerToolStripMenuItem.Text = "&Layer";
            // 
            // addLayerToolStripMenuItem
            // 
            this.addLayerToolStripMenuItem.Name = "addLayerToolStripMenuItem";
            this.addLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addLayerToolStripMenuItem.Text = "Add Layer";
            this.addLayerToolStripMenuItem.Click += new System.EventHandler(this.addLayerToolStripMenuItem_Click);
            this.addLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.addLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // removeLayerToolStripMenuItem
            // 
            this.removeLayerToolStripMenuItem.Name = "removeLayerToolStripMenuItem";
            this.removeLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.removeLayerToolStripMenuItem.Text = "Remove Layer";
            this.removeLayerToolStripMenuItem.Click += new System.EventHandler(this.removeLayerToolStripMenuItem_Click);
            this.removeLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.removeLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // removeCurrentLayerToolStripMenuItem
            // 
            this.removeCurrentLayerToolStripMenuItem.Name = "removeCurrentLayerToolStripMenuItem";
            this.removeCurrentLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.removeCurrentLayerToolStripMenuItem.Text = "Remove Current Layer";
            this.removeCurrentLayerToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentLayerToolStripMenuItem_Click);
            this.removeCurrentLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.removeCurrentLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(188, 6);
            // 
            // fillLayerToolStripMenuItem
            // 
            this.fillLayerToolStripMenuItem.Name = "fillLayerToolStripMenuItem";
            this.fillLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.fillLayerToolStripMenuItem.Text = "Fill Layer";
            this.fillLayerToolStripMenuItem.Click += new System.EventHandler(this.fillLayerToolStripMenuItem_Click);
            this.fillLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.fillLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // fillCurrentLayerToolStripMenuItem
            // 
            this.fillCurrentLayerToolStripMenuItem.Name = "fillCurrentLayerToolStripMenuItem";
            this.fillCurrentLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.fillCurrentLayerToolStripMenuItem.Text = "Fill Current Layer";
            this.fillCurrentLayerToolStripMenuItem.Click += new System.EventHandler(this.fillCurrentLayerToolStripMenuItem_Click);
            this.fillCurrentLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.fillCurrentLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // copyLayerToolStripMenuItem
            // 
            this.copyLayerToolStripMenuItem.Name = "copyLayerToolStripMenuItem";
            this.copyLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.copyLayerToolStripMenuItem.Text = "Copy Layer";
            this.copyLayerToolStripMenuItem.Click += new System.EventHandler(this.copyLayerToolStripMenuItem_Click);
            this.copyLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.copyLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // clearLayerToolStripMenuItem
            // 
            this.clearLayerToolStripMenuItem.Name = "clearLayerToolStripMenuItem";
            this.clearLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.clearLayerToolStripMenuItem.Text = "Clear Layer";
            this.clearLayerToolStripMenuItem.Click += new System.EventHandler(this.clearLayerToolStripMenuItem_Click);
            this.clearLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.clearLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // clearCurrentLayerToolStripMenuItem
            // 
            this.clearCurrentLayerToolStripMenuItem.Name = "clearCurrentLayerToolStripMenuItem";
            this.clearCurrentLayerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.clearCurrentLayerToolStripMenuItem.Text = "Clear Current Layer";
            this.clearCurrentLayerToolStripMenuItem.Click += new System.EventHandler(this.clearCurrentLayerToolStripMenuItem_Click);
            this.clearCurrentLayerToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.clearCurrentLayerToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.toolStripMenuItem10,
            this.aboutMapEditorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Enabled = false;
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            this.viewHelpToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.viewHelpToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutMapEditorToolStripMenuItem
            // 
            this.aboutMapEditorToolStripMenuItem.Name = "aboutMapEditorToolStripMenuItem";
            this.aboutMapEditorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutMapEditorToolStripMenuItem.Text = "About Map Editor";
            this.aboutMapEditorToolStripMenuItem.Click += new System.EventHandler(this.aboutMapEditorToolStripMenuItem_Click);
            this.aboutMapEditorToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseDown);
            this.aboutMapEditorToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_NewMap,
            this.toolStripButton_LoadMap,
            this.toolStripButton_SaveMap,
            this.toolStripButton_LoadTileSheet,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton_Undo,
            this.toolStripButton_Redo,
            this.toolStripSeparator10,
            this.toolStripSeparator11,
            this.toolStripButton_SwitchPreviousLayer,
            this.toolStripLabel_CurrentLayer,
            this.toolStripButton_SwitchNextLayer,
            this.toolStripSeparator12,
            this.toolStripButton_TintColor,
            this.toolStripSeparator8,
            this.toolStripTextBox_AlphaValue,
            this.toolStripSeparator9,
            this.toolStripButton_ToggleAutoScrolling,
            this.toolStripTextBox_AutoScrollingX,
            this.toolStripLabel1,
            this.toolStripTextBox_AutoScrollingY,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.toolStripButton_TogglePassable,
            this.toolStripSeparator13,
            this.toolStripButton_FillRectangle,
            this.toolStripSeparator5,
            this.toolStripButton_Gravity,
            this.toolStripTextBox_GravityX,
            this.toolStripLabel2,
            this.toolStripTextBox_GravityY,
            this.toolStripSeparator6,
            this.toolStripButton_CodeValue,
            this.toolStripTextBox_CodeValue,
            this.toolStripComboBox_CodeValues,
            this.toolStripSeparator7});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(934, 25);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_NewMap
            // 
            this.toolStripButton_NewMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_NewMap.Image = global::MapEditor2.ImageResources.New;
            this.toolStripButton_NewMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_NewMap.Name = "toolStripButton_NewMap";
            this.toolStripButton_NewMap.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_NewMap.Text = "New Map";
            this.toolStripButton_NewMap.ToolTipText = "New Map - Ctrl + N";
            this.toolStripButton_NewMap.Click += new System.EventHandler(this.toolStripButton_NewMap_Click);
            // 
            // toolStripButton_LoadMap
            // 
            this.toolStripButton_LoadMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_LoadMap.Image = global::MapEditor2.ImageResources.Load;
            this.toolStripButton_LoadMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_LoadMap.Name = "toolStripButton_LoadMap";
            this.toolStripButton_LoadMap.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_LoadMap.Text = "Load Map";
            this.toolStripButton_LoadMap.ToolTipText = "Load Map - Ctrl + L";
            this.toolStripButton_LoadMap.Click += new System.EventHandler(this.toolStripButton_LoadMap_Click);
            // 
            // toolStripButton_SaveMap
            // 
            this.toolStripButton_SaveMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SaveMap.Image = global::MapEditor2.ImageResources.Save;
            this.toolStripButton_SaveMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SaveMap.Name = "toolStripButton_SaveMap";
            this.toolStripButton_SaveMap.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_SaveMap.Text = "Save Map";
            this.toolStripButton_SaveMap.ToolTipText = "Save Map - Ctrl + S";
            this.toolStripButton_SaveMap.Click += new System.EventHandler(this.toolStripButton_SaveMap_Click);
            // 
            // toolStripButton_LoadTileSheet
            // 
            this.toolStripButton_LoadTileSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_LoadTileSheet.Image = global::MapEditor2.ImageResources.Tiles;
            this.toolStripButton_LoadTileSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_LoadTileSheet.Name = "toolStripButton_LoadTileSheet";
            this.toolStripButton_LoadTileSheet.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_LoadTileSheet.Text = "Load new Tile Sheet";
            this.toolStripButton_LoadTileSheet.Click += new System.EventHandler(this.toolStripButton_LoadTileSheet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_Undo
            // 
            this.toolStripButton_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Undo.Image = global::MapEditor2.ImageResources.Undo;
            this.toolStripButton_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Undo.Name = "toolStripButton_Undo";
            this.toolStripButton_Undo.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_Undo.Text = "Undo";
            this.toolStripButton_Undo.ToolTipText = "Undo - Ctrl + Z";
            this.toolStripButton_Undo.Click += new System.EventHandler(this.toolStripButton_Undo_Click);
            // 
            // toolStripButton_Redo
            // 
            this.toolStripButton_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Redo.Image = global::MapEditor2.ImageResources.Redo;
            this.toolStripButton_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Redo.Name = "toolStripButton_Redo";
            this.toolStripButton_Redo.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_Redo.Text = "Redo";
            this.toolStripButton_Redo.ToolTipText = "Redo - Ctrl + Y";
            this.toolStripButton_Redo.Click += new System.EventHandler(this.toolStripButton_Redo_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_SwitchPreviousLayer
            // 
            this.toolStripButton_SwitchPreviousLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SwitchPreviousLayer.Image = global::MapEditor2.ImageResources.GreenArrowDown;
            this.toolStripButton_SwitchPreviousLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SwitchPreviousLayer.Name = "toolStripButton_SwitchPreviousLayer";
            this.toolStripButton_SwitchPreviousLayer.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_SwitchPreviousLayer.Text = "Layer Behind";
            this.toolStripButton_SwitchPreviousLayer.Click += new System.EventHandler(this.toolStripButton_SwitchPreviousLayer_Click);
            // 
            // toolStripLabel_CurrentLayer
            // 
            this.toolStripLabel_CurrentLayer.AutoSize = false;
            this.toolStripLabel_CurrentLayer.Name = "toolStripLabel_CurrentLayer";
            this.toolStripLabel_CurrentLayer.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel_CurrentLayer.Text = "50/50";
            this.toolStripLabel_CurrentLayer.ToolTipText = "Current layer";
            // 
            // toolStripButton_SwitchNextLayer
            // 
            this.toolStripButton_SwitchNextLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SwitchNextLayer.Image = global::MapEditor2.ImageResources.GreenArrowUp;
            this.toolStripButton_SwitchNextLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SwitchNextLayer.Name = "toolStripButton_SwitchNextLayer";
            this.toolStripButton_SwitchNextLayer.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_SwitchNextLayer.Text = "Layer Ahead";
            this.toolStripButton_SwitchNextLayer.Click += new System.EventHandler(this.toolStripButton_SwitchNextLayer_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_TintColor
            // 
            this.toolStripButton_TintColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_TintColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_TintColor.Image")));
            this.toolStripButton_TintColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TintColor.Name = "toolStripButton_TintColor";
            this.toolStripButton_TintColor.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_TintColor.Text = "Layer\'s Tint Color";
            this.toolStripButton_TintColor.Click += new System.EventHandler(this.toolStripButton_TintColor_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripTextBox_AlphaValue
            // 
            this.toolStripTextBox_AlphaValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_AlphaValue.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox_AlphaValue.Name = "toolStripTextBox_AlphaValue";
            this.toolStripTextBox_AlphaValue.Size = new System.Drawing.Size(30, 22);
            this.toolStripTextBox_AlphaValue.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStripTextBox_AlphaValue.ToolTipText = "Layer\'s transparency value (0.0 - 1.0)";
            this.toolStripTextBox_AlphaValue.Leave += new System.EventHandler(this.toolStripTextBox_AlphaValue_Leave);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_ToggleAutoScrolling
            // 
            this.toolStripButton_ToggleAutoScrolling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ToggleAutoScrolling.Image = global::MapEditor2.ImageResources.AutoScroll;
            this.toolStripButton_ToggleAutoScrolling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ToggleAutoScrolling.Name = "toolStripButton_ToggleAutoScrolling";
            this.toolStripButton_ToggleAutoScrolling.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_ToggleAutoScrolling.Text = "Auto Scrolling Layer";
            this.toolStripButton_ToggleAutoScrolling.Click += new System.EventHandler(this.toolStripButton_ToggleAutoScrolling_Click);
            // 
            // toolStripTextBox_AutoScrollingX
            // 
            this.toolStripTextBox_AutoScrollingX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_AutoScrollingX.Enabled = false;
            this.toolStripTextBox_AutoScrollingX.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox_AutoScrollingX.Name = "toolStripTextBox_AutoScrollingX";
            this.toolStripTextBox_AutoScrollingX.Size = new System.Drawing.Size(30, 22);
            this.toolStripTextBox_AutoScrollingX.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStripTextBox_AutoScrollingX.ToolTipText = "Auto scrolling X value";
            this.toolStripTextBox_AutoScrollingX.Leave += new System.EventHandler(this.toolStripTextBox_AutoScrolling_Leave);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(10, 15);
            this.toolStripLabel1.Text = ",";
            // 
            // toolStripTextBox_AutoScrollingY
            // 
            this.toolStripTextBox_AutoScrollingY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_AutoScrollingY.Enabled = false;
            this.toolStripTextBox_AutoScrollingY.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox_AutoScrollingY.Name = "toolStripTextBox_AutoScrollingY";
            this.toolStripTextBox_AutoScrollingY.Size = new System.Drawing.Size(30, 22);
            this.toolStripTextBox_AutoScrollingY.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStripTextBox_AutoScrollingY.ToolTipText = "Auto scrolling Y value";
            this.toolStripTextBox_AutoScrollingY.Leave += new System.EventHandler(this.toolStripTextBox_AutoScrolling_Leave);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_TogglePassable
            // 
            this.toolStripButton_TogglePassable.Checked = true;
            this.toolStripButton_TogglePassable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton_TogglePassable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_TogglePassable.Image = global::MapEditor2.ImageResources.Passable;
            this.toolStripButton_TogglePassable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TogglePassable.Name = "toolStripButton_TogglePassable";
            this.toolStripButton_TogglePassable.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_TogglePassable.Text = "Right Click Mode: Toggle Passable";
            this.toolStripButton_TogglePassable.Click += new System.EventHandler(this.toolStripButton_TogglePassable_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_FillRectangle
            // 
            this.toolStripButton_FillRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_FillRectangle.Image = global::MapEditor2.ImageResources.FillRectangle;
            this.toolStripButton_FillRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FillRectangle.Name = "toolStripButton_FillRectangle";
            this.toolStripButton_FillRectangle.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_FillRectangle.Text = "Right Click Mode: Filling Rectangle Selection (F: Fill - U: Unfill)";
            this.toolStripButton_FillRectangle.Click += new System.EventHandler(this.toolStripButton_FillRectangle_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_Gravity
            // 
            this.toolStripButton_Gravity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Gravity.Image = global::MapEditor2.ImageResources.Gravity;
            this.toolStripButton_Gravity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Gravity.Name = "toolStripButton_Gravity";
            this.toolStripButton_Gravity.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_Gravity.Text = "Right Click Mode: Set Gravity";
            this.toolStripButton_Gravity.Click += new System.EventHandler(this.toolStripButton_Gravity_Click);
            // 
            // toolStripTextBox_GravityX
            // 
            this.toolStripTextBox_GravityX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_GravityX.Enabled = false;
            this.toolStripTextBox_GravityX.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox_GravityX.Name = "toolStripTextBox_GravityX";
            this.toolStripTextBox_GravityX.Size = new System.Drawing.Size(30, 22);
            this.toolStripTextBox_GravityX.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStripTextBox_GravityX.ToolTipText = "Gravity\'s X value";
            this.toolStripTextBox_GravityX.Leave += new System.EventHandler(this.toolStripTextBox_Gravity_Leave);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(10, 15);
            this.toolStripLabel2.Text = ",";
            // 
            // toolStripTextBox_GravityY
            // 
            this.toolStripTextBox_GravityY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_GravityY.Enabled = false;
            this.toolStripTextBox_GravityY.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox_GravityY.Name = "toolStripTextBox_GravityY";
            this.toolStripTextBox_GravityY.Size = new System.Drawing.Size(30, 22);
            this.toolStripTextBox_GravityY.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStripTextBox_GravityY.ToolTipText = "Gravity\'s Y value";
            this.toolStripTextBox_GravityY.Leave += new System.EventHandler(this.toolStripTextBox_Gravity_Leave);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton_CodeValue
            // 
            this.toolStripButton_CodeValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_CodeValue.Image = global::MapEditor2.ImageResources.Code;
            this.toolStripButton_CodeValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CodeValue.Name = "toolStripButton_CodeValue";
            this.toolStripButton_CodeValue.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_CodeValue.Text = "Right Click Mode: Set Code Value";
            this.toolStripButton_CodeValue.Click += new System.EventHandler(this.toolStripButton_CodeValue_Click);
            // 
            // toolStripTextBox_CodeValue
            // 
            this.toolStripTextBox_CodeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_CodeValue.Enabled = false;
            this.toolStripTextBox_CodeValue.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox_CodeValue.Name = "toolStripTextBox_CodeValue";
            this.toolStripTextBox_CodeValue.Size = new System.Drawing.Size(100, 22);
            this.toolStripTextBox_CodeValue.ToolTipText = "Current code value";
            this.toolStripTextBox_CodeValue.Leave += new System.EventHandler(this.toolStripTextBox_CodeValue_Leave);
            // 
            // toolStripComboBox_CodeValues
            // 
            this.toolStripComboBox_CodeValues.AutoSize = false;
            this.toolStripComboBox_CodeValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_CodeValues.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripComboBox_CodeValues.Name = "toolStripComboBox_CodeValues";
            this.toolStripComboBox_CodeValues.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox_CodeValues.ToolTipText = "Code Values Combo";
            this.toolStripComboBox_CodeValues.DropDown += new System.EventHandler(this.toolStripComboBox_CodeValues_DropDown);
            this.toolStripComboBox_CodeValues.DropDownClosed += new System.EventHandler(this.toolStripComboBox_CodeValues_DropDownClosed);
            this.toolStripComboBox_CodeValues.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_CodeValues_SelectedIndexChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // GameUpdate_Timer
            // 
            this.GameUpdate_Timer.Enabled = true;
            this.GameUpdate_Timer.Interval = 20;
            this.GameUpdate_Timer.Tick += new System.EventHandler(this.GameUpdate_Timer_Tick);
            // 
            // panel_TileSheet
            // 
            this.panel_TileSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_TileSheet.AutoScroll = true;
            this.panel_TileSheet.BackColor = System.Drawing.SystemColors.Info;
            this.panel_TileSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_TileSheet.Controls.Add(this.pictureBox_TileSheet);
            this.panel_TileSheet.Location = new System.Drawing.Point(664, 52);
            this.panel_TileSheet.Name = "panel_TileSheet";
            this.panel_TileSheet.Size = new System.Drawing.Size(265, 554);
            this.panel_TileSheet.TabIndex = 8;
            // 
            // pictureBox_TileSheet
            // 
            this.pictureBox_TileSheet.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox_TileSheet.Name = "pictureBox_TileSheet";
            this.pictureBox_TileSheet.Size = new System.Drawing.Size(22, 23);
            this.pictureBox_TileSheet.TabIndex = 0;
            this.pictureBox_TileSheet.TabStop = false;
            this.pictureBox_TileSheet.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_TileSheet_Paint);
            this.pictureBox_TileSheet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_TileSheet_MouseDown);
            this.pictureBox_TileSheet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_TileSheet_MouseUp);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 642);
            this.Controls.Add(this.panel_TileSheet);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl_Editor);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 480);
            this.Name = "LevelEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.LevelEditor_Activated);
            this.Deactivate += new System.EventHandler(this.LevelEditor_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelEditor_FormClosed);
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.Shown += new System.EventHandler(this.LevelEditor_Shown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem_MouseUp);
            this.tabControl_Editor.ResumeLayout(false);
            this.tabPage_Map.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctSurface)).EndInit();
            this.tabPage_XML.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel_TileSheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TileSheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage_XML;
        private System.Windows.Forms.VScrollBar vScrollBar_pctSurface;
        private System.Windows.Forms.HScrollBar hScrollBar_pctSurface;
        public System.Windows.Forms.PictureBox pctSurface;
        private System.Windows.Forms.RichTextBox richTextBox_XML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_LayerVisibility;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_SquarePassable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_SquareCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_MapCell;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_MapCoordinates;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadNewTileSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_NewMap;
        private System.Windows.Forms.ToolStripButton toolStripButton_LoadMap;
        private System.Windows.Forms.ToolStripButton toolStripButton_SaveMap;
        private System.Windows.Forms.ToolStripButton toolStripButton_LoadTileSheet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_SwitchPreviousLayer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CurrentLayer;
        private System.Windows.Forms.ToolStripButton toolStripButton_SwitchNextLayer;
        private System.Windows.Forms.ToolStripButton toolStripButton_ToggleAutoScrolling;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_TogglePassable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton_Gravity;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_GravityX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_GravityY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton_CodeValue;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_CodeValue;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_CodeValues;
        private System.Windows.Forms.ToolStripMenuItem redimensionMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redimensionTileSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem modifyMapGravityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyPassableToAllLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem fillLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCurrentLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem passableBlocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gravityToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem showAllLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideCurrentLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem aboutMapEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer GameUpdate_Timer;
        private System.Windows.Forms.TabControl tabControl_Editor;
        private System.Windows.Forms.TabPage tabPage_Map;
        private System.Windows.Forms.Panel panel_TileSheet;
        private System.Windows.Forms.PictureBox pictureBox_TileSheet;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_AlphaValue;
        private System.Windows.Forms.ToolStripMenuItem fillCurrentLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_AutoScrollingX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_AutoScrollingY;
        private System.Windows.Forms.ToolStripButton toolStripButton_Undo;
        private System.Windows.Forms.ToolStripButton toolStripButton_Redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton toolStripButton_TintColor;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem resetCodeValuesComboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCodesToCodeValuesComboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilePreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton toolStripButton_FillRectangle;
    }
}