using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSequenceState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(MoveSequence());
    }

    IEnumerator MoveSequence()
    {
        List<TileLogic> path = new List<TileLogic>();
        path.Add(machine.selectedTile);

        Movement movement = Turn.unit.GetComponent<Movement>();
        yield return StartCoroutine(movement.Move(path));
        Turn.unit.tile = machine.selectedTile;
        yield return new WaitForSeconds(0.2f);
        Turn.hasMoved = true;
        machine.ChangeTo<ChooseActionState>();
    }
}
