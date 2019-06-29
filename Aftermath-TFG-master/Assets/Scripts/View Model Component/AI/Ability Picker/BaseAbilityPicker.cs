using UnityEngine;
using System.Collections;

public abstract class BaseAbilityPicker : MonoBehaviour
{
	#region Fields
	protected Unit owner;
	protected AbilityCatalog ac;
    BattleController bc;
    protected BattleMessageController bmc;
    protected ComputerPlayer cp;
	#endregion

	#region MonoBehaviour
	void Start ()
	{
		owner = GetComponentInParent<Unit>();
		ac = owner.GetComponentInChildren<AbilityCatalog>();
        bc = gameObject.transform.parent.parent.parent.parent.gameObject.GetComponent<BattleController>();
        bmc = bc.GetComponentInChildren<BattleMessageController>();
        cp = bc.gameObject.GetComponent<ComputerPlayer>();

    }
	#endregion

	#region Public
	public abstract void Pick (PlanOfAttack plan);
	#endregion
	
	#region Protected
	protected Ability Find (string abilityName)
	{
        for (int i = 0; i < ac.transform.childCount; ++i)
		{
			Transform category = ac.transform.GetChild(i);
			Transform child = category.Find(abilityName);
			if (child != null)
				return child.GetComponent<Ability>();
		}
		return null;
	}

	protected Ability Default ()
	{
		return owner.GetComponentInChildren<Ability>();
	}
	#endregion
}