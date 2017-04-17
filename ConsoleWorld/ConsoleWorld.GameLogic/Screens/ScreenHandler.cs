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