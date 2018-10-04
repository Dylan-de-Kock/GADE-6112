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
        public String[,] map = new string[20, 20];
        private List<Unit> units = new List<Unit>();
        private List<Building> buildings = new List<Building>();

        public List<Unit> Units { get { return units; } set {this.units = value; } }
        public List<Building> Buildings { get { return buildings; } set { this.buildings = value; } }

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

                buildings.Add(new ResourceBuilding(x, y, 10, true, "RB", 2, 10));
                map[x, y] = "RB";

                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                buildings.Add(new FactoryBuilding(x, y, 50, true, "FB", 2, 2));
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

                buildings.Add(new ResourceBuilding(x, y, 10, false, "rb", 2, 10));
                map[x, y] = "rb";

                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                buildings.Add(new FactoryBuilding(x, y, 50, false, "fb", 2, 2));
                map[x, y] = "fb";

            }

            for (int j = 0; j < 2; j++)
            {
                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                units.Add(new WizardUnit(x, y, 10, 1, 3, 3, true, "W", "Sorcerer"));
                map[x, y] = units.Last().Symbol;

                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                units.Add(new WizardUnit(x, y, 10, 1, 3, 3, false, "w", "Sorcerer"));
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

                units.Add(new HealerUnit(x, y, 3, 1, 3, 3, true, "H", "MakerBetter"));
                map[x, y] = units.Last().Symbol;

                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                }
                while (map[x, y] == "*");

                units.Add(new HealerUnit(x, y, 3, 1, 2, 3, false, "h", "MakerBetter"));
                map[x, y] = units.Last().Symbol;

            }

            do
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);
            }
            while (map[x, y] == "*");

            units.Add(new HeroUnit(x, y, 20, 1, 5, 1, true, "C", "Champion"));
            map[x, y] = units.Last().Symbol;

            do
            {
                x = rnd.Next(0, 20);
                y = rnd.Next(0, 20);
            }
            while (map[x, y] == "*");

            units.Add(new HeroUnit(x, y, 20, 1, 5, 1, false, "c", "Champion"));
            map[x, y] = units.Last().Symbol;

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
    #endregion

        //takes in a unit so it can move it on the map based on the updated information
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

    public void change()
        {
            Random rnd = new Random();
            int team = 0;

            foreach (Unit u in units)
            {
                team = rnd.Next(0, 1);
                if (team == 0)
                {
                    u.Team = false;
                    u.Symbol.ToLower();
                }
                else if (team == 1)
                {
                    u.Team = true;
                    u.Symbol.ToUpper();
                }
            }
        }

        //saves each class so that it can be called when the project is loaded again
    public void save()
        {
            FileStream outFileRanger = new FileStream(@"Files\\RangerUnit.txt", FileMode.Create, FileAccess.Write);
            outFileRanger.Close();
            FileStream outFileMelee = new FileStream(@"Files\\MeleeUnit.txt", FileMode.Create, FileAccess.Write);
            outFileMelee.Close();
            FileStream outFileHero = new FileStream(@"Files\\HeroUnit.txt", FileMode.Create, FileAccess.Write);
            outFileHero.Close();
            FileStream outFileHealer = new FileStream(@"Files\\HealerUnit.txt", FileMode.Create, FileAccess.Write);
            outFileHealer.Close();
            FileStream outFileWizard = new FileStream(@"Files\\WizardUnit.txt", FileMode.Create, FileAccess.Write);
            outFileWizard.Close();
            FileStream outFileResource = new FileStream(@"Files\\ResourceBuilding.txt", FileMode.Create, FileAccess.Write);
            outFileResource.Close();
            FileStream outFileFactory = new FileStream(@"Files\\FactoryBuilding.txt", FileMode.Create, FileAccess.Write);
            outFileFactory.Close();

            foreach (Unit u in units)
            {
                u.save();
            }
            foreach (Building b in buildings)
            {
                b.save();
            }
        }

        //a method that will read from each file that is written and load that into the map
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
            string name;
            int resourcesPerGameTick;
            int resourcesRemaining;
            int gameTicksPerProduction;
            int spawnPoint;
            try
            {
                inFile = new FileStream(@"Files\\FactoryBuilding.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();      // priming read
                while (input != null)
                {
                    xPosition = int.Parse(input);
                    input = reader.ReadLine();
                    yPosition = int.Parse(input);  
                    input = reader.ReadLine();
                    health = int.Parse(input);
                    input = reader.ReadLine();
                    team = bool.Parse(input);
                    input = reader.ReadLine();
                    symbol = input;
                    input = reader.ReadLine();
                    gameTicksPerProduction = int.Parse(reader.ReadLine());
                    input = reader.ReadLine();
                    spawnPoint = int.Parse(reader.ReadLine());

                    FactoryBuilding b = new FactoryBuilding(xPosition, yPosition, health, team, symbol, gameTicksPerProduction, spawnPoint);
                    buildings.Add(b);
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
                    input = reader.ReadLine();
                    yPosition = int.Parse(input);
                    input = reader.ReadLine();
                    health = int.Parse(input);
                    input = reader.ReadLine();
                    team = bool.Parse(input);
                    input = reader.ReadLine();
                    symbol = input;
                    input = reader.ReadLine();
                    resourcesPerGameTick = int.Parse(reader.ReadLine());
                    input = reader.ReadLine();
                    resourcesRemaining = int.Parse(reader.ReadLine());

                    ResourceBuilding b = new ResourceBuilding(xPosition, yPosition, health, team, symbol, resourcesPerGameTick, resourcesRemaining);
                    buildings.Add(b);
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
                    input = reader.ReadLine();
                    yPosition = int.Parse(input);
                    input = reader.ReadLine();
                    health = int.Parse(input);
                    input = reader.ReadLine();
                    speed = int.Parse(input);
                    input = reader.ReadLine();
                    attack = int.Parse(input);
                    input = reader.ReadLine();
                    attackRange = int.Parse(input);
                    input = reader.ReadLine();
                    team = bool.Parse(input);
                    input = reader.ReadLine();
                    symbol = input;
                    input = reader.ReadLine();
                    name = input;
                    MeleeUnit u = new MeleeUnit(xPosition, yPosition, health, speed, attack, attackRange, team, symbol, name);
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
                    input = reader.ReadLine();
                    yPosition = int.Parse(input);
                    input = reader.ReadLine();
                    health = int.Parse(input);
                    input = reader.ReadLine();
                    speed = int.Parse(input);
                    input = reader.ReadLine();
                    attack = int.Parse(input);
                    input = reader.ReadLine();
                    attackRange = int.Parse(input);
                    input = reader.ReadLine();
                    team = bool.Parse(input);
                    input = reader.ReadLine();
                    symbol = input;
                    input = reader.ReadLine();
                    name = input;
                    RangerUnit u = new RangerUnit(xPosition, yPosition, health, speed, attack, attackRange, team, symbol, name);
                    units.Add(u);
                    // secondary read
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
        }
    
    }
}