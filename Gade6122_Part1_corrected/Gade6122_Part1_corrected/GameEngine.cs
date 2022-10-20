 using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Gade6122_Part1_corrected
{
    public class GameEngine
    {
        Map map;
        
        public string Display
        {
            get { return map.ToString(); }
        }
        public string HeroStats
        {
            get { return map.Hero.ToString(); }
        }
        public GameEngine()
        {
            map = new Map(10, 20, 10, 20, 8, 6);
        }
        public bool MovePlayer(Movement direction)
        {
            if (direction == Movement.NoMovemnt)
            {
                return false;
            }

            Movement validMove = map.Hero.ReturnMove(direction);
            if (validMove == Movement.NoMovemnt)
            {
                return false;
            }
            

            


            map.Hero.Move(validMove);
            map.UpdateMap();
            return true;
        }
        public string PlayerAttack(Movement direction)
        {
            if (direction == Movement.NoMovemnt)
            {
                return "Attack Failed!";
            }
            Tile tile = map.Hero.Vision[(int)direction];
            if (tile is Enemy)
            {
                Enemy enemy = (Enemy)tile;
                map.Hero.Attack(enemy);
                return "Hero attacked: " + enemy.ToString();
            }
            return "Attack Failed, no enemy in this direction";
        }

        public static void EnemyAttacks()
        { 
        
        }

        public static void EnemyMove()
        {
           

        }

        public void Save()
        {
            FileStream fs = new FileStream("Save.txt", FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);

            w.Write("Game Saved");
            w.Flush();
            w.Close();
            fs.Close();

            fs = new FileStream("Save.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine(sr.ReadToEnd());
            fs.Position = 0;
            BinaryReader br = new BinaryReader(fs);

            fs.Close();
        }

        public void Load()
        { 
        
        }
    }
}
