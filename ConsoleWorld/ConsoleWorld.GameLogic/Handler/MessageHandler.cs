namespace ConsoleWorld.GameLogic.Handler
{
    using Models;
    using System;

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
            this.WriteMessage($"{killer.Name} killed {killed.Name}!");
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