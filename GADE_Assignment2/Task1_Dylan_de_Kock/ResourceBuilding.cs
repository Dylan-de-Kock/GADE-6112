using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1_Dylan_de_Kock
{
    class ResourceBuilding : Building
    {
        private string resourceType = "Coin";
        private int resourcesPerGameTick = 2;
        private int resourcesRemaining = 10;

        #region constructors
        public ResourceBuilding()
        {

        }

        public ResourceBuilding(int x, int y, int hp, bool team, string symbol)
            : base (x, y, hp, team, symbol)
        {

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

        public void generateResources()
        {
            if (resourcesRemaining >= 0)
            {
                resourcesRemaining -= resourcesPerGameTick;
            }
        }

        public override void save()
        {
            try
            {
                FileStream outFile = new FileStream(@"Files\\ResourceBuilding.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                writer.WriteLine(this.xPosition);
                writer.WriteLine(this.yPosition);
                writer.WriteLine(this.health);
                writer.WriteLine(this.team);
                writer.WriteLine(this.symbol);

                writer.Close();
                outFile.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
        }

    }
}
