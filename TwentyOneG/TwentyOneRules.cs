using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneG
{
    public class TwentyOneRules
    {
        private static readonly Dictionary<Face, int> _CardValues = new Dictionary<Face, int>()
       
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1
        };
        private static readonly object v;

        private static int[] GetAllPossibleHandValues(List<Card> Hand)
        {
            int account = Hand.Count(x => x.Face == Face.Ace);
            int[]result = new int[account + 1];
            int value = Hand.Sum(x => _CardValues[x.Face]);
            result[0] = value;
            if (result.Length == 1)
            {
                return result;
            }
            for (int i = 1; i < result.Length; i++)
            {
                value += (i * 10);
                result[i] = value;    
            }
            return result;
        }
        public static bool CheckForBlackJack(List<Card> Hand)
        {
            int[] possibleValues = GetAllPossibleHandValues(Hand);
            int value = possibleValues.Max();
            if (value == 21) return true;
            else return false;
        }
        public static bool IsBusted(List<Card> Hand)
        {
            int value = GetAllPossibleHandValues(Hand).Max();
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand) => ShouldDealerStay(Hand, v);

        private static bool ShouldDealerStay(List<Card> hand, object v)
        {
            throw new NotImplementedException();
        }

        public static bool ShouldDealerStay(List<Card>Hand, bool v)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);
            foreach (int values in possibleHandValues)
            {
                if (values > 16 && v)
                {
                    return true;
                }
            }
            return false;
        } 
        public static bool? CompareHands(List<Card>PlayerHand, List<Card> Dealer)
        {
            int[] playerResults = GetAllPossibleHandValues(PlayerHand);
            int[] dealerResults = GetAllPossibleHandValues(Dealer);

            int playerScore = playerResults.Where(x => x < 22).Max();
            int dealerScore = dealerResults.Where(x => x < 22).Max();

            if (playerScore > dealerScore) return true;
            else if (playerScore < dealerScore) return false;
            else
            {
                return null;
            }
        }
    }
}
