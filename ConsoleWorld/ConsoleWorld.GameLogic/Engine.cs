namespace ConsoleWorld.GameLogic
{
    using Screens;

    public class Engine
    {
        private ScreenHandler screenHandler;

        public Engine()
        {
            this.screenHandler = new ScreenHandler();
        }

        public void Run()
        {
            TitleScreen.Draw();
            this.screenHandler.SelectOptionFromTitleScreen();
        }
    }
}