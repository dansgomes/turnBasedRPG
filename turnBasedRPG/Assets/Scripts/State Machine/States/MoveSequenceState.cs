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
        yield return new WaitForSeconds(0.5f);
        Turn.hasMoved = true;
        //machine.ChangeTo<TurnEndState>();
    }
}
