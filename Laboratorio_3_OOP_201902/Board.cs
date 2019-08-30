using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Board
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos
        private Dictionary<string, List<Card>>[] playerCards; 
        private List<SpecialCard> weatherCards;

        //Propiedades
        public Dictionary<string, List<Card>>[] PlayerCards
        {
            get
            {
                return this.playerCards; 
            }
        }
        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }


        //Constructor
        public Board()
        {
            this.playerCards = new Dictionary<string, List<Card>>[DEFAULT_NUMBER_OF_PLAYERS];
            this.playerCards[0] = new Dictionary<string, List<Card>>();
            this.playerCards[1] = new Dictionary<string, List<Card>>();
            this.weatherCards = new List<SpecialCard>();
        }

        //Metodos
        public void AddCard(Card card, int playerId = -1, string buffType = null)
        {
            //Combat o Special
            if (card.GetType().Name == nameof(CombatCard))
            {
                //Agregar la de combate a su fila correspondiente
                if (playerId == 0 || playerId == 1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId][card.Type].Add(card);
                    }
                    else
                    {
                        playerCards[playerId].Add(card.Type, new List<Card>() { card });
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }
            } 
            else
            {
                //Es capitan?
                if ((playerId == 0 || playerId == 1) && buffType == null)
                {
                    //Revisar si no se a agregado el capitan
                    if (!playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId].Add(card.Type, new List<Card>() { card });
                    }
                    else
                    {
                        throw new FieldAccessException("Player already has captain");
                    }   
                }
                //Es buffer?
                else if ((playerId == 0 || playerId == 1) && buffType != null)
                {
                    //Revisar si no se a agregado un buffer en la fila primero.
                    if (!playerCards[playerId].ContainsKey(card.Type + buffType))
                    {
                        playerCards[playerId].Add(card.Type + buffType, new List<Card>() { card });
                    }
                    else
                    {
                        throw new FieldAccessException($"Player has already played a buffer card in {buffType} row");
                    }
                }
                else
                {
                    weatherCards.Add(card as SpecialCard);
                }
            }
        }
        public void DestroyCards()
        {
            //Guardar las cartas de capitan en una variable temporal
            List<Card>[] captainCards = new List<Card>[DEFAULT_NUMBER_OF_PLAYERS] 
            {
                new List<Card>(playerCards[0]["captain"]),
                new List<Card>(playerCards[1]["captain"])
            };
            //Destruir todas las cartas
            this.playerCards = new Dictionary<string, List<Card>>[DEFAULT_NUMBER_OF_PLAYERS];
            this.playerCards[0] = new Dictionary<string, List<Card>>();
            this.playerCards[1] = new Dictionary<string, List<Card>>();
            this.weatherCards = new List<SpecialCard>();
            //Agregar nuevamente los capitanes
            AddCard(captainCards[0][0], 0);
            AddCard(captainCards[1][0], 1);
        }
        public int[] GetMeleeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas melee y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i=0; i < 2; i++)
            {
                if (playerCards[i].ContainsKey("melee"))
                {
                    foreach (CombatCard card in playerCards[i]["melee"])
                    {
                        totalAttack[i] += card.AttackPoints;
                    }
                }
            }
            return totalAttack;
            
        }
        public int[] GetRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas range y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                if (playerCards[i].ContainsKey("range"))
                {
                    foreach (CombatCard card in playerCards[i]["range"])
                    {
                        totalAttack[i] += card.AttackPoints;
                    }
                }
            }
            return totalAttack;
        }
        public int[] GetLongRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas longRange y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                if (playerCards[i].ContainsKey("longRange"))
                {
                    foreach (CombatCard card in playerCards[i]["longRange"])
                    {
                        totalAttack[i] += card.AttackPoints;
                    }
                }
            }
            return totalAttack;
        }
    }
}
