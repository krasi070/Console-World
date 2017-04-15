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
                    
                    HelpScreen.Draw();                   
                    BackFromHelp();   
                      break;
                    
                case TitleScreenOption.Credits:
                    CreditsScreen.Draw();
                    BackFromHelp();
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
                    LoadGameScreen.Draw();
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

        public void BackFromHelp()
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    TitleScreen.Draw();
                    SelectOptionFromTitleScreen();
                    break;
                }
            }           
        }
    }
}