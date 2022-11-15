using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gade6122_Part1_corrected
{
    [System.Serializable]
    public class GameEngine
    {
        Map map;
        SwampCreature swampcreature;
        Enemy enemy;
        Mage mage;
        private Enemy[] enemies;

        public Enemy[] Enemies => enemies;
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

        public bool isGameOver
        {
            get { return map.Hero.IsDead; }
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

            Item item = map.GetItemAtPosition(map.Hero.X, map.Hero.Y);
            if (item != null)
            {
                map.Hero.Pickup(item);
            }
            map.UpdateMap();
            return true;
        }
        public string PlayerAttack(Movement direction)
        {
            if (isGameOver)
            {
                return "Game is Over";
            }
            if (direction == Movement.NoMovemnt)
            {
                return "Attack Failed!";
            }
            Tile tile = map.Hero.Vision[(int)direction];
            if (tile is Enemy)
            {
                Enemy enemy = (Enemy)tile;
                map.Hero.Attack(enemy);
                MoveEnemies();
                EnemiesAttack();

                map.UpdateMap();
                map.UpdateVision();

                return "Hero attacked: " + enemy.ToString();
            }
            return "Attack Failed, no enemy in this direction";
        }

        private void EnemiesAttack()
        {
            foreach (Enemy enemy in map.Enemies)
            {
                if (enemy.IsDead)
                {
                    continue;
                }
                if (enemy is Mage)
                {
                    MageAttack((Mage)enemy);
                }
                else if (enemy is SwampCreature)
                {
                    SwampCreatureAttack((SwampCreature)enemy);
                }
            }
        }
        private void MageAttack(Mage mage)
        {
            foreach (Enemy target in map.Enemies)
            {
                if (mage.CheckRange(target))
                {
                    mage.Attack(target);
                }
            }
        }

        private void SwampCreatureAttack(SwampCreature swampcreature)
        {
            if (swampcreature.CheckRange(map.Hero))
            {
                swampcreature.CheckRange(map.Hero);
            }
        }

        private void MoveEnemies()
        {
          
            foreach(Enemy enemy in map.Enemies)
            {
                if (enemy.IsDead)
                {
                    continue;
                }

                Movement movement = enemy.ReturnMove();
                enemy.Move(movement);
            }

        }

        const string SAVE_FILE_NAME = "save.sf";
        public void Save()
        {
            FileStream stream = new FileStream(SAVE_FILE_NAME, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, map);
        }

        public void Load()
        {
            FileStream stream = new FileStream(SAVE_FILE_NAME, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            map = (Map)bf.Deserialize(stream);

            stream.Close();

         
            map.UpdateVision();
            map.UpdateMap();
        }




    }
}

