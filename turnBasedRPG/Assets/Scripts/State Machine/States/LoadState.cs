using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public override void Enter()
    {
        StartCoroutine(LoadSequence());
    }

    IEnumerator LoadSequence()
    {
        yield return StartCoroutine(Board.instance.InitSequence(this));
        yield return null;
        MapLoader.instance.CriaUnidades();
        yield return null;
        InitialTurnOrdering();
        
        StateMachineController.instance.ChangeTo<TurnBeginState>();
    }

    void InitialTurnOrdering()
    {
        for(int i=0; i<machine.units.Count; i++)
        {
            machine.units[i].ChargeTime = 100 - machine.units[i].GetStat(StatEnum.SPEED);
        }
    }
}
