using Microsoft.Xna.Framework;

namespace TileMapLibrary
{
    public static class Camera
    {
        #region Declarations
        private static Vector2 _Position = Vector2.Zero;
        private static Vector2 _ViewPortSize = Vector2.Zero;
        private static Rectangle _WorldRectangle = new Rectangle(0, 0, 0, 0);

        private static Vector2 _ZoomAmount = new Vector2(1.0f, 1.0f);
        private static float _Rotation = 0.0f;
        #endregion Declarations

        #region Properties
        public static Vector2 Position
        {
            get { return _Position; }
            set
            {
                _Position = new Vector2(
                    MathHelper.Clamp(value.X, _WorldRectangle.X, _WorldRectangle.Width - ViewPortWidth),
                    MathHelper.Clamp(value.Y, _WorldRectangle.Y, _WorldRectangle.Height - ViewPortHeight));
            }
        }

        public static Rectangle WorldRectangle
        {
            get { return _WorldRectangle; }
            set { _WorldRectangle = value; }
        }

        public static int ViewPortWidth
        {
            get { return (int)_ViewPortSize.X; }
            set { _ViewPortSize.X = value; }
        }

        public static int ViewPortHeight
        {
            get { return (int)_ViewPortSize.Y; }
            set { _ViewPortSize.Y = value; }
        }

        public static Rectangle ViewPort
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, ViewPortWidth, ViewPortHeight);
            }
        }

        public static Vector2 ZoomAmount
        {
            get { return _ZoomAmount; }
            set
            {
                _ZoomAmount.X = MathHelper.Clamp(value.X, 0.35f, float.MaxValue);
                _ZoomAmount.Y = MathHelper.Clamp(value.Y, 0.35f, float.MaxValue);
            }
        }

        public static float Rotation
        {
            get { return _Rotation; }
            set { _Rotation = MathHelper.Clamp(value, -0.99f, 0.99f); }
        }
        #endregion Properties

        #region Public Methods
        public static void Move(Vector2 offset)
        {
            Position += offset;
        }

        public static bool ObjectIsVisible(Rectangle bounds)
        {
            return (ViewPort.Intersects(bounds));
        }

        public static Vector2 WorldToScreen(Vector2 worldLocation)
        {
            return
                Vector2.Transform(worldLocation - _Position, Zoom());
                //worldLocation - _Position;
        }

        public static Rectangle WorldToScreen(Rectangle worldRectangle)
        {
            return new Rectangle(
                worldRectangle.Left - (int)_Position.X,
                worldRectangle.Top - (int)_Position.Y,
                worldRectangle.Width,
                worldRectangle.Height);
        }

        public static Vector2 ScreenToWorld(Vector2 screenLocation)
        {
            return 
                Vector2.Transform(screenLocation + _Position, Matrix.Invert(Zoom()));
                //screenLocation + _Position;
        }

        public static Rectangle ScreenToWorld(Rectangle screenRectangle)
        {
            return new Rectangle(
                screenRectangle.Left + (int)_Position.X,
                screenRectangle.Top + (int)_Position.Y,
                screenRectangle.Width,
                screenRectangle.Height);
        }

        public static Matrix Zoom()
        {
            return Matrix.CreateScale(new Vector3(ZoomAmount.X, ZoomAmount.Y, 1.0f));
            // *
            //Matrix.CreateTranslation(new Vector3(-_Position.X, -_Position.Y, 0)) *
            //Matrix.CreateRotationZ(Rotation) *
            //Matrix.CreateTranslation(new Vector3(ViewPortWidth * 0f, ViewPortHeight * 0f, 0));//ViewPortWidth * 0.5f, ViewPortHeight * 0.5f, 0));

            //Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
            //                             Matrix.CreateRotationZ(Rotation) *
            //                             Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
            //                             Matrix.CreateTranslation(new Vector3(ViewportWidth * 0.5f, ViewportHeight * 0.5f, 0))
        }
        #endregion Public Methods
    }
}
