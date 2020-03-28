using System;
using Microsoft.Xna.Framework;

namespace TileMapLibrary
{
    [Serializable]
    public class SerializableTileMap
    {
        #region Declarations
        public int TileWidth;
        public int TileHeight;
        public int MapWidth;
        public int MapHeight;
        public int MapLayers;
        public Vector2 Gravity;

        public SerializableMapLayer[] SerializableMapLayerCollection;
        #endregion

        #region Constructor
        /// <summary>
        /// Used only for serialization.
        /// </summary>
        private SerializableTileMap()
        {
        }

        public SerializableTileMap(int mapLayers, int mapWidth, int mapHeight, int tileWidth, int tileHeight, Vector2 gravity, MapLayer[] layerCells)
        {
            MapLayers = mapLayers;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Gravity = gravity;

            SerializableMapLayerCollection = new SerializableMapLayer[layerCells.Length];

            int _TotalSquares = mapWidth * mapHeight;
            int _CurrentSquare = 0;

            for (int layer = 0; layer < layerCells.Length; layer++)
            {
                _CurrentSquare = 0;
                SerializableMapLayerCollection[layer] = new SerializableMapLayer();
                SerializableMapLayerCollection[layer].MapLayer = layerCells[layer];
                SerializableMapLayerCollection[layer].TintColor = new Vector3(layerCells[layer].TintColor.R, layerCells[layer].TintColor.G, layerCells[layer].TintColor.B);
                SerializableMapLayerCollection[layer].SerializableMapSquareCollection = new MapSquare[_TotalSquares];

                for (int y = 0; y < mapHeight; y++)
                    for (int x = 0; x < mapWidth; x++)
                        if (_CurrentSquare < _TotalSquares)
                        {
                            SerializableMapLayerCollection[layer].SerializableMapSquareCollection[_CurrentSquare] = layerCells[layer].MapSquareCollection[x, y];
                            _CurrentSquare++;
                        }
            }
        }
        #endregion

        #region Convertion Methods
        // It isn't inside the layer class because we are only gonna need this on specific scenarios and don't need to have it always available.
        public MapSquare[,] ConvertSimpleArrayIntoMultidimensionalArray(MapSquare[] mapCells)
        {
            MapSquare[,] _MapSquareCollection = new MapSquare[MapWidth, MapHeight];
            int _MapWidth = 0;
            int _MapHeight = 0;

            for (int x = 0; x < mapCells.Length; x++)
            {
                _MapSquareCollection[_MapWidth, _MapHeight] = mapCells[x];
                _MapWidth++;

                if (_MapWidth >= MapWidth)
                {
                    _MapWidth = 0;
                    _MapHeight++;
                }
            }

            return _MapSquareCollection;
        }

        //public void ConvertMultidimensionalArrayIntoSimpleArray(MapSquare[,] mapCells)
        //{
        //    int totalSquares = MapWidth * MapHeight;
        //    int currentSquare = 0;
        //    MapCells = new MapSquare[totalSquares];

        //    for (int y = 0; y < MapHeight; y++)
        //        for (int x = 0; x < MapWidth; x++)
        //            if (currentSquare < totalSquares)
        //            {
        //                MapCells[currentSquare] = mapCells[x, y];
        //                currentSquare++;
        //            }
        //}
        #endregion
    }

    [Serializable]
    public class SerializableMapLayer
    {
        public MapLayer MapLayer;

        // A vector3 is utilized because a Color cannot be Deserialized correctly so we will store the 3 values (R,G,B) for the serialization/deserialization.
        public Vector3 TintColor;
        public MapSquare[] SerializableMapSquareCollection;
    }
}
