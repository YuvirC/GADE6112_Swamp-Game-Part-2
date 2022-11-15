using System;
using System.Collections.Generic;
using System.Text;

namespace Gade6122_Part1_corrected
{
    [System.Serializable]
    public class Map
    {
        private Tile[,] map;
        private Hero hero;
        private Enemy[] enemies;
        private Item[] items;
        private int width;
        private int height;
        private Random random;
        public Hero Hero 
        { 
            get { return hero; }
        }

        public Enemy[] Enemies => enemies;
       
        public Item[] Items => items;
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numItems)
        {
            random = new Random();

            width = random.Next(minWidth, maxWidth);
            height = random.Next(minHeight, maxHeight);
            map = new Tile[width, height];
            InitialiseMap();
            enemies = new Enemy[numEnemies];
            items = new Item[numItems];
            hero = (Hero)Create(TileType.Hero);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = (Enemy)Create(TileType.Enemy);            
            }
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = (Item)Create(TileType.Gold);
            }


            UpdateVision();
         }

        public Item GetItemAtPosition(int x, int y)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    continue;
                }
                if (items[i].X == x && items[i].Y == y)
                {
                    Item item = items[i];
                    items[i] = null;
                    return item;
                }
            }
            return null;
        }

        public void UpdateVision()
        {
            hero.UpdateVision(map);
            foreach (Enemy enemy in enemies)
            {
                enemy.UpdateVision(map);
            }
        }
        public void UpdateMap()
        {
            InitialiseMap();

           
            foreach (Enemy enemy in enemies)
            {
                map[enemy.X, enemy.Y] = enemy;
            }

            foreach (Item item in items)
            {
                if (item is null)
                {
                    continue;
                }
                map[item.X, item.Y] = item;
            }
            //place hero last so its not overwritten
            map[hero.X, hero.Y] = hero;
            UpdateVision();
        }

        private Tile Create(TileType type)
        {
            int tileX = random.Next(1, width - 1);
            int tileY = random.Next(1, height - 1);

            while(!(map[tileX, tileY] is EmptyTile))
            {
                tileX = random.Next(1, width - 1);
                tileY = random.Next(1, height - 1);
            }
            if(type == TileType.Hero)
            {
                map[tileX, tileY] = new Hero(tileX, tileY, 10);
            }
            else if (type == TileType.Enemy)
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
            else if (type == TileType.Gold)
            {
                map[tileX, tileY] = new Gold(tileX, tileY);
            }
            return map[tileX, tileY];
        }
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
        public override string ToString()
        {
            string s = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tile tile = map[x, y];
                    if(tile is EmptyTile)
                    {
                        s += ".";
                    }
                    else if (tile is Obstacle)
                    {
                        s += "X";
                    }
                    else if (tile is Hero)
                    {
                        s += "H";
                    }
                    else if (tile is SwampCreature)
                    {
                        Enemy enemy = (Enemy)tile;
                        if (enemy.IsDead == false)
                        {
                            s += "S";
                        }
                       // s += "S";
                         if (enemy.IsDead)
                        {
                            s += "†";
                        }
                    }
                    else if (tile is Mage)
                    {
                        Enemy enemy = (Enemy)tile;
                        if (enemy.IsDead == false)
                        {
                            s += "M";
                        }
                        if (enemy.IsDead)
                        {
                            s += "D";
                        }
                    }
                    

                    else if (tile is Gold)
                    {
                        Gold gold = (Gold)tile;
                        s += gold.GoldAmount + "";
                    }

                }
                s += "\n";
            }
            return s;
        }
    }
}
