using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    public class Gold : Item
    {
        private int GoldAmount
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
         
        
    }

   
  
}
