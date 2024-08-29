using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBeginState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(SelectUnit());
    }
    IEnumerator SelectUnit()
    {
        BreakDraw();
        machine.units.Sort((x, y) => x.ChargeTime.CompareTo(y.ChargeTime));
        Turn.unit = machine.units[0];

        yield return null;
        machine.ChangeTo<ChooseActionState>();
    }

    void BreakDraw()
    {
        for(int i=0; i<machine.units.Count; i++)
        {
            if (machine.units[i].ChargeTime == machine.units[i + 1].ChargeTime)
                machine.units[i + 1].ChargeTime += 1;
        }
    }
}
