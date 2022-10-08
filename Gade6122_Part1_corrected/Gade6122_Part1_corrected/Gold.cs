using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    public class Gold : Item
    {
        private int GoldAmount;
        private Random randomGold;


        public Gold(int x, int y) : base(x, y)
        {
            Random rnd = new Random();
            int randGold = rnd.Next(1, 5);

            
        }
       

    }
  
}
