using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConditionalAbilityPicker : BaseAbilityPicker
{
    public List<BaseAbilityPicker> pickers;
    public int max;
    public string abilityName;

    public override void Pick(PlanOfAttack finalPlan)
    {
        PlanOfAttack optionalPlan = new PlanOfAttack();
        PlanOfAttack plan = new PlanOfAttack();
        for (int i = 0; i < pickers.Count; i++)
        {
            BaseAbilityPicker p = pickers[i];
            p.Pick(plan);
            cp.Evaluate(plan);
            if (plan.ability == null)
            {
                optionalPlan = plan;
                continue;
            }
            Debug.Log(plan.ability.name);
            Debug.Log(plan.unit.name);
            string unit = plan.unit.name;
            string ability = plan.ability.name;
            Unit.Pair pair = new Unit.Pair(unit, ability);
            if (owner.pairings.Contains(pair))
            {
                pair = (Unit.Pair) owner.pairings[owner.pairings.IndexOf(pair)];
            }
            else
            {
                owner.pairings.Add(pair);
                max = pair.damage;
                abilityName = pair.ability;
            }
            if(pair.damage >= max)
            {
                max = pair.damage;
                abilityName = pair.ability;
                finalPlan.ability = plan.ability;
                finalPlan.target = plan.target;
                finalPlan.moveLocation = plan.moveLocation;
                finalPlan.fireLocation = plan.fireLocation;
                finalPlan.attackDirection = plan.attackDirection;
                finalPlan.unit = plan.unit;
            }
            bmc.Display("Current max: " + max + " by " + abilityName);
            StartCoroutine(Wait());
        }
        max = 0;
        if(finalPlan.ability == null)
        {
            finalPlan.ability = optionalPlan.ability;
            finalPlan.target = optionalPlan.target;
            finalPlan.moveLocation = optionalPlan.moveLocation;
            finalPlan.fireLocation = optionalPlan.fireLocation;
            finalPlan.attackDirection = optionalPlan.attackDirection;
            finalPlan.unit = optionalPlan.unit;
        }
        finalPlan.complete = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }
}