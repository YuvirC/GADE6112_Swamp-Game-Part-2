using System;

namespace Gade6122_Part1_corrected
{
    [System.Serializable]
    public class Gold : Item
    {
        private int goldAmount = 0;
        private static Random random = new Random();
        public int GoldAmount
        {
            get { return goldAmount; } 
        }
        public Gold(int x, int y) : base(x, y)
        {
            goldAmount = random.Next(1, 6);
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
