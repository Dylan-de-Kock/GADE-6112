using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1_Dylan_de_Kock
{
    class FactoryBuilding : Building
    {
        private int unitsToProduce;
        private int gameTicksPerProduction;
        private int spawnPoint;

        #region constructors
        public FactoryBuilding()
        {

        }

        public FactoryBuilding(int x, int y, int hp, bool team, string symbol, int gameTicksPerProduction, int spawnPoint)
            : base(x, y, hp, team, symbol)
        {
            this.gameTicksPerProduction = gameTicksPerProduction;
            this.spawnPoint = spawnPoint;
        }
        #endregion

        public override bool death()
        {
            if (this.health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string output = "";
            output += "X: " + this.xPosition + "\n";
            output += "Y: " + this.yPosition + "\n";
            output += "Health: " + this.health + "\n";
            if (this.team == true)
            {
                output += "Team: Blue\n";
            }
            else
            {
                output += "Team: Red\n";
            }
            output += "Symbol: " + this.symbol;

            return output;
        }

        public override void save()
        {
            try
            {
            FileStream outFileFactory = new FileStream(@"Files\\FactoryBuilding.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFileFactory);

            writer.WriteLine(this.xPosition);
            writer.WriteLine(this.yPosition);
            writer.WriteLine(this.health);
            writer.WriteLine(this.team);
            writer.WriteLine(this.symbol);

            writer.Close();
            outFileFactory.Close();
        }
        catch (Exception fe)
        {
             Debug.WriteLine(fe.Message);
        }
}

        public Unit unitSpawn(Building b)
        {
            RangerUnit ru = new RangerUnit();
            MeleeUnit mu = new MeleeUnit();
            bool type = false;
            
            if (b.tm == true)
            {
                Random rnd = new Random();

                int unitType = rnd.Next(0, 2);
                int x = rnd.Next(0, 20);
                int y = rnd.Next(0, 20);

                if (unitType == 1)
                {
                    ru = new RangerUnit(x, y, 3, 1, 2, 1, true, "R", "Archer");
                    type = true;
                }
                else if (unitType == 2)
                {
                    mu = new MeleeUnit(x, y, 3, 2, 2, 1, true, "M", "Warrior");
                    type = false;
                }
            }

            else
            {
                Random rnd = new Random();

                int unitType = rnd.Next(0, 2);
                int x = rnd.Next(0, 20);
                int y = rnd.Next(0, 20);

                if (unitType == 1)
                {
                    ru = new RangerUnit(x, y, 3, 1, 2, 1, false, "r", "Archer");
                    type = true;
                }
                else if (unitType == 2)
                {
                    mu = new MeleeUnit(x, y, 3, 2, 2, 1, false, "m", "Warrior");
                    type = false;
                }
            }

            if (type == true)
            {
                return ru;
            }
            else
            {
                return mu;
            }
        }
        
    }
}
