using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    public class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 5, 5) // MAGE HP DAMAGE AND POSITIONING
        {

        }

        public override Movement ReturnMove(Movement move = 0) //MAGES DO NOT MOVE
        {            
            return Movement.NoMovemnt;       
        }

        public override bool CheckRange(Character target) //CHECKS THE MAGES RANGE TO ATTACK AROUND A 1BLOCK RANGE
        {
            int distancex = Math.Abs(target.X - x);
            int distancey = Math.Abs(target.Y - y);
            int totdistance = distancex + distancey;
            if (totdistance == -2 || totdistance == 2 || totdistance == -1 || totdistance == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }


    }
    

    
}


