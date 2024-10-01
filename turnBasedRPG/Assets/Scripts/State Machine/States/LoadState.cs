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
        UnitAlliances();
        yield return null;
        
        StateMachineController.instance.ChangeTo<TurnBeginState>();
    }

    void InitialTurnOrdering()
    {
        for(int i=0; i<machine.units.Count; i++)
        {
            machine.units[i].ChargeTime = 100 - machine.units[i].GetStat(StatEnum.SPEED);
            machine.units[i].active = true;
        }
    }

    void UnitAlliances()
    {
        for(int i=0; i<machine.units.Count; i++)
        {
            SetUnitAlliance(machine.units[i]);
        }
    }

    void SetUnitAlliance(Unit unit)
    {
        for (int i=0; i < MapLoader.instance.alliances.Count; i++){
            if (MapLoader.instance.alliances[i].factions.Contains(unit.faction))
            {
                MapLoader.instance.alliances[i].units.Add(unit);
                return;
            }
        }
    }
}
