using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TileMapLibrary;

namespace MapEditor2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class LevelEditorGame : Microsoft.Xna.Framework.Game
    {
        #region Declarations
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        IntPtr drawSurface;

        // WinForm
        System.Windows.Forms.Form parentForm;
        System.Windows.Forms.PictureBox pictureBox;

        // XNA window
        System.Windows.Forms.Control gameForm;

        public int DrawTile = 0;
        public int[,] DrawTileCollection;

        public Rectangle FillingRectangle = Rectangle.Empty;
        public Vector2 FillingRectangleStartingCell = Vector2.Zero;
        public Vector2 FillingRectangleEndingCell = Vector2.Zero;

        Texture2D _Pixel;

        public bool CheckUpdateMethod = true;
        public bool EditingCode = false;
        public bool SetPassable = false;
        public bool EditingGravity = false;
        public bool EditingFillRectangle = false;
        public bool HasPendingChanges = false;
        public bool ApplyPassableToAllLayers = true;

        public string CurrentCodeValue = string.Empty;
        public Vector2 CurrentGravity = Vector2.Zero;

        Vector2 _MousePointerCellLocation;
        public bool ShowTilePreview = true;

        System.Windows.Forms.VScrollBar vscroll_pctSurface;
        System.Windows.Forms.HScrollBar hscroll_pctSurface;
        #endregion

        public LevelEditorGame(IntPtr drawSurface, System.Windows.Forms.Form parentForm, System.Windows.Forms.PictureBox surfacePictureBox)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            #region Redirects the game1 class methods to the windows form
            this.drawSurface = drawSurface;
            this.parentForm = parentForm;
            this.pictureBox = surfacePictureBox;

            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);

            Mouse.WindowHandle = drawSurface;
            #endregion

            #region Changes the visibility and size behaviour to the winform
            gameForm = System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            gameForm.VisibleChanged += new EventHandler(gameForm_VisibleChanged);
            pictureBox.SizeChanged += new EventHandler(pictureBox_SizeChanged);
            #endregion

            vscroll_pctSurface = (System.Windows.Forms.VScrollBar)parentForm.Controls["tabControl_Editor"].Controls["tabPage_Map"].Controls["vScrollBar_pctSurface"];
            hscroll_pctSurface = (System.Windows.Forms.HScrollBar)parentForm.Controls["tabControl_Editor"].Controls["tabPage_Map"].Controls["hScrollBar_pctSurface"];
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO : Add all initialization logic here.

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _Pixel = new Texture2D(GraphicsDevice, 1, 1);
            _Pixel.SetData(new[] { Color.White });

            TileMap.Initialize(null, 3, 40, 11, 48, 48, GraphicsDevice);
            TileMap.SpriteFont = Content.Load<SpriteFont>(@"Fonts\Miramonte8");

            pictureBox_SizeChanged(null, null);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() { }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (CheckUpdateMethod && parentForm.Enabled && TileMap.TileSheet != null)
            {
                Camera.Position = new Vector2(hscroll_pctSurface.Value, vscroll_pctSurface.Value);
                MouseState mouseState = Mouse.GetState();

                if ((mouseState.X > 0) && (mouseState.Y > 0) &&
                    (mouseState.X < Camera.ViewPortWidth) &&
                    (mouseState.Y < Camera.ViewPortHeight))
                {
                    Vector2 mouseLocation = Camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y));

                    _MousePointerCellLocation = TileMap.GetCellByPixel(new Vector2(mouseLocation.X, mouseLocation.Y));

                    if (Camera.WorldRectangle.Contains((int)mouseLocation.X, (int)mouseLocation.Y))
                    {
                        #region When Left Ctrl is not pressed
                        if (mouseState.LeftButton == ButtonState.Pressed && Keyboard.GetState().IsKeyUp(Keys.LeftControl))
                            if (DrawTile > -1)
                            {
                                TileMap.SetTileAtCell(
                                    TileMap.GetCellByPixelX((int)mouseLocation.X),
                                    TileMap.GetCellByPixelY((int)mouseLocation.Y),
                                    TileMap.CurrentLayer,
                                    DrawTile);
                            }
                            else
                                for (int x = 0; x < DrawTileCollection.GetUpperBound(1) + 1; x++)
                                    for (int y = 0; y < DrawTileCollection.GetUpperBound(0) + 1; y++)
                                    {
                                        // The X and Y values are inverted because in jagged arrays it stores the values as [y, x].
                                        Rectangle _TileRectangle = TileMap.CellScreenRectangle((int)_MousePointerCellLocation.X + y, (int)_MousePointerCellLocation.Y + x);

                                        if (Camera.WorldRectangle.Intersects(_TileRectangle))
                                            TileMap.SetTileAtCell(
                                                (int)_MousePointerCellLocation.X + y,
                                                (int)_MousePointerCellLocation.Y + x,
                                                TileMap.CurrentLayer,
                                                DrawTileCollection[y, x]);
                                    }

                        if ((mouseState.RightButton == ButtonState.Pressed) && Keyboard.GetState().IsKeyUp(Keys.LeftControl))
                        {
                            MapSquare currentMapSquare = TileMap.GetMapSquareAtCell(TileMap.GetCellByPixelX((int)mouseLocation.X), TileMap.GetCellByPixelY((int)mouseLocation.Y), TileMap.CurrentLayer);

                            if (EditingCode)
                            {
                                currentMapSquare.CodeValue = CurrentCodeValue;
                            }
                            else if (EditingGravity)
                            {
                                currentMapSquare.Gravity = CurrentGravity;
                            }
                            else if (!EditingFillRectangle)     // Editing Passable Squares
                                if (!ApplyPassableToAllLayers)
                                    currentMapSquare.Passable = SetPassable;
                                else
                                    for (int x = 0; x < TileMap.MapLayers; x++)
                                        TileMap.GetMapSquareAtCell(
                                            TileMap.GetCellByPixelX((int)mouseLocation.X),
                                            TileMap.GetCellByPixelY((int)mouseLocation.Y),
                                            x).Passable = SetPassable;
                        }
                        #endregion

                        #region When Left Ctrl is pressed
                        if (mouseState.LeftButton == ButtonState.Pressed && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                            TileMap.SetTileAtCell(
                                TileMap.GetCellByPixelX((int)mouseLocation.X),
                                TileMap.GetCellByPixelY((int)mouseLocation.Y),
                                TileMap.CurrentLayer,
                                -1);

                        if ((mouseState.RightButton == ButtonState.Pressed) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                        {
                            MapSquare currentMapSquare = TileMap.GetMapSquareAtCell(TileMap.GetCellByPixelX((int)mouseLocation.X), TileMap.GetCellByPixelY((int)mouseLocation.Y), TileMap.CurrentLayer);

                            if (EditingCode)
                            {
                                currentMapSquare.CodeValue = String.Empty;
                            }
                            else if (EditingGravity)
                            {
                                currentMapSquare.Gravity = TileMap.Gravity;
                            }
                            else if (!EditingFillRectangle)     // Editing Passable Squares
                                if (!ApplyPassableToAllLayers)
                                    currentMapSquare.Passable = true;
                                else
                                    for (int x = 0; x < TileMap.MapLayers; x++)
                                        TileMap.GetMapSquareAtCell(
                                            TileMap.GetCellByPixelX((int)mouseLocation.X),
                                            TileMap.GetCellByPixelY((int)mouseLocation.Y),
                                            x).Passable = true;
                        }
                        #endregion
                    }
                }

                if (EditingFillRectangle &&
                    FillingRectangle != Rectangle.Empty)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.F))
                        TileMap.FillRectangle(TileMap.CurrentLayer, FillingRectangleStartingCell, FillingRectangleEndingCell, DrawTile);

                    if (Keyboard.GetState().IsKeyDown(Keys.U))
                        TileMap.FillRectangle(TileMap.CurrentLayer, FillingRectangleStartingCell, FillingRectangleEndingCell, -1);
                }
            }

            TileMap.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Begin(
                        SpriteSortMode.BackToFront,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        Camera.Zoom());
            TileMap.Draw(spriteBatch);

            #region Show Tile Preview
            if (ShowTilePreview &&
                Camera.WorldRectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                if (DrawTile > -1)
                {
                    if (Camera.WorldRectangle.Intersects(TileMap.CellScreenRectangle((int)_MousePointerCellLocation.X, (int)_MousePointerCellLocation.Y)))
                        spriteBatch.Draw(
                            TileMap.TileSheet,
                            TileMap.CellScreenRectangle((int)_MousePointerCellLocation.X, (int)_MousePointerCellLocation.Y),
                            TileMap.TileSourceRectangle(DrawTile),
                            Color.AntiqueWhite * 0.65f);
                }
                else
                {
                    for (int x = 0; x < DrawTileCollection.GetUpperBound(1) + 1; x++)
                        for (int y = 0; y < DrawTileCollection.GetUpperBound(0) + 1; y++)
                        {
                            // The X and Y values are inverted because in jagged arrays it stores them as [y, x].
                            Rectangle _TileRectangle = TileMap.CellScreenRectangle((int)_MousePointerCellLocation.X + y, (int)_MousePointerCellLocation.Y + x);

                            if (Camera.WorldRectangle.Intersects(_TileRectangle))
                            {
                                spriteBatch.Draw(
                                    TileMap.TileSheet,
                                    _TileRectangle,
                                    TileMap.TileSourceRectangle(DrawTileCollection[y, x]),
                                    Color.AntiqueWhite * 0.65f);
                            }
                        }
                }
            #endregion

            if (EditingFillRectangle &&
                FillingRectangle != Rectangle.Empty)
            {
                spriteBatch.Draw(_Pixel, new Rectangle(FillingRectangle.Left, FillingRectangle.Top, 3, FillingRectangle.Height), Color.Green);      // Left
                spriteBatch.Draw(_Pixel, new Rectangle(FillingRectangle.Left, FillingRectangle.Top, FillingRectangle.Width, 3), Color.Green);       // Top
                spriteBatch.Draw(_Pixel, new Rectangle(FillingRectangle.Right, FillingRectangle.Top, 3, FillingRectangle.Height), Color.Green);     // Right
                spriteBatch.Draw(_Pixel, new Rectangle(FillingRectangle.Left, FillingRectangle.Bottom, FillingRectangle.Width, 3), Color.Green);    // Bottom
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #region Form Related Events
        void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (parentForm.WindowState != System.Windows.Forms.FormWindowState.Minimized)
            {
                // Redimentions the "Game1" original "window"
                graphics.PreferredBackBufferWidth = pictureBox.Width;
                graphics.PreferredBackBufferHeight = pictureBox.Height;

                Camera.WorldRectangle = new Rectangle(
                0,
                0,
                TileMap.TileWidth * TileMap.MapWidth,
                TileMap.TileHeight * TileMap.MapHeight);

                //Camera.ViewPortWidth = pictureBox.Width + (int)(pictureBox.Width * Camera.ZoomAmount.X);
                //Camera.ViewPortHeight = pictureBox.Height + (int)(pictureBox.Height * Camera.ZoomAmount.Y);

                Camera.ViewPortWidth = pictureBox.Width;
                Camera.ViewPortHeight = pictureBox.Height;
                Camera.Move(Vector2.Zero);
                graphics.ApplyChanges();

                vscroll_pctSurface.Minimum = 0;
                vscroll_pctSurface.Maximum = Camera.WorldRectangle.Height - Camera.ViewPortHeight > 0 ? Camera.WorldRectangle.Height - Camera.ViewPortHeight : 0;

                hscroll_pctSurface.Minimum = 0;
                hscroll_pctSurface.Maximum = Camera.WorldRectangle.Width - Camera.ViewPortWidth > 0 ? Camera.WorldRectangle.Width - Camera.ViewPortWidth : 0;
            }
        }

        void gameForm_VisibleChanged(object sender, EventArgs e)
        {
            if (gameForm.Visible == true)
                gameForm.Visible = false;

            parentForm.Enabled = true;
            parentForm.Focus();
        }

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }
        #endregion
    }
}
