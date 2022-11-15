using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    public abstract class Weapon
    {
        protected int damage;
        public int range;
        protected int durability;
        protected int cost;
        protected string weaponType;

        public int Damage { get { return damage; } }
        public int Range { get { return range; } }
        public int Durability { get { return durability; } }
        public int Cost { get { return cost; } }
        public string WeaponType { get { return weaponType; } }
    }

  




    
}
