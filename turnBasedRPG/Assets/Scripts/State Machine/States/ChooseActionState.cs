using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseActionState : State
{
    int index;
    public override void Enter()
    {
        MoveSelector(Turn.unit.tile);
        base.Enter();
        index = 0;
        ChangeUISelector();
        CheckAction();
        inputs.OnMove += OnMove;
        inputs.OnFire += OnFire;
        machine.chooseActionPanel.MoveTo("Show");
    }

    public override void Exit()
    {
        base.Exit();
        inputs.OnMove -= OnMove;
        inputs.OnFire -= OnFire;
        machine.chooseActionPanel.MoveTo("Hide");
    }

    void OnMove(object sender, object args)
    {
        Vector3Int button = (Vector3Int)args;
        if(button == Vector3Int.left)
        {
            index--;
            ChangeUISelector();
        }else if(button == Vector3Int.right)
        {
            index++;
            ChangeUISelector();
        }
    }

    void OnFire(object sender, object args)
    {
        int button = (int)args;

        if (button == 1)
        {
            ActionButtons();
        }else if (button == 2)
        {
            machine.ChangeTo<RoamState>();
        }
    }

    void ChangeUISelector()
    {
        if (index == -1)
        {
            index = machine.chooseActionButtons.Count - 1;
        }else if(index == machine.chooseActionButtons.Count)
        {
            index = 0;
        }

        machine.chooseActionSelection.transform.localPosition =
        machine.chooseActionButtons[index].transform.localPosition;
    }

    void ActionButtons()
    {
        Debug.Log(index);

        switch (index)
        {
            case 0:
                if(!Turn.hasMoved)
                    machine.ChangeTo<MoveSelectionState>();
                break;
            case 1:
                //machine.ChangeTo<ActionSelectState>();
                break;
            case 2:
                //machine.ChangeTo<ItemSelectState>();
                break;
            case 3:
                machine.ChangeTo<TurnEndState>();
                break;
                                           
        }
    }

    void CheckAction()
    {
        PaintButton(machine.chooseActionButtons[0], Turn.hasMoved);
        PaintButton(machine.chooseActionButtons[1], Turn.hasActed);
        PaintButton(machine.chooseActionButtons[2], Turn.hasActed);
    }

    void PaintButton(Image image, bool check)
    {
        if (check)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
