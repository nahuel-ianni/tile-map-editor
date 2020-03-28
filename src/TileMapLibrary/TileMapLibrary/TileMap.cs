using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapLibrary
{
    public static class TileMap
    {
        #region Declarations
        public static int TileWidth = 48;
        public static int TileHeight = 48;
        public static int MapWidth = 40;
        public static int MapHeight = 11;
        public static int MapLayers = 3;
        public static int CurrentLayer = 0;

        public static SpriteFont SpriteFont;
        public static Texture2D TileSheet;
        public static Vector2 Gravity = Vector2.Zero;
        public static MapLayer[] MapLayerCollection;

        private static Texture2D _Pixel;
        private static float _PassableBlocksAlphaValue = 0.2f;
        private static float _PassableBlocksAlphaValueModifier = 0.2f;

        // Map Editor exclusive declarations
        public static bool EditorMode = false;
        public static bool ShowLinedGrid = false;
        public static bool ShowPointedGrid = false;
        public static bool ShowSquareGravity = false;
        public static bool ShowPassableBlocks = true;
        public static bool ShowCodeValues = true;
        #endregion

        #region Initialization
        /// <summary>
        /// Initialization used by the Game1 class.
        /// </summary>
        /// <param name="tileTexture"></param>
        /// <param name="mapLayers"></param>
        /// <param name="mapWidth"></param>
        /// <param name="mapHeight"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        public static void Initialize(Texture2D tileTexture, int mapLayers, int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            Initialize(
                tileTexture,
                mapLayers,
                mapWidth,
                mapHeight,
                tileWidth,
                tileHeight,
                null);
        }

        /// <summary>
        /// Initialization used by the MapEditor when loading an existing map.
        /// </summary>
        /// <param name="tileTexture"></param>
        /// <param name="serializableTileMap"></param>
        /// <param name="graphicsDevice"></param>
        public static void Initialize(Texture2D tileTexture, SerializableTileMap serializableTileMap, GraphicsDevice graphicsDevice)
        {
            Initialize(
                tileTexture,
                serializableTileMap.MapLayers,
                serializableTileMap.MapWidth,
                serializableTileMap.MapHeight,
                serializableTileMap.TileWidth,
                serializableTileMap.TileHeight,
                graphicsDevice);
        }

        /// <summary>
        /// Initialization used by the Map Editor when creating a new Map.
        /// </summary>
        /// <param name="tileTexture"></param>
        /// <param name="mapLayers"></param>
        /// <param name="mapWidth"></param>
        /// <param name="mapHeight"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <param name="graphicsDevice"></param>
        public static void Initialize(Texture2D tileTexture, int mapLayers, int mapWidth, int mapHeight, int tileWidth, int tileHeight, GraphicsDevice graphicsDevice)
        {
            TileSheet = tileTexture;
            MapLayers = mapLayers;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            MapLayerCollection = new MapLayer[MapLayers];

            for (int x = 0; x < MapLayers; x++)
                MapLayerCollection[x] = new MapLayer(x);

            if (graphicsDevice != null)
            {
                _Pixel = new Texture2D(graphicsDevice, 1, 1);
                _Pixel.SetData(new[] { Color.White });
            }

            ClearMap();
        }
        #endregion

        #region Tile and Tile Sheet Handling
        public static int TilesPerRow
        {
            get { return TileSheet.Width / TileWidth; }
        }

        public static Rectangle TileSourceRectangle(int tileIndex)
        {
            return new Rectangle(
                (tileIndex % TilesPerRow) * TileWidth,
                (tileIndex / TilesPerRow) * TileHeight,
                TileWidth,
                TileHeight);
        }
        #endregion

        #region Information about Map Squares
        public static int GetCellByPixelX(int pixelX)
        {
            return pixelX / TileWidth;
        }

        public static int GetCellByPixelY(int pixelY)
        {
            return pixelY / TileHeight;
        }

        public static Vector2 GetCellByPixel(Vector2 pixelLocation)
        {
            return new Vector2(
                GetCellByPixelX((int)pixelLocation.X),
                GetCellByPixelY((int)pixelLocation.Y));
        }

        public static Vector2 GetCellCenter(int cellX, int cellY)
        {
            return new Vector2(
                (cellX * TileWidth) + (TileWidth / 2),
                (cellY * TileHeight) + (TileHeight / 2));
        }

        public static Vector2 GetCellCenter(Vector2 cell)
        {
            return GetCellCenter(
                (int)cell.X,
                (int)cell.Y);
        }

        public static Rectangle CellWorldRectangle(int cellX, int cellY)
        {
            return new Rectangle(
                cellX * TileWidth,
                cellY * TileHeight,
                TileWidth,
                TileHeight);
        }

        public static Rectangle CellWorldRectangle(Vector2 cell)
        {
            return CellWorldRectangle(
                (int)cell.X,
                (int)cell.Y);
        }

        public static Rectangle CellScreenRectangle(int cellX, int cellY)
        {
            return Camera.WorldToScreen(CellWorldRectangle(cellX, cellY));
        }

        public static Rectangle CellScreenRectangle(Vector2 cell)
        {
            return CellScreenRectangle((int)cell.X, (int)cell.Y);
        }

        public static bool CellIsPassable(int cellX, int cellY, int layer)
        {
            MapSquare _Square = GetMapSquareAtCell(cellX, cellY, layer);

            if (_Square == null)
                return false;
            else
                return _Square.Passable;
        }

        public static bool CellIsPassable(Vector2 cell, int layer)
        {
            return CellIsPassable((int)cell.X, (int)cell.Y, layer);
        }

        public static bool CellIsPassableByPixel(Vector2 pixelLocation, int layer)
        {
            return CellIsPassable(
                GetCellByPixelX((int)pixelLocation.X),
                GetCellByPixelY((int)pixelLocation.Y),
                layer);
        }

        public static string CellCodeValue(int cellX, int cellY, int layer)
        {
            MapSquare _Square = GetMapSquareAtCell(cellX, cellY, layer);

            if (_Square == null)
                return string.Empty;
            else
                return _Square.CodeValue.ToLower();
        }

        public static string CellCodeValue(Vector2 cell, int layer)
        {
            return CellCodeValue((int)cell.X, (int)cell.Y, layer);
        }

        public static Vector2 CellGravity(int cellX, int cellY, int layer)
        {
            MapSquare _Square = GetMapSquareAtCell(cellX, cellY, layer);

            if (_Square == null)
                return Vector2.Zero;
            else
                return _Square.Gravity;
        }

        public static Vector2 CellGravity(Vector2 cell, int layer)
        {
            return CellGravity((int)cell.X, (int)cell.Y, layer);
        }
        #endregion

        #region Information about MapSquare objects
        public static MapSquare GetMapSquareAtCell(int tileX, int tileY, int layer)
        {
            if ((tileX >= 0) && (tileX < MapWidth) &&
                (tileY >= 0) && (tileY < MapHeight) &&
                (layer >= 0) && (layer <= MapLayerCollection.Length))
                return MapLayerCollection[layer].MapSquareCollection[tileX, tileY];
            else
                return null;
        }

        public static void SetMapSquareAtCell(int tileX, int tileY, int layer, MapSquare tile)
        {
            if ((tileX >= 0) && (tileX < MapWidth) &&
                (tileY >= 0) && (tileY < MapHeight) &&
                (layer >= 0) && (layer <= MapLayerCollection.Length))
                MapLayerCollection[layer].MapSquareCollection[tileX, tileY] = tile;
        }

        public static void SetTileAtCell(int tileX, int tileY, int layer, int tileIndex)
        {
            if ((tileX >= 0) && (tileX < MapWidth) &&
                (tileY >= 0) && (tileY < MapHeight) &&
                (layer >= 0) && (layer <= MapLayerCollection.Length))
                MapLayerCollection[layer].MapSquareCollection[tileX, tileY].SquareTile = tileIndex;
        }

        public static MapSquare GetMapSquareAtPixel(int pixelX, int pixelY, int layer)
        {
            return GetMapSquareAtCell(
                GetCellByPixelX(pixelX),
                GetCellByPixelY(pixelY),
                layer);
        }

        public static MapSquare GetMapSquareAtPixel(Vector2 pixelLocation, int layer)
        {
            return GetMapSquareAtPixel(
                (int)pixelLocation.X,
                (int)pixelLocation.Y,
                layer);
        }
        #endregion

        #region Update Methods
        public static void Update(GameTime gameTime)
        {
            if (!EditorMode)
                for (int z = 0; z < MapLayers; z++)
                    MapLayerCollection[z].Update(gameTime);

            if (EditorMode)
                UpdateEditModeItems(gameTime);
        }

        private static void UpdateEditModeItems(GameTime gameTime)
        {
            _PassableBlocksAlphaValue += (_PassableBlocksAlphaValueModifier * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (_PassableBlocksAlphaValue <= 0.15f ||
                _PassableBlocksAlphaValue >= 0.65f)
                _PassableBlocksAlphaValueModifier *= -1;
        }
        #endregion

        #region Drawing Methods
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (TileSheet != null)
                for (int z = 0; z < MapLayers; z++)
                    MapLayerCollection[z].Draw(spriteBatch);

            if (EditorMode)
                DrawEditModeItems(spriteBatch);
        }

        public static void DrawEditModeItems(SpriteBatch spriteBatch)
        {
            int startX = GetCellByPixelX((int)Camera.Position.X);
            int endX = GetCellByPixelX((int)Camera.Position.X + Camera.ViewPortWidth);

            int startY = GetCellByPixelY((int)Camera.Position.Y);
            int endY = GetCellByPixelY((int)Camera.Position.Y + Camera.ViewPortHeight);

            for (int x = startX; x <= endX; x++)
                for (int y = startY; y <= endY; y++)
                {
                    if ((x < 0) || (x >= MapWidth) ||
                        (y < 0) || (y >= MapHeight))
                        continue;

                    Rectangle _ScreenRectangle = CellScreenRectangle(x, y);

                    if (ShowPointedGrid)
                    {
                        #region Pointed Grid
                        // Line on Top
                        if (y == 0)
                        {
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 1 / 8), _ScreenRectangle.Top, 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 2 / 8), _ScreenRectangle.Top, 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 3 / 8), _ScreenRectangle.Top, 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 4 / 8), _ScreenRectangle.Top, 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 5 / 8), _ScreenRectangle.Top, 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 6 / 8), _ScreenRectangle.Top, 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 7 / 8), _ScreenRectangle.Top, 1, 1), Color.AntiqueWhite);
                        }

                        // Line on Left
                        if (x == 0)
                        {
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top + (TileMap.TileWidth * 1 / 8), 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top + (TileMap.TileWidth * 2 / 8), 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top + (TileMap.TileWidth * 3 / 8), 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top + (TileMap.TileWidth * 4 / 8), 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top + (TileMap.TileWidth * 5 / 8), 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top + (TileMap.TileWidth * 6 / 8), 1, 1), Color.AntiqueWhite);
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top + (TileMap.TileWidth * 7 / 8), 1, 1), Color.AntiqueWhite);
                        }

                        // Line on Bottom
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 1 / 8), _ScreenRectangle.Bottom, 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 2 / 8), _ScreenRectangle.Bottom, 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 3 / 8), _ScreenRectangle.Bottom, 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 4 / 8), _ScreenRectangle.Bottom, 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 5 / 8), _ScreenRectangle.Bottom, 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 6 / 8), _ScreenRectangle.Bottom, 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left + (TileMap.TileHeight * 7 / 8), _ScreenRectangle.Bottom, 1, 1), Color.AntiqueWhite);

                        // Line on Right
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top + (TileMap.TileWidth * 1 / 8), 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top + (TileMap.TileWidth * 2 / 8), 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top + (TileMap.TileWidth * 3 / 8), 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top + (TileMap.TileWidth * 4 / 8), 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top + (TileMap.TileWidth * 5 / 8), 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top + (TileMap.TileWidth * 6 / 8), 1, 1), Color.AntiqueWhite);
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top + (TileMap.TileWidth * 7 / 8), 1, 1), Color.AntiqueWhite);
                        #endregion
                    }
                    else if (ShowLinedGrid)
                    {
                        #region Lined Grid
                        if (x == 0)
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top, 1, _ScreenRectangle.Height), Color.AntiqueWhite);   // Left

                        if (y == 0)
                            spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Top, _ScreenRectangle.Width, 1), Color.AntiqueWhite);    // Top

                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Right, _ScreenRectangle.Top, 1, _ScreenRectangle.Height), Color.AntiqueWhite);      // Right
                        spriteBatch.Draw(_Pixel, new Rectangle(_ScreenRectangle.Left, _ScreenRectangle.Bottom, _ScreenRectangle.Width, 1), Color.AntiqueWhite);     // Bottom
                        #endregion
                    }

                    if (MapLayerCollection[CurrentLayer].ShowLayer)
                    {
                        #region Passable Blocks
                        if (ShowPassableBlocks)
                            if (!CellIsPassable(x, y, CurrentLayer))
                                spriteBatch.Draw(
                                    TileSheet,
                                    _ScreenRectangle,
                                    TileSourceRectangle(1),
                                    new Color(255, 0, 0, 80) * _PassableBlocksAlphaValue,
                                    0.0f,
                                    Vector2.Zero,
                                    SpriteEffects.None,
                                    0.0f);
                        #endregion

                        #region Code Values
                        if (ShowCodeValues)
                            if (MapLayerCollection[CurrentLayer].MapSquareCollection[x, y].CodeValue != "")
                            {
                                spriteBatch.DrawString(
                                    SpriteFont,
                                    MapLayerCollection[CurrentLayer].MapSquareCollection[x, y].CodeValue,
                                    new Vector2(
                                        _ScreenRectangle.X,
                                        _ScreenRectangle.Bottom - SpriteFont.MeasureString(MapLayerCollection[CurrentLayer].MapSquareCollection[x, y].CodeValue).Y),
                                    Color.White,
                                    0.0f,
                                    Vector2.Zero,
                                    1.0f,
                                    SpriteEffects.None,
                                    0.0f);
                            }
                        #endregion

                        #region Gravity
                        // It checks if the cell is passable because blocks not passable will never use it's gravity.
                        if (ShowSquareGravity && MapLayerCollection[CurrentLayer].MapSquareCollection[x, y].Passable)
                            spriteBatch.DrawString(
                                SpriteFont,
                                string.Format(" {0},{1}", MapLayerCollection[CurrentLayer].MapSquareCollection[x, y].Gravity.X, MapLayerCollection[CurrentLayer].MapSquareCollection[x, y].Gravity.Y),
                                new Vector2(_ScreenRectangle.X, _ScreenRectangle.Top),
                                Color.White,
                                0.0f,
                                Vector2.Zero,
                                1.0f,
                                SpriteEffects.None,
                                0.0f);
                        #endregion
                    }
                }
        }
        #endregion

        #region Loading and Saving Maps
        public static void SaveMap(FileStream fileStream)
        {
            SerializableTileMap _SerializableTileMap = new SerializableTileMap(MapLayers, MapWidth, MapHeight, TileWidth, TileHeight, Gravity, MapLayerCollection);

            XmlSerializer _XmlSerializer = new XmlSerializer(typeof(SerializableTileMap));
            _XmlSerializer.Serialize(fileStream, _SerializableTileMap);
            fileStream.Close();
        }

        public static bool LoadMap(FileStream fileStream)
        {
            bool _ReturnValue = true;
            try
            {
                SerializableTileMap _SerializableTileMap;
                XmlSerializer _XmlSerializer = new XmlSerializer(typeof(SerializableTileMap));
                _SerializableTileMap = _XmlSerializer.Deserialize(fileStream) as SerializableTileMap;

                LoadMap(_SerializableTileMap);

                _ReturnValue = true;
            }
            catch
            {
                ClearMap();

                _ReturnValue = false;
            }

            fileStream.Close();
            return _ReturnValue;
        }

        public static void LoadMap(SerializableTileMap serializableTileMap)
        {
            MapLayers = serializableTileMap.MapLayers;
            MapWidth = serializableTileMap.MapWidth;
            MapHeight = serializableTileMap.MapHeight;
            TileWidth = serializableTileMap.TileWidth;
            TileHeight = serializableTileMap.TileHeight;
            Gravity = serializableTileMap.Gravity;

            Camera.WorldRectangle = new Rectangle(0, 0, TileWidth * MapWidth, TileHeight * MapHeight);
            Camera.Position = Vector2.Zero;

            MapLayerCollection = new MapLayer[serializableTileMap.SerializableMapLayerCollection.Length];

            for (int layer = 0; layer < serializableTileMap.SerializableMapLayerCollection.Length; layer++)
                LoadLayer(serializableTileMap, layer);
        }

        public static void LoadLayer(SerializableTileMap serializableTileMap, int layerNumber)
        {
            int _LayerPosition = serializableTileMap.SerializableMapLayerCollection[layerNumber].MapLayer.LayerNumber;

            MapLayerCollection[_LayerPosition] = new MapLayer(layerNumber);
            MapLayerCollection[_LayerPosition].MapSquareCollection = serializableTileMap.ConvertSimpleArrayIntoMultidimensionalArray(serializableTileMap.SerializableMapLayerCollection[layerNumber].SerializableMapSquareCollection);
            MapLayerCollection[_LayerPosition].ShowLayer = serializableTileMap.SerializableMapLayerCollection[layerNumber].MapLayer.ShowLayer;
            MapLayerCollection[_LayerPosition].AutoScrolling = serializableTileMap.SerializableMapLayerCollection[layerNumber].MapLayer.AutoScrolling;
            MapLayerCollection[_LayerPosition].AutoScrollingVelocity = serializableTileMap.SerializableMapLayerCollection[layerNumber].MapLayer.AutoScrollingVelocity;
            MapLayerCollection[_LayerPosition].AlphaValue = serializableTileMap.SerializableMapLayerCollection[layerNumber].MapLayer.AlphaValue;
            MapLayerCollection[_LayerPosition].LayerNumber = serializableTileMap.SerializableMapLayerCollection[layerNumber].MapLayer.LayerNumber;
            MapLayerCollection[_LayerPosition].TintColor.R = (byte)serializableTileMap.SerializableMapLayerCollection[layerNumber].TintColor.X;
            MapLayerCollection[_LayerPosition].TintColor.G = (byte)serializableTileMap.SerializableMapLayerCollection[layerNumber].TintColor.Y;
            MapLayerCollection[_LayerPosition].TintColor.B = (byte)serializableTileMap.SerializableMapLayerCollection[layerNumber].TintColor.Z;
        }
        #endregion

        #region Map Editor Exclusive Access Methods
        public static void ClearMap()
        {
            ShowAllLayers();

            for (int z = 0; z < MapLayers; ++z)
                for (int x = 0; x < MapWidth; ++x)
                    for (int y = 0; y < MapHeight; ++y)
                        MapLayerCollection[z].ResetLayer();
        }

        #region Layer Manipulation
        public static void AddLayer()
        {
            MapLayers++;
            MapLayer[] _Layers = new MapLayer[MapLayers];

            for (int x = 0; x < MapLayerCollection.Length; x++)
            {
                _Layers[x] = MapLayerCollection[x];
                _Layers[x].LayerNumber = x;
            }

            _Layers[MapLayers - 1] = new MapLayer(MapLayers - 1);

            MapLayerCollection = _Layers;
        }

        public static void AddLayer(int layer, bool insertAhead)
        {
            MapLayers++;
            MapLayer[] _Layers = new MapLayer[MapLayers];

            int _NewLayerPosition = 0;
            for (int x = 0; x < MapLayerCollection.Length; x++)
            {
                if (x == layer && !insertAhead)
                {
                    _Layers[_NewLayerPosition] = new MapLayer(_NewLayerPosition);
                    ++_NewLayerPosition;
                }

                _Layers[_NewLayerPosition] = MapLayerCollection[x];
                _Layers[_NewLayerPosition].LayerNumber = _NewLayerPosition;

                if (x == layer && insertAhead)
                {
                    ++_NewLayerPosition;
                    _Layers[_NewLayerPosition] = new MapLayer(_NewLayerPosition);
                }

                ++_NewLayerPosition;
            }

            MapLayerCollection = _Layers;
        }

        public static void ClearLayer(int layer)
        {
            int _LayerNumber = (int)MathHelper.Clamp(layer, 0, MapLayers - 1);

            MapLayerCollection[_LayerNumber].ClearLayer();
        }

        public static void CopyLayer(int sourceLayer, int destinationLayer)
        {
            sourceLayer = (int)MathHelper.Clamp(sourceLayer, 0, MapLayers - 1);
            destinationLayer = (int)MathHelper.Clamp(destinationLayer, 0, MapLayers - 1);

            if (sourceLayer != destinationLayer)
            {
                for (int x = 0; x < MapWidth; ++x)
                    for (int y = 0; y < MapHeight; ++y)
                        MapLayerCollection[destinationLayer].MapSquareCollection[x, y] = MapLayerCollection[sourceLayer].MapSquareCollection[x, y];
            }
        }

        public static void FillLayer(int layer, int layerTile)
        {
            int _LayerNumber = (int)MathHelper.Clamp(layer, 0, MapLayers - 1);

            MapLayerCollection[_LayerNumber].FillLayer(layerTile);
        }

        public static void FillLayer(int layer, int[,] layerTileCollection)
        {
            int _LayerNumber = (int)MathHelper.Clamp(layer, 0, MapLayers - 1);

            MapLayerCollection[_LayerNumber].FillLayer(layerTileCollection);
        }

        public static void FillRectangle(int layer, int startingCellX, int startingCellY, int endingCellX, int endingCellY, int layerTile)
        {
            int _LayerNumber = (int)MathHelper.Clamp(layer, 0, MapLayers - 1);

            MapLayerCollection[_LayerNumber].FillRectangle(startingCellX, startingCellY, endingCellX, endingCellY, layerTile);
        }

        public static void FillRectangle(int layer, Vector2 startingCell, Vector2 endingCell, int layerTile)
        {
            FillRectangle(layer, (int)startingCell.X, (int)startingCell.Y, (int)endingCell.X, (int)endingCell.Y, layerTile);
        }

        public static void RemoveLayer(int layerNumber)
        {
            if (MapLayers > 1)
            {
                layerNumber = (int)MathHelper.Clamp(layerNumber, 0, MapLayers - 1);

                MapLayer[] _Layers = new MapLayer[MapLayers - 1];
                int _NewLayerNumber = 0;

                for (int x = 0; x < MapLayers; x++)
                    if (x != layerNumber)
                    {
                        _Layers[_NewLayerNumber] = MapLayerCollection[x];
                        _Layers[_NewLayerNumber].LayerNumber = _NewLayerNumber;
                        _NewLayerNumber++;
                    }

                MapLayerCollection = _Layers;
                MapLayers--;

                if (CurrentLayer >= layerNumber && CurrentLayer > 0)
                    CurrentLayer--;
            }
        }

        public static void ShowAllLayers()
        {
            for (int x = 0; x < MapLayers; ++x)
                MapLayerCollection[x].ShowLayer = true;
        }
        #endregion

        public static void ModifyMapGravity(float newGravityX, float newGravityY, bool keepModifiedGravities)
        {
            ModifyMapGravity(new Vector2(newGravityX, newGravityY), keepModifiedGravities);
        }

        public static void ModifyMapGravity(Vector2 newGravity, bool keepModifiedGravities)
        {
            for (int x = 0; x < MapWidth; ++x)
                for (int y = 0; y < MapHeight; ++y)
                    for (int z = 0; z < MapLayers; ++z)
                    {
                        if (keepModifiedGravities)
                        {
                            if (MapLayerCollection[z].MapSquareCollection[x, y].Gravity.X == Gravity.X)
                                MapLayerCollection[z].MapSquareCollection[x, y].Gravity.X = newGravity.X;

                            if (MapLayerCollection[z].MapSquareCollection[x, y].Gravity.Y == Gravity.Y)
                                MapLayerCollection[z].MapSquareCollection[x, y].Gravity.Y = newGravity.Y;
                        }
                        else
                            MapLayerCollection[z].MapSquareCollection[x, y].Gravity = newGravity;
                    }

            Gravity = newGravity;
        }

        #region Map Size Manipulation
        public static void RedimensionMapSize(int mapWidth, int mapHeight)
        {
            if (mapWidth <= 0 || mapHeight <= 0)
                return;

            // The map gets smaller on the X axis.
            if (mapWidth < MapWidth)
                MapWidth = mapWidth;

            // The map gets smaller on the Y axis.
            if (mapHeight < MapHeight)
                MapHeight = mapHeight;

            //// The map gets bigger on the X axis.
            if (mapWidth > MapWidth)
                RedimensionMapWidth(mapWidth);

            //// The map gets bigger on the Y axis.
            if (mapHeight > MapHeight)
                RedimensionMapHeight(mapHeight);

            Camera.WorldRectangle = new Rectangle(0, 0, TileMap.TileWidth * TileMap.MapWidth, TileMap.TileHeight * TileMap.MapHeight);
        }

        private static void RedimensionMapWidth(int mapWidth)
        {
            MapSquare[,] _NewMapCells;// = new MapSquare[mapWidth, MapHeight];

            for (int z = 0; z < MapLayers; ++z)
            {
                _NewMapCells = new MapSquare[mapWidth, MapHeight];

                for (int x = 0; x < MapWidth; ++x)
                    for (int y = 0; y < MapHeight; ++y)
                        _NewMapCells[x, y] = MapLayerCollection[z].MapSquareCollection[x, y];

                for (int x = MapWidth; x < mapWidth; ++x)
                    for (int y = 0; y < MapHeight; ++y)
                        _NewMapCells[x, y] = new MapSquare(-1, string.Empty, true, Gravity);

                MapLayerCollection[z].MapSquareCollection = _NewMapCells;
            }

            MapWidth = mapWidth;
        }

        private static void RedimensionMapHeight(int mapHeight)
        {
            MapSquare[,] _NewMapCells; //= new MapSquare[MapWidth, mapHeight];

            for (int z = 0; z < MapLayers; ++z)
            {
                _NewMapCells = new MapSquare[MapWidth, mapHeight];

                for (int x = 0; x < MapWidth; ++x)
                    for (int y = 0; y < MapHeight; ++y)
                        _NewMapCells[x, y] = MapLayerCollection[z].MapSquareCollection[x, y];

                for (int x = 0; x < MapWidth; ++x)
                    for (int y = MapHeight; y < mapHeight; ++y)
                        _NewMapCells[x, y] = new MapSquare(-1, string.Empty, true, Gravity);

                MapLayerCollection[z].MapSquareCollection = _NewMapCells;
            }

            MapHeight = mapHeight;
        }
        #endregion

        public static void RedimensionTileSize(int tileWidth, int tileHeight)
        {
            if (tileWidth <= 0 || tileHeight <= 0)
                return;

            TileHeight = tileHeight;
            TileWidth = tileWidth;

            Camera.WorldRectangle = new Rectangle(0, 0, TileWidth * MapWidth, TileHeight * MapHeight);
        }
        #endregion
    }
}
