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

        //public void SelectOptionFromImproveStatsScreen()
        //{
        //    ImproveStatsScreen.CurrentOption = ImproveStatsOption.MaxHp;
        //    ImproveStatsScreen.SelectOption();

        //    switch (ImproveStatsScreen.CurrentOption)
        //    {
        //        case ImproveStatsOption.MaxHp:
        //            LoadGameScreen.Draw();
        //            break;
        //        case ImproveStatsOption.MaxMp:
        //            CharacterCreationScreen.Draw();
        //            CharacterCreationScreen.CreateCharacter();
        //            break;
        //        case ImproveStatsOption.Attack:
        //            TitleScreen.Draw();
        //            this.SelectOptionFromTitleScreen();
        //            break;
        //        case ImproveStatsOption.MagicAttack:
        //            TitleScreen.Draw();
        //            this.SelectOptionFromTitleScreen();
        //            break;
        //        case ImproveStatsOption.Defense:
        //            TitleScreen.Draw();
        //            this.SelectOptionFromTitleScreen();
        //            break;
        //        case ImproveStatsOption.MagicDefense:
        //            TitleScreen.Draw();
        //            this.SelectOptionFromTitleScreen();
        //            break;
        //        case ImproveStatsOption.Evade:
        //            TitleScreen.Draw();
        //            this.SelectOptionFromTitleScreen();
        //            break;
        //        case ImproveStatsOption.Accuracy:
        //            TitleScreen.Draw();
        //            this.SelectOptionFromTitleScreen();
        //            break;
        //    }
        //}

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

        //public void BackFromImproveStats()
        //{
        //    while (true)
        //    {
        //        ConsoleKey key = Console.ReadKey(true).Key;
        //        if(key == ConsoleKey.Enter)
        //        {
        //            //TODO: Return to game
        //            break;
        //        }
        //    }
        //}
    }
}