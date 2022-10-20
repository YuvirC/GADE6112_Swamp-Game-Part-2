using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Gade6122_Part1_corrected
{
    [Serializable]
    public class Map
    {
        private Tile[,] map;       
        private string[,] stringMap;
        private Hero hero;
        private Enemy[] enemies;
        private int enem;

        private int items;
        private Item[] item;
        public Gold gold;
        [NonSerialized] private Random ran;

        private int width;
        private int height;

        private Random random;

        public int Enemies
        {
            get { return enem; }
        }
        public Hero Hero           
        { 
            get { return hero; }
        }
        //GENERATION OF MAP
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numItems)
        {
            random = new Random();

            width = random.Next(minWidth, maxWidth);
            height = random.Next(minHeight, maxHeight);

            map = new Tile[width, height];
            InitialiseMap();

            enemies = new Enemy[numEnemies];
           // items = new Item[numItems];

            this.items = items;
            this.enemies = enemies;

            hero = (Hero)Create(TileType.Hero);
            for (int i = 0; i < enemies.Length; i++) //Enemy Array
            {
                enemies[i] = (Enemy)Create(TileType.Enemy);
            }
            UpdateVision();

            gold = (Gold)Create(TileType.Gold); //GOLD TO BE GENERATED ONTO THE MAP          
        }

        public void UpdateMap()
        {
            InitialiseMap();
            foreach (Enemy enemy in enemies)
            {
                map[enemy.X, enemy.Y] = enemy;
            }
            //place hero last so its not overwritten
            map[hero.X, hero.Y] = hero;
            UpdateVision();
        }

        public void UpdateVision()
        {
            hero.UpdateVision(map);
            foreach (Enemy enemy in enemies)
            {
                enemy.UpdateVision(map);
            }
        }
        //PICKUP ITEMS
        public void PickupItem()
        {

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (stringMap[x, y] == "G")
                    {
                        stringMap[x, y] = "H";
                    }
                }
            }
        }
        //CREATES THE TILES
        private Tile Create(TileType type)
        {
            int tileX = random.Next(1, width - 1);
            int tileY = random.Next(1, height - 1);

            while(!(map[tileX, tileY] is EmptyTile))
            {
                tileX = random.Next(1, width - 1);
                tileY = random.Next(1, height - 1);
            }
            if (type == TileType.Hero)
            {
                map[tileX, tileY] = new Hero(tileX, tileY, 10);
            }

            else if (type == TileType.Enemy) //Generates Both MAGES and SWAMP CREATURES
            {
                int enemyType = random.Next(0,2);
                if (enemyType == 0)
                {
                    map[tileX, tileY] = new SwampCreature(tileX, tileY);
                }
                else if (enemyType == 1)
                {
                    map[tileX, tileY] = new Mage(tileX, tileY);

                }
            }
            else if (type == TileType.Gold) // Generate Gold onto the Map
            { 
                int goldType = random.Next(0);
                if (goldType == 0)
                {
                    map[tileX, tileY] = new Gold(tileX, tileY);
               
                }            
            }
            return map[tileX, tileY];
        }
        //INITIALISES THE MAP
        private void InitialiseMap()
        {
            for(int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        map[x, y] = new Obstacle(x, y);

                    }
                    else
                    {
                        map[x, y] = new EmptyTile(x, y);
                    }
                }
            }
        }
        //GETS ITEM POSITIONS FOR ITEMS FOUND ON THE MAP
        public Item GetItemAtPosition(int x, int y)
        {
            for (int i = 0; i <= items; i++)
            {
                if (gold.X == x && gold.Y == y)
                {
                    return gold;                   
                }
            }
            return null;
        }

        public override string ToString()
        {
            string s = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tile tile = map[x, y];
                    if (tile is EmptyTile)
                    {
                        s += ".";
                    }
                    else if (tile is Obstacle)
                    {
                        s += "X";
                    }
                    else if (tile is Gold) //SHOWS THE GOLD ONTO THE MAP
                    {
                        s += "@";
                    
                    }
                    else if (tile is Hero)
                    {
                        s += "H";
                    }
                    else if (tile is Enemy)
                    {
                        Enemy enemy = (Enemy)tile;
                        if (enemy.IsDead)
                        {
                            s += '†';
                        }
                        else if (tile is SwampCreature) //DISPLAYS BETWEEN SWAMP CREATURES AND MAGES
                        {
                            s += "S";
                        }
                        else 
                        {
                            s += "M";
                        }

                    }                    
                }
                s += "\n";
            }
            return s;
        }
       
    }
}
