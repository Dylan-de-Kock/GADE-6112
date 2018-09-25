using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Dylan_de_Kock
{
    abstract class Building
    {
        protected int xPosition;
        protected int yPosition;
        protected int health;
        protected bool team;
        protected string symbol;

        #region get/set
        public int x
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        public int y
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        public int hp
        {
            get { return health; }
            set { health = value; }
        }

        public bool tm
        {
            get { return team; }
            set { team = value; }
        }

        public string sym
        {
            get { return symbol; }
            set { symbol = value; }
        }
        #endregion

        #region constructors
        public Building()
        {

        }

        public Building(int x, int y, int hp, bool team, string symbol)
        {
            this.xPosition = x;
            this.yPosition = y;
            this.health = hp;
            this.team = team;
            this.symbol = symbol;
        }
        #endregion

        public abstract bool death();

        public abstract string ToString();

        public abstract void save();
    }
}
