using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Deck
    {

        private List<Card> cards;

        public Deck()
        {

        }

        public List<Card> Cards { get => cards; set => cards = value; }

        public void AddCard(Card card)
        {
            throw new NotImplementedException();
        }
        public void DestroyCard(int cardId)
        {
            throw new NotImplementedException();
        }
        public void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}
