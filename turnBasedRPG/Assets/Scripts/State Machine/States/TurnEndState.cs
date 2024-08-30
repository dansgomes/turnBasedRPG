using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(AddUnitDelay());
    }

    IEnumerator AddUnitDelay()
    {
        Turn.unit.ChargeTime += 300;
        if (Turn.hasMoved)
            Turn.unit.ChargeTime += 100;    
        if (Turn.hasActed)     
            Turn.unit.ChargeTime += 100;
        Turn.unit.ChargeTime -= Turn.unit.GetStat(StatEnum.SPEED);

        Turn.hasActed = Turn.hasMoved = false;
        machine.units.Remove(Turn.unit);
        machine.units.Add(Turn.unit);
        yield return new WaitForSeconds(0.5f);
        machine.ChangeTo<TurnBeginState>();
    }
}
