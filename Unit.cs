using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTSGame2018
{
    abstract class Unit
    {
        protected int xPosition;
        protected int yPosition;
        protected int health;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected bool team;
        protected string symbol;
        protected string name; //added the name

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
            set { symbol = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region constructors
        public Unit()
        {

        }

        public Unit(int x, int y, int health, int speed, int attack, int range, bool team, string symbol, string name)//added the name
        {
            this.xPosition = x;
            this.yPosition = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = range;
            this.team = team;
            this.symbol = symbol;
            this.name = name;
        }
        #endregion

        public abstract bool moveTowards(string direction, string[,] map);

        public abstract void combat(Unit target);

        public abstract bool canAttack(Unit target);

        public abstract Unit closestUnit(List<Unit> units);

        public abstract Building closestBuilding(List<Building> buildings);

        public abstract bool death();

        public abstract string ToString();

        public abstract void save();
    }
}
