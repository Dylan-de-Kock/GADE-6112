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
            List<Unit> unitsToRemove= new List<Unit>();

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
            foreach (Unit u in unitsToRemove)
            {
                m.Units.Remove(u);
            }
        }
        
    }
}
