using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRTSGame
{
    abstract class Unit
    {
        private int xPosition;
        private int yPosition;
        private int health;
        private int speed;
        private int attack;
        private int attackRange;
        private bool team;
        private string symbol;
        private Map currentMap; //made so that each unit is able to see the entire map

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

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }

        public bool Team
        {
            get { return team; }
            set { team = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value;}
        }

        public Unit()
        {

        }

        public Unit(int x, int y, int health, int speed, int attack, int range, bool team, string symbol, Map m)
        {
            this.xPosition = x;
            this.yPosition = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = range;
            this.team = team;
            this.symbol = symbol;
            this.currentMap = m;
        }

        public abstract string moveTowards();

        public abstract bool combat();

        public abstract bool aRange();

        public abstract Unit closestUnit();

        public abstract bool death();

        public string toString()
        {
            return "";
        }

        public abstract void action();
    }
}
