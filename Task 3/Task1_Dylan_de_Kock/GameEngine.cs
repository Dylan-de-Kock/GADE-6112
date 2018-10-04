using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Dylan_de_Kock
{
    class GameEngine
    {
        public void gameTick(Map m)
        {
            List<Unit> unitsToRemove = new List<Unit>();
            List<Building> buildingsToRemove = new List<Building>();

            foreach (Unit u in m.Units)
            {
                if (!u.death())
                {
                    if (u.canAttack(u.closestUnit(m.Units)))
                    {
                        u.combat(u.closestUnit(m.Units));
                    }
                    else
                    {
                        m.moveUnit(u);
                    }
                }
                else
                {
                    unitsToRemove.Add(u);
                }

            }

            foreach (ResourceBuilding b in m.Buildings.OfType<ResourceBuilding>())
            {
                b.generateResources();
                if (b.ResourcesRemaining < 1)
                {
                    b.hp--;
                    if (b.hp <= 0)
                    {
                        buildingsToRemove.Add(b);
                    }
                }
                else
                {

                }
            }
            foreach (Unit u in unitsToRemove)
            {
                m.Units.Remove(u);
            }

            foreach (Building b in buildingsToRemove)
            {
                m.Buildings.Remove(b);
            }
        }
        
    }
}
