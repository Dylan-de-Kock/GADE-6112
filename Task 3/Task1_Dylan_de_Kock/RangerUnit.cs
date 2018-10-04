using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1_Dylan_de_Kock
{
    class RangerUnit : Unit
    {
        #region constructors
        public RangerUnit()
        {

        }

        public RangerUnit(int x, int y, int health, int speed, int attack, int range, bool team, string symbol, string name)
            : base(x, y, health, speed, attack, range, team, symbol, name)
        {

        }
        #endregion

        public override bool moveTowards(string direction, string[,] map)
        {
            int y = 0;
            int x = 0;
            if (direction.Contains("N"))
            {
                if ((this.y - this.Speed) < 0)
                {
                    y = 0;
                }
                else
                {
                    y = (this.y - this.Speed);
                }

            }
            if (direction.Contains("S"))
            {
                if ((this.y + this.Speed) > 19)
                {
                    y = 19;
                }
                else
                {
                    y = (this.y + this.Speed);
                }
            }
            if (direction.Contains("E"))
            {
                if (this.x + this.Speed > 19)
                {
                    x = 19;
                }
                else
                {
                    x = (this.x + this.Speed);
                }
            }
            if (direction.Contains("W"))
            {
                if (this.x - this.Speed < 0)
                {
                    x = 0;
                }
                else
                {
                    x = (this.x - this.Speed);
                }
            }
            if (map[x, y] == " * ")
            {
                this.x = x;
                this.y = y;
                return true;
            }
            string[,] moveArea = new string[x, y];


            if (direction == "NE")
            {
                for (int i = 0; i < this.Speed; i++)
                {
                    for (int j = 0; j < this.Speed; j++)
                    {
                        if (map[x - i, y + j] == "*")
                        {
                            return true;
                        }
                    }
                }
            }

            if (direction == "NW")
            {
                for (int i = 0; i < this.Speed; i++)
                {
                    for (int j = 0; j < this.Speed; j++)
                    {
                        if (map[x + i, y + j] == "*")
                        {
                            return true;
                        }
                    }
                }
            }

            if (direction == "SW")
            {
                for (int i = 0; i < this.Speed; i++)
                {
                    for (int j = 0; j < this.Speed; j++)
                    {
                        if (map[x + i, y - j] == "*")
                        {
                            return true;
                        }
                    }
                }
            }

            if (direction == "SE")
            {
                for (int i = 0; i < this.Speed; i++)
                {
                    for (int j = 0; j < this.Speed; j++)
                    {
                        if (map[x - i, y - j] == "*")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override void combat(Unit target)
        {
            target.hp -= this.Attack;
        }

        public override bool canAttack(Unit target)
        {
            int xDifference = Math.Abs(this.x - target.x);
            int yDifference = Math.Abs(this.y - target.y);

            if (xDifference < 4 && yDifference < 4)
            {
                return true;
            }
            return false; 
        }

        public override Unit closestUnit(List<Unit> units)
        {
            Unit closestUnit = null;
            double closestRange = 5000;
            int xRange = 0;
            int yRange = 0;
            double rangeTot = 0;

            foreach (Unit unit in units)
            {
                if (unit.Team != this.Team)
                {
                    xRange = this.x - unit.x;
                    yRange = this.y - unit.y;

                    rangeTot = Math.Sqrt(Math.Pow(xRange, 2) + Math.Pow(yRange, 2));

                    if (rangeTot < closestRange)
                    {
                        closestRange = rangeTot;
                        closestUnit = unit;
                    }
                }

            }

            return closestUnit;
        }

        public override bool death()
        {
            return this.hp <= 0;
        }

        public override string ToString()
        {
            string output = "x: " + x + Environment.NewLine
                + "y: " + y + Environment.NewLine
                + "Health: " + hp + Environment.NewLine
                + "Speed: " + speed + Environment.NewLine
                + "Attack: " + attack + Environment.NewLine
                + "Attack Range: " + AttackRange + Environment.NewLine
                + "Team: " + team + Environment.NewLine
                + "Symbol: " + symbol + Environment.NewLine
                + "Name: " + Name + Environment.NewLine;

            return output;
        }

        public override void save()
        {
            try
            {
                FileStream outFileRanger = new FileStream(@"Files\\RangerUnit.txt", FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFileRanger);

                writer.WriteLine(x);
                writer.WriteLine(y);
                writer.WriteLine(health);
                writer.WriteLine(speed);
                writer.WriteLine(attack);
                writer.WriteLine(attackRange);
                writer.WriteLine(team);
                writer.WriteLine(symbol);
                writer.WriteLine(name);

                writer.Close();
                outFileRanger.Close();
            }
            catch (Exception fe)
            {
                Debug.WriteLine(fe.Message);
            }
        }
    }
}
