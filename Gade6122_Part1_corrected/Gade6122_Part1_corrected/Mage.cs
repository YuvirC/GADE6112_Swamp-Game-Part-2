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

        public override Movement ReturnMove(Movement move = Movement.NoMovemnt) //MAGES DO NOT MOVE
        {
            
            return 0;       
        }

       


    }
    

    
}


