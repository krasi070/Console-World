namespace ConsoleWorld.GameLogic.Handler
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MessageHandler
    {
        private const int StartX = 3;
        private const int StartY = 25;

        public void BattleMessage(Unit attacker, Unit defender, int damage)
        {
            this.WriteMessage($"{attacker.Name} attacked {defender.Name} for {damage} damage!");
        }

        public void ItemMessage(Character character, Item item)
        {
            this.WriteMessage($"{character.Name} picked up a(n) {item.Name}!");
        }

        public void MissMessage(Character character)
        {
            this.WriteMessage($"{character.Name} missed!");
        }

        public void MoneyMessage(Character character, int money)
        {
            this.WriteMessage($"{character.Name} got {money}$!");
        }

        public void KillMessage(Unit killer, Unit killed)
        {
            this.WriteMessage($"{killer.Name} killed {killed.Name} and got {killed.Money}$!");
        }

        public void HoleMessage()
        {
            this.WriteMessage("Drop down? (Press [J])");
        }

        public void MagicWellMessage(Character character, List<Item> items)
        {
            if (items.Count > 0)
            {
                this.WriteMessage($"{character.Name} got {string.Join(", ", items.Select(i => i.Name))} from the magic well!");
            }
            else
            {
                this.WriteMessage($"{character.Name} didn't give enough money to the magic well!");
            }
        }

        public void MagicWellTutorialMessage(Character character)
        {
            this.WriteMessage($"Will {character.Name} give all of his money to the magic well? (Press [L])");
        }

        public void UnlockDoorNormalKeyMessage(Character character, int keysLeft)
        {
            this.WriteMessage($"{character.Name} unlocked a door! ({keysLeft} keys left)");
        }

        public void UnlockDoorMasterKeyMessage(Character character)
        {
            this.WriteMessage($"{character.Name} unlocked a door with the Master Key!");
        }

        public void EraseMessage()
        {
            Console.SetCursorPosition(StartX, StartY);
            Console.Write(new string(' ', 100));
        }

        private void WriteMessage(string msg)
        {
            this.EraseMessage();
            Console.SetCursorPosition(StartX, StartY);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}