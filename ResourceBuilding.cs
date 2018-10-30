using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace RTSGame2018
{
    class ResourceBuilding : Building
    {
        private string resourceType = "Resources";
        private int resourcesPerGameTick = 2;
        private int resourcesRemaining = 10;
        private int resourcesLeft = 10;

        public int resources { get { return resourcesLeft; } set { this.resourcesLeft = value; } }

        #region constructors
        public ResourceBuilding()
        {

        }

        public ResourceBuilding(int x, int y, int hp, bool team, string symbol, int resourcesPerGameTick, int resourcesRemaining)
            : base (x, y, hp, team, symbol)
        {
            this.resourcesPerGameTick = resourcesPerGameTick;
            this.resourcesRemaining = resourcesRemaining;
        }
        #endregion

        public int ResourcesPerGameTick
        {
            get { return ResourcesPerGameTick; }
            set { ResourcesPerGameTick = value; }
        }

        public int ResourcesRemaining
        {
            get { return resourcesRemaining; }
            set { resourcesRemaining = value; }
        }

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

        // constatly takes away however many resources are minused for each game tick
        public int generateResources()
        {
            if (resourcesRemaining >= 0)
            {
                resourcesRemaining -= resourcesPerGameTick;
            }

            resourcesLeft -= resourcesPerGameTick;
            return resourcesRemaining;
        }

        public override void save()
        {
            try
            {
                FileStream outFileResource = new FileStream(@"Files\\ResourceBuilding.txt", FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFileResource);

                writer.WriteLine(this.xPosition);
                writer.WriteLine(this.yPosition);
                writer.WriteLine(this.health);
                writer.WriteLine(this.team);
                writer.WriteLine(this.symbol);

                writer.Close();
                outFileResource.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
        }

    }
}
