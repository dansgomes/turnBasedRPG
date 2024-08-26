using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
    public override void Enter()
    {
        base.Enter();
        InputController.instance.OnMove += OnMove;
        InputController.instance.OnFire += OnFire;
        CheckNullPosition();
    }

    public override void Exit()
    {
        base.Exit();
        InputController.instance.OnMove -= OnMove;
        InputController.instance.OnFire -= OnFire;
    }

    void OnMove(object sender, object args)
    {
        Vector3Int input = (Vector3Int)args;
        TileLogic t = Board.GetTile(Selector.instance.position + input);

        if (t != null)
        {
            Selector.instance.tile = t;
            Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
            Selector.instance.transform.position = t.worldPos;
        }
    }

    void OnFire(object sender, object args)
    {
        int button = (int)args;

        if (button == 1)
        {

        }
        else if (button == 2)
        {
            StateMachineController.instance.ChangeTo<ChooseActionState>();
        }
    }

    void CheckNullPosition()
    {
        if (Selector.instance.tile == null)
        {
            TileLogic t = Board.GetTile(new Vector3Int(0,0,0));
            Selector.instance.tile = t;
            Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
            Selector.instance.transform.position = t.worldPos;
        }
    }
}
