using ConsoleWorld.GameLogic.Core;

namespace ConsoleWorld.GameLogic.Screens
{
    using Enums;
    using Models;
    using System;

    public class ScreenHandler
    {
        // true - start
        // false - help, credits
        public bool SelectOptionFromTitleScreen()
        {
            TitleScreen.SelectOption();
            switch (TitleScreen.CurrentOption)
            {
                case TitleScreenOption.Start:
                    StartMenuScreen.Draw();
                    return true;
                case TitleScreenOption.Help:
                    HelpScreen.Draw();                   
                    Back();
                    return false;
                case TitleScreenOption.Credits:
                    CreditsScreen.Draw();
                    Back();
                    return false;
                case TitleScreenOption.Exit:
                    Environment.Exit(0);
                    break;
            }

            return false;
        }

        public Character SelectOptionFromStartMenuScreen()
        {
            StartMenuScreen.CurrentOption = StartMenuOption.NewGame;
            StartMenuScreen.SelectOption();
            switch (StartMenuScreen.CurrentOption)
            {
                case StartMenuOption.LoadGame:
                    LoadGameScreen.Draw();
                    return LoadGameScreen.GetCharacter();
                case StartMenuOption.NewGame:
                    CharacterCreationScreen.Draw();
                    return CharacterCreationScreen.CreateCharacter();
                case StartMenuOption.Back:
                    TitleScreen.Draw();
                    //this.SelectOptionFromTitleScreen();
                    break;
            }

            return null;
        }

        public void SelectOptionFromImproveStatsScreen(Dungeon dungeon,Character character)
        {
            ImproveStatsScreen.Draw(character);
            if(ImproveStatsScreen.SelectOption(character))
            BackFromImproveStats(dungeon,character);
        }

        public void Back()
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter)
                {
                    TitleScreen.Draw();
                    break;
                }
            }           
        }

        public void BackFromImproveStats(Dungeon dungeon,Character character)
        {

                    Console.Clear();
                    dungeon.Draw();
                    character.Draw();            
        }
    }
}