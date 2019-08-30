using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;

namespace Laboratorio_3_OOP_201902
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            cards.Add(new CombatCard("Goblin", "melee", null, 5, false));
            cards.Add(new SpecialCard("Snow", "weather", "All LongRange attack points to 1"));
            cards.Add(new SpecialCard("General Harris", "captain", "All LongRange attack points to 10"));
            cards.Add(new SpecialCard("General Smith", "captain", "All Range attack points to 10"));
            cards.Add(new SpecialCard("Motivation", "buff", "All minions attack double on selected line"));
            cards.Add(new CombatCard("Destructor", "longRange", null, 10, true));
            Console.WriteLine(cards[1].GetType().Name == nameof(Card));
            Board board = new Board();
            board.AddCard(cards[2],0);
            board.AddCard(cards[1]);
            Console.WriteLine(board.PlayerCards[0]["captain"][0].Name);
            Console.WriteLine(board.WeatherCards[0].Name);
            board.AddCard(cards[3], 1);
            Console.WriteLine(board.PlayerCards[1]["captain"][0].Name);
            board.AddCard(cards[4], 0, "melee");
            Console.WriteLine(board.PlayerCards[0]["buffmelee"][0].Name);
            board.AddCard(cards[4], 0, "range");
            Console.WriteLine(board.PlayerCards[0]["buffrange"][0].Name);
            board.AddCard(cards[0], 0);
            Console.WriteLine(String.Join(", ", board.GetMeleeAttackPoints()));
            board.AddCard(cards[0], 0);
            Console.WriteLine(String.Join(", ", board.GetMeleeAttackPoints()));
            Console.WriteLine(String.Join(", ", board.GetRangeAttackPoints()));
            board.DestroyCards();
            Console.WriteLine(board.PlayerCards[0]["captain"][0].Name);
            Console.WriteLine(String.Join(", ", board.GetMeleeAttackPoints()));
            Console.WriteLine(String.Join(", ", board.GetRangeAttackPoints()));
            Console.WriteLine(board.WeatherCards.Count);
        }
    }
}
