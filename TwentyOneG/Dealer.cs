using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneG
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public Dealer Cards { get; set; }
        public Card  Card { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add((Card)Deck.Cards);
            //Console.WriteLine(Deck.Cards.First().Tostring() + "\n");
            //object value = Deck.Cards.RemoveAt(0);

        }

    }
}
