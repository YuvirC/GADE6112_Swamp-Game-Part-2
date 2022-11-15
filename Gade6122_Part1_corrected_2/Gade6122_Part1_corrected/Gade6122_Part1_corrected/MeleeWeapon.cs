using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    public enum Types
    {
        Daggers,
        Longswords
    }
    public class MeleeWeapon {

        protected int x;
        protected int y;
        protected Type type;

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }

       // public override int Range { get { return 1; } }

        public MeleeWeapon(int x, int y)
        {
            

            this.x = x;
            this.y = y;
        }
   }

        
}
