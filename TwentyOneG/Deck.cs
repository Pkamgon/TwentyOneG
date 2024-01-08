using System;

namespace TwentyOneG
{
    public class Deck
    {
        public object Cards { get; internal set; }

        internal void Shuffle()
        {
            //throw new NotImplementedException();
        }

        public static implicit operator Deck(Dealer v)
        {
            throw new NotImplementedException();
        }
    }
}