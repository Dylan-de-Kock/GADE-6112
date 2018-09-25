using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRTSGame
{
    class Map
    {
        Unit[,] map = new Unit[20, 20]; //creating a 2D array of units so you will always be able to keep track of where they are and what their values are.
        Unit[] blueRangers;
        Unit[] blueMelee;
        Unit[] redRangers;
        Unit[] redMelee;

        int bRangersTotal, bMeleeTotal, rRangersTotal, rMeleeTotal = 0;

        public Unit getUnitAt(int x, int y)
        {
            return map[x, y];
        }

        public Unit getBlueRangers(int i)
        {
            return blueRangers[i];
        }

        public Unit getBlueMelee(int i)
        {
            return blueMelee[i];
        }

        public Unit getRedRangers(int i)
        {
            return redRangers[i];
        }

        public Unit getRedMelee(int i)
        {
            return redMelee[i];
        }
        #region totals
        public int blueRangersTotal()
        {
            return bRangersTotal;
        }

        public int blueMeleeTotal()
        {
            return bMeleeTotal;
        }

        public int redRangersTotal()
        {
            return rRangersTotal;
        }

        public int redMeleeTotal()
        {
            return rMeleeTotal;
        }
        #endregion
        //initalizes the map 
        #region load
        public void loadMap()
        {
            Random rnd = new Random();

            int bRangers = rnd.Next(1, 5);
            int bMelee = 10 - bRangers;
            bRangersTotal = bRangers;
            bMeleeTotal = bMelee;

            int rRangers = rnd.Next(1, 5);
            int rMelee = 10 - bRangers;
            rRangersTotal = rRangers;
            rMeleeTotal = rMelee;

            blueRangers = new Unit[bRangers];
            blueMelee = new Unit[bMelee];
            redRangers = new Unit[rRangers];
            redMelee = new Unit[rMelee];

            Unit[] u = new Unit[bRangers + rRangers + bMelee + rMelee];

            #region while 
            int count = 0;

            while (count < bRangers)
            {

                int x = rnd.Next(1, 20);
                int y = rnd.Next(1, 20);

                if (map[x, y] != null)
                {
                    x = rnd.Next(1, 20);
                    y = rnd.Next(1, 20);
                }
                else
                {
                    map[x, y] = new RangerUnit(x, y, 5, 1, 1, 3, true, "R", this); // (this.) is giving the randomly generated map to each new unit made
                    blueRangers[count] = new RangerUnit(x, y, 5, 1, 1, 3, true, "R", this);
                    count++;
                }
                
            }

            count = 0;
            while (count < bMelee)
            {
                int x = rnd.Next(1, 20);
                int y = rnd.Next(1, 20);

                if (map[x, y] != null)
                {
                    x = rnd.Next(1, 20);
                    y = rnd.Next(1, 20);
                }
                else
                {
                    map[x, y] = new MeleeUnit(x, y, 10, 3, 2, 1, true, "M", this);
                    blueMelee[count] = new MeleeUnit(x, y, 10, 3, 2, 1, true, "M", this);
                    count++;
                }
            }
            /*
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j].Symbol == "M" || map[i, j].Symbol == "R" )
                    {
                         = map[i, j];
                    }
                }
            }*/

            count = 0;
            while (count < rRangers)
            {
                int x = rnd.Next(1, 20);
                int y = rnd.Next(1, 20);

                if (map[x, y] != null)
                {
                    x = rnd.Next(1, 20);
                    y = rnd.Next(1, 20);
                }
                else
                {
                    map[x, y] = new RangerUnit(x, y, 10, 3, 2, 1, false, "r", this);
                    redRangers[count] = new RangerUnit(x, y, 10, 3, 2, 1, false, "r", this); 
                    count++;
                }
            }

            count = 0;
            while (count < rMelee)
            {
                int x = rnd.Next(1, 20);
                int y = rnd.Next(1, 20);

                if (map[x, y] != null)
                {
                    x = rnd.Next(1, 20);
                    y = rnd.Next(1, 20);
                }
                else
                {
                    map[x, y] = new MeleeUnit(x, y, 10, 3, 2, 1, false, "m", this);
                    redMelee[count] = new MeleeUnit(x, y, 10, 3, 2, 1, false, "m", this);
                    count++;
                }
            }
            #endregion
        }
        #endregion
        //creates a string that will store all the values and send that out for lblMap to output
        #region drawMap
        public string drawMap()
        {
            string showMap = "";

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j] == null)
                    {
                        showMap += " * ";
                    }
                    else
                    {
                        showMap += map[i, j].Symbol;
                    }
                }
                showMap += "\n";
            }
            return showMap;
        }
        #endregion
        //takes in the unit and where it needs to move to based on the calculation done with moveTowards()
        #region moveUnit
        public string moveUnit(Unit u, int x, int y) //takes in the unit to work with as well as the x position and y position of where to move to
        {
            string showMap = "";
            map[u.x, u.y] = null;
            map[x, y] = u;
            u.x = x;
            u.y = y;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j] == null)
                    {
                        showMap += " * ";
                    }
                    else
                    {
                        showMap += map[i, j].Symbol;
                    }
                }
                showMap += "\n";
            }
            return showMap;
        }
        #endregion
        //calls the method to be used
        #region act
        public void act()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j] != null)
                    {
                        map[i, j].action(); //action() in Unit class
                    }
                }
            }
        }
        #endregion
    }
}
