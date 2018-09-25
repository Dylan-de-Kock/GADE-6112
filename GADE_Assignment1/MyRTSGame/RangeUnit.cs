using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRTSGame
{
    class RangerUnit : Unit
    {
        Map m = new Map();

        public RangerUnit()
        {

        }
        public RangerUnit(int x, int y, int health, int speed, int attack, int range, bool team, string symbol, Map m)
            : base(x, y, health, speed, attack, range, team, symbol, m)
        {

        }
        //a claculation that takes in the closest units x and y coordinates and calculates the furthest point this unit can move towards it
        #region moveTowards
        public override string moveTowards()
        {
            int xu = 0;
            int yu = 0;
            int xc = 0;
            int yc = 0;

            xu = this.x;
            yu = this.y;

            closestUnit().x = x;
            closestUnit().y = y;

            int sy = Convert.ToInt32((Speed * (yc - yu)) / Math.Ceiling(Math.Sqrt(((xc - xu) * (xc - xu)) + ((yc - yu) * (yc - yu)))));
            int sx = Convert.ToInt32((Speed * (xc - xu)) / Math.Ceiling(Math.Sqrt(((yc - yu) * (yc - yu)) + ((xc - xu) * (xc - xu)))));

            this.x = sx;
            this.y = sy;

            return m.moveUnit(this, x, y);
        }
        #endregion
        //checks if attack range is true, if true means this unit is in combat
        #region combat
        public override bool combat()
        {
            if (aRange() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //checks if the targeted unit is in range
        #region aRange
        public override bool aRange()
        {
            Unit closest = closestUnit();
            int unit = Convert.ToInt32(Math.Ceiling(Math.Sqrt(closest.x * closest.x) + (closest.y * closest.y)));

            if (AttackRange >= unit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        //returns the closest unit
        #region closestUnit
        public override Unit closestUnit()
        {
            int shortestMelee = int.MaxValue;
            int shortestRanger = int.MaxValue;
            int meleeCount = 0;
            int rangerCount = 0;

            if (this.Team == false)
            {
                if (this.Symbol == "r")
                {
                    for (int i = 0; i < m.blueMeleeTotal(); i++)
                    {
                        if (shortestMelee > Math.Sqrt((this.x - m.getBlueMelee(i).x) * (this.x - m.getBlueMelee(i).x) + (this.y - m.getBlueMelee(i).y) * (this.y - m.getBlueMelee(i).y))) //just a distance not the unit
                        {
                            shortestMelee = Convert.ToInt32(Math.Ceiling(Math.Sqrt((this.x - m.getBlueMelee(i).x) * (this.x - m.getBlueMelee(i).x) + (this.y - m.getBlueMelee(i).y) * (this.y - m.getBlueMelee(i).y))));
                            meleeCount = i;
                        }
                    }

                    for (int i = 0; i < m.blueRangersTotal(); i++)
                    {
                        if (shortestRanger > Math.Sqrt((this.x - m.getBlueRangers(i).x) * (this.x - m.getBlueRangers(i).x) + (this.y - m.getBlueRangers(i).y) * (this.y - m.getBlueRangers(i).y))) //just a distance not the unit
                        {
                            shortestRanger = Convert.ToInt32(Math.Ceiling(Math.Sqrt((this.x - m.getBlueRangers(i).x) * (this.x - m.getBlueRangers(i).x) + (this.y - m.getBlueRangers(i).y) * (this.y - m.getBlueRangers(i).y))));
                            rangerCount = i;
                        }
                    }
                }
                if (shortestMelee < shortestRanger)
                {
                    return m.getBlueMelee(meleeCount);
                }
                else
                {
                    return m.getBlueRangers(rangerCount);
                }

            }
            else
            {
                if (this.Symbol == "R")
                {
                    for (int i = 0; i < m.redMeleeTotal(); i++)
                    {
                        if (shortestMelee > Math.Sqrt((this.x - m.getRedMelee(i).x) * (this.x - m.getRedMelee(i).x) + (this.y - m.getRedMelee(i).y) * (this.y - m.getRedMelee(i).y))) //just a distance not the unit
                        {
                            shortestMelee = Convert.ToInt32(Math.Ceiling(Math.Sqrt((this.x - m.getRedMelee(i).x) * (this.x - m.getRedMelee(i).x) + (this.y - m.getRedMelee(i).y) * (this.y - m.getRedMelee(i).y))));
                            meleeCount = i;
                        }
                    }

                    for (int i = 0; i < m.redRangersTotal(); i++)
                    {
                        if (shortestRanger > Math.Sqrt((this.x - m.getRedRangers(i).x) * (this.x - m.getRedRangers(i).x) + (this.y - m.getRedRangers(i).y) * (this.y - m.getRedRangers(i).y))) //just a distance not the unit
                        {
                            shortestRanger = Convert.ToInt32(Math.Ceiling(Math.Sqrt((this.x - m.getRedRangers(i).x) * (this.x - m.getRedRangers(i).x) + (this.y - m.getRedRangers(i).y) * (this.y - m.getRedRangers(i).y))));
                            rangerCount = i;
                        }
                    }
                }
                if (shortestMelee < shortestRanger)
                {
                    return m.getRedMelee(meleeCount);
                }
                else
                {
                    return m.getRedRangers(rangerCount);
                }

            }
        }
        #endregion

        public override bool death()
        {
            if (hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void action()
        {
            /*
            Unit closestU = closestUnit();
            if (this.combat() == false)
            {

                this.moveTowards(closestU.x, closestU.y);
            }
            else if (this.combat() == true)
            {

            }
            else if (this.aRange() == true)
            {

            }
            else if (this.hp < 2)
            {

            }*/
        }
    }
}
