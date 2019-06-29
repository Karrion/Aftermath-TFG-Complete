using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour 
{
	public Tile tile { get; protected set; }
	public Directions dir;
    public BattleMessageController bmc;
    

    public class Pair
    {
        public string unit, ability;
        public int damage;

        public Pair(string unitP, string abilityP)
        {
            unit = unitP;
            ability = abilityP;
            damage = 9999;
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() != this.GetType()) return false;
            Pair p = (Pair) obj;
            if (p.ability == this.ability && p.unit == this.unit) return true;
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1138330480;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(unit);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ability);
            hashCode = hashCode * -1521134295 + damage.GetHashCode();
            return hashCode;
        }
    }

    public ArrayList pairings = new ArrayList();
    public string lastState = "Default";

    public void Place (Tile target)
	{
		// Make sure old tile location is not still pointing to this unit
		if (tile != null && tile.content == gameObject)
			tile.content = null;
		
		// Link unit and tile references
		tile = target;
		
		if (target != null)
			target.content = gameObject;
        bmc = gameObject.transform.parent.parent.gameObject.GetComponentInChildren<BattleMessageController>();
    }

    public void Match ()
	{
		transform.localPosition = tile.center;
		transform.localEulerAngles = dir.ToEuler();
	}
}