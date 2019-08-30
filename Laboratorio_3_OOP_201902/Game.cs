using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;

        //Constructor
        public Game()
        {
            this.decks = new List<Deck>();
        }
        

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }

        public void ReadCards() {
            int cont = 0;
            string fileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files\Decks.txt";
            StreamReader reader = new StreamReader(fileLocation);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] position = line.Split();
                List<Card> cards = new List<Card>();
                if (position[0]!="END")
                {
                    if (position[0]!="START")
                    {
                        switch (position[0])
                        {
                            case "CombatCard":
                                
                                cards.Add(new CombatCard(position[1], position[2], position[3], int.Parse(position[4]), bool.Parse(position[5])));
                                break;
                            case "SpecialCard":
                                cards.Add(new SpecialCard(position[1], position[2],position[3]));
                                break;
                        }
                    }
                }
                else
                {
                    cont++;
                    Decks[cont].Cards = new List<Card>(cards);
                }
                
            }
            reader.Close();
        }
    }
}
