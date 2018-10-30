using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RTSGame2018
{
    class GameEngine : MonoBehaviour
    {
        Map map = new Map();
        List<GameObject> objects = new List<GameObject>();
        float time = 0;

        private void Start()
        {
            float xStart = -4.78f;
            float yStart = 4.78f;
            var tileSize = new Vector2(0.5f, 0.5f);

            map.generateMap();
            //Debug.Log("Number of units: " + Map.NumberOfUnitsOnMap.ToString());
            foreach(Building temp in map.Buildings)
            {
                if (temp != null)
                {
                    var buildingType = temp.GetType().ToString();
                    var xPos = temp.x * tileSize.x + xStart;
                    var yPos = -temp.y * tileSize.y + yStart;

                    if (buildingType.Contains("ResourceBuilding"))
                    {
                        if (temp.tm)
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueResourceBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);

                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RedResourceBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                    }

                    if (buildingType.Contains("FactoryBuilding"))
                    {
                        if (temp.tm)
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueFactoryBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RedFactoryBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                    }
                }
            }

            foreach(Unit temp in map.Units)
            {
                if (temp != null)
                {
                    var unitType = temp.GetType().ToString();
                    var xPos = temp.x * tileSize.x + xStart;
                    var yPos = -temp.y * tileSize.y + yStart;

                    if (unitType.Contains("MeleeUnit"))
                    {
                        if (temp.Team)
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueWarrior"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RedWarrior"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                    }
                    
                    else if (unitType.Contains("RangerUnit"))
                    {
                        if (temp.Team)
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueArcher"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RedArcher"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                    }

                    else if (unitType.Contains("WizardUnit"))
                    {
                        if (temp.Team)
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueWizard"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RedWizard"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                    }

                    else if (unitType.Contains("HeroUnit"))
                    {
                        if (temp.Team)
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueHero"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RedHero"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                    }

                    else if (unitType.Contains("HealerUnit"))
                    {
                        if (temp.Team)
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueHealer"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                        else
                        {
                            GameObject GO = ((GameObject)Instantiate(Resources.Load("RedHealer"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                            objects.Add(GO2);
                            objects.Add(GO);
                        }
                    }
                }
            }
        }

        private void Update()
        {
            time += Time.deltaTime;

            if (time >= 1)
            {
                foreach (GameObject thing in objects)
                {
                    Destroy(thing);
                }

                float xStart = -4.78f;
                float yStart = 4.78f;
                var tileSize = new Vector2(0.5f, 0.5f);

                //Debug.Log("Number of units: " + Map.NumberOfUnitsOnMap.ToString());
                foreach (Building temp in map.Buildings)
                {
                    if (temp != null)
                    {
                        var buildingType = temp.GetType().ToString();
                        var xPos = temp.x * tileSize.x + xStart;
                        var yPos = -temp.y * tileSize.y + yStart;

                        if (buildingType.Contains("ResourceBuilding"))
                        {
                            if (temp.tm)
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueResourceBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);

                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedResourceBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                objects.Add(GO2);
                                objects.Add(GO);
                            }
                        }

                        if (buildingType.Contains("FactoryBuilding"))
                        {
                            if (temp.tm)
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueFactoryBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp > 20)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedFactoryBuilding"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp > 20)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                        }
                    }
                }

                foreach (Unit temp in map.Units)
                {
                    if (temp != null)
                    {
                        var unitType = temp.GetType().ToString();
                        var xPos = temp.x * tileSize.x + xStart;
                        var yPos = -temp.y * tileSize.y + yStart;

                        if (unitType.Contains("MeleeUnit"))
                        {
                            if (temp.Team)
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueWarrior"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp == 3)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 1)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedWarrior"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp == 3)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 1)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                        }

                        else if (unitType.Contains("RangerUnit"))
                        {
                            if (temp.Team)
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueArcher"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp == 3)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 1)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedArcher"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp == 3)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp == 1)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                        }

                        else if (unitType.Contains("WizardUnit"))
                        {
                            if (temp.Team)
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueWizard"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp > 7)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp > 4)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.75Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp > 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp > 0)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedWizard"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp > 7)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp > 4)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.75Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp > 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp > 0)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                        }

                        else if (unitType.Contains("HeroUnit"))
                        {
                            if (temp.Team)
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("BlueHero"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp <= 20)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 15)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.75Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 10)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 5)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedHero"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp <= 20)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 15)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.75Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 10)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 5)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                        }

                        else if (unitType.Contains("HealerUnit"))
                        {
                            if (temp.Team)
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedHealer"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp <= 3)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 1)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                            else
                            {
                                GameObject GO = ((GameObject)Instantiate(Resources.Load("RedHealer"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                if (temp.hp <= 3)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("FullHealth"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 2)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.5Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                if (temp.hp < 1)
                                {
                                    GameObject GO2 = ((GameObject)Instantiate(Resources.Load("0.25Health"), new Vector3(xPos, yPos, -2), Quaternion.identity));
                                    objects.Add(GO2);
                                }
                                objects.Add(GO);
                            }
                        }
                    }
                }

                List<Unit> unitsToRemove = new List<Unit>();
                List<Building> buildingsToRemove = new List<Building>();

                foreach (Unit u in map.Units)
                {
                    if (!u.death())
                    {
                        if (u.canAttack(u.closestUnit(map.Units)))
                        {
                            u.combat(u.closestUnit(map.Units));
                        }
                        else
                        {
                            map.moveUnit(u);
                        }
                    }
                    else
                    {
                        unitsToRemove.Add(u);
                    }

                }

                foreach (ResourceBuilding b in map.Buildings.OfType<ResourceBuilding>())
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
                    map.Units.Remove(u);
                }

                foreach (Building b in buildingsToRemove)
                {
                    map.Buildings.Remove(b);
                }
                time = 0;
            }
        }   
    }
}
