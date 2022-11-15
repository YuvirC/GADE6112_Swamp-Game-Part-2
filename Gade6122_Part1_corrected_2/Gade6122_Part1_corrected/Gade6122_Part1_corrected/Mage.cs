using System;

namespace Gade6122_Part1_corrected
{
    [System.Serializable]
    public class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 5, 5)
        {

        }
        public override Movement ReturnMove(Movement move = Movement.NoMovemnt)
        {
            return Movement.NoMovemnt;
        }

        public override bool CheckRange(Character target)
        {
            int xdist = Math.Abs(target.X);
            int ydist = Math.Abs(target.Y);

            if (xdist == 0 && ydist == 0)
            {
                return false;
            }

            if (xdist <= 0 && ydist <= 1)
            {
                return true;
            }

            return false;
        }

    }
}





