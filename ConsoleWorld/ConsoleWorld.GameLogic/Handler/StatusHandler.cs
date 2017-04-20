namespace ConsoleWorld.GameLogic.Handler
{
    using Data;
    using Models;
    using System;

    public class StatusHandler
    {
        private const int StartX = 3;
        private const int StartY = 26;

        public void Draw(Character character, int dungeonLevel)
        {

            Console.SetCursorPosition(StartX, StartY);
            Console.Write($"Name: {character.Name} the {character.Class.ToString()} " + 
                $"LVL: {character.LevelId}  " +
                $"EXP: {character.Exp} / {Utility.GetExpToNextLevel(character.Id)}  " +
                //$"EXP: {character.Exp} / 1000  " +
                $"DUNGEON LVL: {dungeonLevel}");
            Console.SetCursorPosition(StartX, StartY + 1);
            Console.Write(
                $"HP: {character.Hp} / {character.MaxHp}  " +
                $"MP: {character.Mp} / {character.MaxMp}  " +
                $"$: {character.Money}  " +
                $"Points: {character.Points}");
            Console.SetCursorPosition(StartX, StartY + 2);
            Console.Write(
                $"ATK: {character.Attack}  " +
                $"MATK: {character.MagicAttack}  " +
                $"DEF: {character.Defense}  " +
                $"MDEF: {character.MagicDefense}  " +
                $"EV: {character.Evade}%  " +
                $"ACC: {character.Accuracy}%  " +
                $"RANGE: {character.Range}");
        }
    }
}