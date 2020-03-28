using System;

namespace MapEditor2
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]         // Attributed used for the FileDialog instances to work while debugging.
        static void Main(string[] args)
        {
            LevelEditor _Form = new LevelEditor();

            _Form.Show();
            _Form.Game = new LevelEditorGame(
                _Form.pctSurface.Handle,
                _Form,
                _Form.pctSurface);

            _Form.Game.Run();
        }
    }
#endif
}

