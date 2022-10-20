 using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Gade6122_Part1_corrected
{
    public class GameEngine
    {
        Map map;

        //private Map map;

        private Random ran;

        private Hero hero;

        private Enemy enemy;

        private Mage mage;

        private SwampCreature swampCreature;

        private const string FILENAME = "Save.txt";
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
            map = new Map(10, 20, 10, 20, 8, 5);
        }

        //MOVES THE PLAYER AND UPDATES THE MAP
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
        //PLAYER ATTACKS THE ENEMY
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

        //ALLOWS FOR THE ENEMY TO ATTACK THE PLAYER
        public static void EnemyAttacks()
        { 

        
        }

        //ATTEMPTS TO ALLOW THE SWAMP CREATURE ONLY TO MOVE WHEN THE CHARACTER MOVES
        public static void EnemyMove()
        {
           

        }

        //ATTEMPTS TO SAVE GAME
        public void Save()
        {
            try
            {
                FileStream saveFile = new FileStream(
                FILENAME, FileMode.Create, FileAccess.Write
                );

                BinaryFormatter bWriter = new BinaryFormatter();

                bWriter.Serialize(saveFile, map);

                saveFile.Close();
            }
            catch (Exception ex)
            {

            }
        }

        //ATTEMPTS TO LOAD THE GAME TO THE MAP
        public void Load()
        {
            try
            {
                FileStream saveFile = new FileStream(
                FILENAME, FileMode.Open, FileAccess.Read
                );

                BinaryFormatter bReader = new BinaryFormatter();

                while (saveFile.Position < saveFile.Length)
                {
                    map = (Map)bReader.Deserialize(saveFile);

                }
                saveFile.Close();
            }
            catch (Exception error)
            {
                if (!(File.Exists(FILENAME)))
                {
                    MessageBox.Show("There's no saved file.");

                }
            }
        }


    }
}
