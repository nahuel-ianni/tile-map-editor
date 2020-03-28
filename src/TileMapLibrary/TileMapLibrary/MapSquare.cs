using System;
using Microsoft.Xna.Framework;

namespace TileMapLibrary
{
    [Serializable]
    public class MapSquare
    {
        #region Declarations
        public int SquareTile = 0;
        public string CodeValue = String.Empty;
        public Vector2 Gravity = Vector2.Zero;
        public bool Passable = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Used only for serialization.
        /// </summary>
        private MapSquare() { }

        public MapSquare(int squareTile, string code, bool passable, Vector2 gravity)
        {
            SquareTile = squareTile;
            CodeValue = code;
            Passable = passable;
            Gravity = gravity;
        }
        #endregion

        #region Public Methods
        public void TogglePassable()
        {
            Passable = !Passable;
        }
        #endregion
    }
}
