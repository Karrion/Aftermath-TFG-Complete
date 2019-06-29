using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InitBattleState : BattleState 
{
	public override void Enter ()
	{
		base.Enter ();
		StartCoroutine(Init());
	}
	
	IEnumerator Init ()
	{
		board.Load( levelData );
		Point p = new Point((int)levelData.tiles[0].x, (int)levelData.tiles[0].z);
		SelectTile(p);
		SpawnUnits();
		AddVictoryCondition();
		owner.round = owner.gameObject.AddComponent<TurnOrderController>().Round();
		yield return null;
		owner.ChangeState<CutSceneState>();
	}

    void SpawnUnits()
    {
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            string[] recipes = new string[]
            {
            "Alaois",
            "Hania",
            "Kamau",
            "Alphonse",
            "Roderick",
            "Enemy Scout",
            "Enemy Scout",
            "Enemy Warrior",
            "Enemy Warrior",
            "Enemy Mage"
            };

            GameObject unitContainer = new GameObject("Units");
            unitContainer.transform.SetParent(owner.transform);

            List<Tile> locations = new List<Tile>(board.tiles.Values);
            for (int i = 0; i < recipes.Length; ++i)
            {
                int level = 10;
                GameObject instance = UnitFactory.Create(recipes[i], level);
                instance.transform.SetParent(unitContainer.transform);

                for (int j = 0; j < locations.Count; j++)
                {
                    Tile tile = locations[j];
                    switch (i)
                    {
                        case 0:
                            if (tile.pos == new Point(7, 1))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)0;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 1:
                            if (tile.pos == new Point(8, 1))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)0;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 2:
                            if (tile.pos == new Point(9, 1))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)0;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 3:
                            if (tile.pos == new Point(6, 1))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)0;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 4:
                            if (tile.pos == new Point(10, 1))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)0;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 5:
                            if (tile.pos == new Point(1, 11))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)2;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 6:
                            if (tile.pos == new Point(2, 11))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)2;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 7:
                            if (tile.pos == new Point(3, 11))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)2;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 8:
                            if (tile.pos == new Point(4, 11))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)2;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 9:
                            if (tile.pos == new Point(5, 11))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)2;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        default:
                            break;

                    }
                }
            }
            SelectTile(units[0].tile.pos);
        }else if(SceneManager.GetActiveScene().name == "Test")
        {
            string[] recipes = new string[]
            {
            "Alaois",
            "Enemy Mage"
            };

            GameObject unitContainer = new GameObject("Units");
            unitContainer.transform.SetParent(owner.transform);

            List<Tile> locations = new List<Tile>(board.tiles.Values);
            for (int i = 0; i < recipes.Length; ++i)
            {
                int level = 10;
                GameObject instance = UnitFactory.Create(recipes[i], level);
                instance.transform.SetParent(unitContainer.transform);

                for (int j = 0; j < locations.Count; j++)
                {
                    Tile tile = locations[j];
                    switch (i)
                    {
                        case 0:
                            if (tile.pos == new Point(7, 1))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)0;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 1:
                            if (tile.pos == new Point(8, 1))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)0;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            SelectTile(units[0].tile.pos);
        }else if(SceneManager.GetActiveScene().name == "BattleFront")
        {
            string[] recipes = new string[]
            {
            "Alaois",
            "Kamau",
            "Hania",
            "Alphonse",
            "Roderick",
            "Enemy Mage",
            "Enemy Mage",
            "Enemy Scout",
            "Enemy Scout",
            "Enemy Warrior",
            "Enemy Warrior",
            "Enemy Warrior",
            "Enemy Warrior",
            "Enemy Warrior",
            "Enemy Warrior"
            };

            GameObject unitContainer = new GameObject("Units");
            unitContainer.transform.SetParent(owner.transform);

            List<Tile> locations = new List<Tile>(board.tiles.Values);
            for (int i = 0; i < recipes.Length; ++i)
            {
                int level = 10;
                GameObject instance = UnitFactory.Create(recipes[i], level);
                instance.transform.SetParent(unitContainer.transform);

                for (int j = 0; j < locations.Count; j++)
                {
                    Tile tile = locations[j];
                    switch (i)
                    {
                        case 0:
                            if (tile.pos == new Point(5, 3))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)1;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 1:
                            if (tile.pos == new Point(5, 4))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)1;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 2:
                            if (tile.pos == new Point(5, 5))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)1;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 3:
                            if (tile.pos == new Point(5, 6))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)1;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 4:
                            if (tile.pos == new Point(5, 7))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)1;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;

                            //UNIDADES ENEMIGAS

                        case 5:
                            if (tile.pos == new Point(13, 3))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 6:
                            if (tile.pos == new Point(13, 4))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 7:
                            if (tile.pos == new Point(13, 6))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 8:
                            if (tile.pos == new Point(13, 7))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 9:
                            if (tile.pos == new Point(12, 3))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 10:
                            if (tile.pos == new Point(12, 4))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 11:
                            if (tile.pos == new Point(12, 5))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 12:
                            if (tile.pos == new Point(12, 6))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 13:
                            if (tile.pos == new Point(12, 7))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case 14:
                            if (tile.pos == new Point(11, 5))
                            {
                                //locations.RemoveAt(j);
                                Unit unit = instance.GetComponent<Unit>();
                                unit.Place(tile);
                                unit.dir = (Directions)3;
                                unit.Match();
                                units.Add(unit);
                            }
                            else
                            {
                                break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            SelectTile(units[0].tile.pos);
        }
    }


    void AddVictoryCondition ()
	{
		DefeatTargetVictoryCondition vc = owner.gameObject.AddComponent<DefeatTargetVictoryCondition>();
		Unit enemy = units[ units.Count - 1 ];
		vc.target = enemy;
		Health health = enemy.GetComponent<Health>();
		health.MinHP = 10;
	}
}