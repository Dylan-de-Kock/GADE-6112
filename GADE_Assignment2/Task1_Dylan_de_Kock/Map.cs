using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1_Dylan_de_Kock
{
    class Map
    {
        private String[,] map = new string[20, 20];
        private List<Unit> units = new List<Unit>();
        private List<Building> buildings = new List<Building>();

        public List<Unit> Units { get { return units; } set {this.units = value; } }

    #region generateMap
        public string generateMap()
        {
            string mapString = "";
            Random rnd = new Random();
            int rangers = rnd.Next(5, 10);
            int melee = 20 - rangers;
            int x = 0;
            int y = 0;

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                        map[i, j] = " * ";
                }
            }
                for (int j = 0; j < rangers; j++)
                {
                    do
                    {
                        x = rnd.Next(0, 20);
                        y = rnd.Next(0, 20);
                    }
                    while (map[x, y] == "*");

                    int team = rnd.Next(0, 2);
                    if (team == 1)
                    {
                        units.Add(new RangerUnit(x, y, 3, 1, 2, 1, true, "R", "Archer"));//added the name
                }
                    else
                    {
                        units.Add(new RangerUnit(x, y, 3, 1, 2, 1, false, "r", "Archer"));//added the name
                }

                    map[x, y] = units.Last().Symbol;
                }
            
                for (int j = 0; j < melee; j++)
                {
                    do
                    {
                        x = rnd.Next(0, 20);
                        y = rnd.Next(0, 20);
                    }
                    while (map[x, y] == "*");

                    int team = rnd.Next(0, 2);
                    if (team == 1)
                    {
                        units.Add(new MeleeUnit(x, y, 3, 2, 2, 1, true, "M", "Warrior"));//added the name
                    }
                    else
                    {
                        units.Add(new MeleeUnit(x, y, 3, 2, 2, 1, false, "m", "Warrior"));//added the name
                }

                    map[x, y] = units.Last().Symbol;
                }

            for (int j = 0; j < 2; j++)
            {
                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                buildings.Add(new ResourceBuilding(x, y, 50, true, "RB"));
                map[x, y] = "RB";

                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                buildings.Add(new FactoryBuilding(x, y, 50, true, "FB"));
                map[x, y] = "FB";
            }

            for (int j = 0; j < 2; j++)
            {
                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                buildings.Add(new ResourceBuilding(x, y, 50, false, "rb"));
                map[x, y] = "rb";

                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                buildings.Add(new FactoryBuilding(x, y, 50, false, "fb"));
                map[x, y] = "fb";

            }

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    mapString += map[i, j];
                }
                mapString += "\n";
            }
            return mapString;
        }

        public string resetMap()
        {
            string mapString = "";
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    map[i, j] = " * ";
                }
            }
            return mapString;
        }
    
    #endregion

    #region moveUnit
    public void moveUnit(Unit u)
    {
        string direction = "";
        int oldX = u.x;
        int oldY = u.y;

        Unit nearestUnit = u.closestUnit(units);

        if (nearestUnit.y - oldY > 0)
        {
                direction += "N";
        }
        else if (nearestUnit.y - oldY < 0)
        {
            direction += "S";
        }

        if (nearestUnit.x - oldX > 0)
        {
            direction += "E";
        }
        else if (nearestUnit.x - oldX < 0)
        {
            direction += "W";
        }


        u.moveTowards(direction, map);
            updateUnit(oldX, oldY, u);
    }
    #endregion

    public string mapTick()
    {

        string showMap = "";

        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                map[i, j] = " * ";
            }
        }
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (Unit u in units)
                {
                    if (u.x == i && u.y == j)
                    {
                        map[i, j] = u.Symbol;
                    }
                }

                foreach (Building b in buildings)
                    {
                        if (b.x == i && b.y == j)
                        {
                            map[i, j] = b.sym;
                        }
                    }
                    showMap += map[i, j];

            }
                showMap += "\n";
        }
            return showMap;
    }

    public void updateUnit(int oldX, int oldY, Unit u)
        {
            map[oldX, oldY] = " * ";
            map[u.x, u.y] = u.Symbol;
        }

    public int resourceBuilding()
        {
            int buildings = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j] == "RB")
                    {
                        buildings++;
                    }
                }
            }

            return buildings;
        }
/*
    public void loadMap()
        {
            FileStream inFile = null;
            StreamReader reader = null;
            string input;
            int xPosition;
            int yPosition;
            int health;
            int speed;
            int attack;
            int attackRange;
            bool team;
            string symbol;
            try
            {
                inFile = new FileStream(@"Files\\FactoryBuilding.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    xPosition = int.Parse(input);
                    yPosition = int.Parse(input);
                    health = int.Parse(input);
                    team = bool.Parse(input);
                    symbol = input;
                    FactoryBuilding b = new FactoryBuilding(xPosition, yPosition, health, team, symbol);
                    building.Add(b);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }

            try
            {
                inFile = new FileStream(@"Files\\ResourceBuilding.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    xPosition = int.Parse(input);
                    yPosition = int.Parse(input);
                    health = int.Parse(input);
                    team = bool.Parse(input);
                    symbol = input;
                    ResourceBuilding b = new ResourceBuilding(xPosition, yPosition, health, team, symbol);
                    building.Add(b);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }

            try
            {
                inFile = new FileStream(@"Files\\MeleeUnit.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    xPosition = int.Parse(input);
                    yPosition = int.Parse(input);
                    health = int.Parse(input);
                    speed = int.Parse(input);
                    attack = int.Parse(input);
                    attackRange = int.Parse(input);
                    team = bool.Parse(input);
                    symbol = input;
                    MeleeUnit u = new MeleeUnit(xPosition, yPosition, health, speed, attack, attackRange, team, symbol);
                    units.Add(u);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }

            try
            {
                inFile = new FileStream(@"Files\\RangerUnit.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    xPosition = int.Parse(input);
                    yPosition = int.Parse(input);
                    health = int.Parse(input);
                    speed = int.Parse(input);
                    attack = int.Parse(input);
                    attackRange = int.Parse(input);
                    team = bool.Parse(input);
                    symbol = input;
                    RangerUnit u = new RangerUnit(xPosition, yPosition, health, speed, attack, attackRange, team, symbol);
                    units.Add(u);
                    input = reader.ReadLine();      // secondary read
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();
                }
            }
        }*/
    }
   
}