using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    public class Gold : Item
    {
        private int amountGold;
        private Random randomGold;

        public int AmountGold
        {
            get { return amountGold; }
        }

        public Gold(int x, int y) : base(x, y)
        {
            randomGold = new Random();
            amountGold = randomGold.Next(0, 5);
        }

        public override string ToString()
        {
            return "";
        }


        /* private int GoldAmount
        {
            get { return GoldAmount; }
            set { GoldAmount = value; }
        
        }
        private Random randomGold;

    private int RandomGold
        { 
            get { return RandomGold; }
            set { RandomGold = value; } 

        
        }
        public Gold(int x, int y) : base(x, y)
        {
            Random rnd = new Random();
            int randomGold = rnd.Next(1, 5);             
        }
    } */
    }

   
  
}
