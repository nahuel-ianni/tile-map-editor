using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapLibrary
{
    [Serializable]
    public class MapLayer
    {
        #region Declarations
        [System.Xml.Serialization.XmlIgnore]            // This property is ignored because a matrix cannot be serialized.
        public MapSquare[,] MapSquareCollection = new MapSquare[TileMap.MapWidth, TileMap.MapHeight];
        [System.Xml.Serialization.XmlIgnore]            // This property is ignored because a Color cannot be deserialized so there's no use in serializing it's value.
        public Color TintColor = Color.White;

        public bool ShowLayer = true;

        public bool AutoScrolling = false;
        public Vector2 AutoScrollingVelocity = Vector2.Zero;
        public float AlphaValue = 1.0f;
        public int LayerNumber = 0;

        private float _PositionX = 0;
        private float _PositionY = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Used only for serialization.
        /// </summary>
        private MapLayer() { }

        public MapLayer(int layerNumber)
        {
            LayerNumber = layerNumber;
            ResetLayer();
        }
        #endregion

        #region Update & Draw Method
        public void Update(GameTime gameTime)
        {
            //if (AutoScrolling)
            //{
            //    _PositionX += AutoScrollingVelocity.X;// *(float)gameTime.ElapsedGameTime.TotalSeconds;
            //    _PositionY += AutoScrollingVelocity.Y;// *(float)gameTime.ElapsedGameTime.TotalSeconds;

            //    // Esto mueve la camara pero es incorrecto xq la tiene q mover Y UBICAR en el 00 de la pantalla.
            //    // No puedo hacerlo dentro del draw iniciado normalmente, deberia tener 2 draws...
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (ShowLayer)
            {
                int startX = TileMap.GetCellByPixelX((int)(Camera.Position.X));
                int endX = TileMap.GetCellByPixelX((int)(Camera.Position.X + Camera.ViewPortWidth));

                int startY = TileMap.GetCellByPixelY((int)Camera.Position.Y);
                int endY = TileMap.GetCellByPixelY((int)Camera.Position.Y + Camera.ViewPortHeight);

                for (int x = startX; x <= endX; x++)
                    for (int y = startY; y <= endY; y++)
                        if ((x >= 0) && (y >= 0) && 
                            (x < TileMap.MapWidth) && (y < TileMap.MapHeight) &&
                            MapSquareCollection[x, y].SquareTile != -1)
                            spriteBatch.Draw(
                                TileMap.TileSheet,
                                TileMap.CellScreenRectangle(x, y),
                                TileMap.TileSourceRectangle(MapSquareCollection[x, y].SquareTile),
                                TintColor * AlphaValue,
                                0.0f,
                                Vector2.Zero,
                                SpriteEffects.None,
                                1f - ((float)LayerNumber * 0.1f));
            }
        }
        #endregion

        #region Map Editor Exclusive Access Methods
        public void ClearLayer()
        {
            for (int x = 0; x < TileMap.MapWidth; ++x)
                for (int y = 0; y < TileMap.MapHeight; ++y)
                    MapSquareCollection[x, y] = new MapSquare(-1, System.String.Empty, true, TileMap.Gravity);
        }

        public void FillRectangle(int startingCellX, int startingCellY, int endingCellX, int endingCellY, int mapSquareTile)
        {
            for (int x = startingCellX; x <= endingCellX; ++x)
                for (int y = startingCellY; y <= endingCellY; ++y)
                    MapSquareCollection[x, y].SquareTile = mapSquareTile;
        }

        public void FillLayer(int mapSquareTile)
        {
            for (int x = 0; x < TileMap.MapWidth; ++x)
                for (int y = 0; y < TileMap.MapHeight; ++y)
                    MapSquareCollection[x, y].SquareTile = mapSquareTile;
        }

        public void FillLayer(int[,] mapSquareTileCollection)
        {
            int _MapSquareTileCollectionX = 0;
            int _MapSquareTileCollectionY = 0;

            int _MaxItemsX = mapSquareTileCollection.GetUpperBound(0) + 1;
            int _MaxItemsY = mapSquareTileCollection.GetUpperBound(1) + 1;

            for (int x = 0; x < TileMap.MapWidth; x++)
            {
                if (_MapSquareTileCollectionX >= _MaxItemsX)
                    _MapSquareTileCollectionX = 0;

                for (int y = 0; y < TileMap.MapHeight; y++)
                {
                    if (_MapSquareTileCollectionY >= _MaxItemsY)
                        _MapSquareTileCollectionY = 0;

                    MapSquareCollection[x, y].SquareTile = mapSquareTileCollection[_MapSquareTileCollectionX, _MapSquareTileCollectionY];
                    _MapSquareTileCollectionY++;
                }

                _MapSquareTileCollectionY = 0;
                _MapSquareTileCollectionX++;
            }
        }

        public void ModifyLayerGravity(int newGravityX, int newGravityY)
        {
            ModifyLayerGravity(new Vector2(newGravityX, newGravityY));
        }

        public void ModifyLayerGravity(Vector2 newGravity)
        {
            for (int x = 0; x < TileMap.MapWidth; ++x)
                for (int y = 0; y < TileMap.MapHeight; ++y)
                {
                    if (MapSquareCollection[x, y].Gravity.X == TileMap.Gravity.X)
                        MapSquareCollection[x, y].Gravity.X = newGravity.X;

                    if (MapSquareCollection[x, y].Gravity.Y == TileMap.Gravity.Y)
                        MapSquareCollection[x, y].Gravity.Y = newGravity.Y;
                }
        }

        public void RedimensionLayerSize(Vector2 layerSize)
        {
            RedimensionLayerSize((int)layerSize.X, (int)layerSize.Y);
        }

        public void RedimensionLayerSize(int layerWidth, int layerHeight)
        {
            // The map gets bigger on the X axis.
            if (layerWidth > TileMap.MapWidth)
                RedimensionMapWidth(layerWidth);

            // The map gets bigger on the Y axis. The layerWidth is passed because the TileMap.MapWidth hasn't been updated yet.
            if (layerHeight > TileMap.MapHeight)
                RedimensionMapHeight(layerWidth, layerHeight);
        }

        #region Redimension Map Size particular methods
        void RedimensionMapWidth(int layerWidth)
        {
            MapSquare[,] newlayerCells = new MapSquare[layerWidth, TileMap.MapHeight];
            for (int x = 0; x < TileMap.MapWidth; ++x)
                for (int y = 0; y < TileMap.MapHeight; ++y)
                    newlayerCells[x, y] = MapSquareCollection[x, y];

            MapSquareCollection = newlayerCells;

            for (int x = TileMap.MapWidth; x < layerWidth; ++x)
                for (int y = 0; y < TileMap.MapHeight; ++y)
                    MapSquareCollection[x, y] = new MapSquare(-1, System.String.Empty, true, TileMap.Gravity);
        }

        void RedimensionMapHeight(int layerWidth, int layerHeight)
        {
            MapSquare[,] newlayerCells = new MapSquare[layerWidth, layerHeight];
            for (int x = 0; x < layerWidth; ++x)
                for (int y = 0; y < TileMap.MapHeight; ++y)
                    newlayerCells[x, y] = MapSquareCollection[x, y];

            MapSquareCollection = newlayerCells;

            for (int x = 0; x < layerWidth; ++x)
                for (int y = TileMap.MapHeight; y < layerHeight; ++y)
                    MapSquareCollection[x, y] = new MapSquare(-1, System.String.Empty, true, TileMap.Gravity);
        }
        #endregion

        public void ResetLayer()
        {
            ShowLayer = true;
            AutoScrolling = false;
            AutoScrollingVelocity = Vector2.Zero;

            TintColor = Color.White;

            ClearLayer();
        }
        #endregion
    }
}
