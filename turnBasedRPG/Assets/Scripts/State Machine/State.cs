using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected InputController inputs { get { return InputController.instance; } }
    protected StateMachineController machine { get { return StateMachineController.instance; } }

   public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    protected void OnMoveTileSelector(object sender, object args)
    {
        Vector3Int input = (Vector3Int)args;
        TileLogic t = Board.GetTile(Selector.instance.position + input);

        if (t != null)
        {
            MoveSelector(t);
        }
    }

    protected void MoveSelector(Vector3Int pos)
    {
        MoveSelector(Board.GetTile(pos));
    }

    protected void MoveSelector(TileLogic t)
    {
        Selector.instance.tile = t;
        Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;
        Selector.instance.transform.position = t.worldPos;
        machine.selectedTile = t;
    }
}
