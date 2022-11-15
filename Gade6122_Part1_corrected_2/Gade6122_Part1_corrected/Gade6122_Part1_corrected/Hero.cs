using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    [System.Serializable]
    public class Hero : Character
    {
        public Hero(int x, int y, int hp) : base(x,y)
        {
            this.hp = hp;
            this.maxHp = hp;
            this.damage = 2;
        }
        //going to have to change for hero moving onto a GOLD or WEAPON tile for example
        //for now Hero can only move onto EmptyTiles
        public override Movement ReturnMove(Movement move = Movement.NoMovemnt)
        {
            if (move == Movement.NoMovemnt)
            {
                return move;
            }
            Tile toTile = vision[(int)move];
            if (toTile is EmptyTile || toTile is Gold)
            {
                return move;
            }
            
            return Movement.NoMovemnt;
        }
        public override string ToString()
        {
            return $"Player stats: \n" +
                $"HP: {hp}/{maxHp}\n" +
                $"Damage: {damage} \n" +
                $"[{x}, {y}]/n" + 
                $" Gold is: {goldPurse}";
                    
        }
    }
}
