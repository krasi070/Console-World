namespace ConsoleWorld.GameLogic.Screens
{
    using Enums;
    using System;

    public class ScreenHandler
    {
        public void SelectOptionFromTitleScreen()
        {
            TitleScreen.CurrentOption = TitleScreenOption.Start;
            TitleScreen.SelectOption();
            switch (TitleScreen.CurrentOption)
            {
                case TitleScreenOption.Start:
                    StartMenuScreen.Draw();
                    this.SelectOptionFromStartMenuScreen();
                    break;
                case TitleScreenOption.Help:
                    // TODO: Create HelpScreen class and draw it here
                    break;
                case TitleScreenOption.Credits:
                    // TODO: Create Credits class and draw it here
                    break;
                case TitleScreenOption.Exit:
                    Environment.Exit(0);
                    break;
            }
        }

        public void SelectOptionFromStartMenuScreen()
        {
            StartMenuScreen.CurrentOption = StartMenuOption.NewGame;
            StartMenuScreen.SelectOption();
            switch (StartMenuScreen.CurrentOption)
            {
                case StartMenuOption.LoadGame:
                    // TODO: Create LoadScreen class and draw it here
                    break;
                case StartMenuOption.NewGame:
                    CharacterCreationScreen.Draw();
                    CharacterCreationScreen.CreateCharacter();
                    break;
                case StartMenuOption.Back:
                    TitleScreen.Draw();
                    this.SelectOptionFromTitleScreen();
                    break;
            }
        }
    }
}