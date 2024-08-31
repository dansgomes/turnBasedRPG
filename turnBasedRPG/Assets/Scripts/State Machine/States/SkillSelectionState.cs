using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionState : State
{

    public override void Enter()
    {
        base.Enter();
        inputs.OnMove += OnMove;
        inputs.OnFire += OnFire;
        currentUISelector = machine.skillSelectionSelection;
        machine.skillSelectionPanel.MoveTo("Show");
        ChangeUISelector(machine.skillSelectionButtons);
        //CheckSkills();
    }

    public override void Exit()
    {
        base.Exit();
        inputs.OnMove -= OnMove;
        inputs.OnFire -= OnFire;
        machine.skillSelectionPanel.MoveTo("Hide");
    }

    void OnFire(object sender, object args)
    {
        int button = (int)args;

        if (button == 1)
        {
            //ActionButtons();
        }
        else if (button == 2)
        {
            machine.ChangeTo<ChooseActionState>();
        }
    }

    void OnMove(object sender, object args)
    {
        Vector3Int button = (Vector3Int)args;
        if (button == Vector3Int.up)
        {
            index--;
            ChangeUISelector(machine.skillSelectionButtons);
        }
        else if (button == Vector3Int.down)
        {
            index++;
            ChangeUISelector(machine.skillSelectionButtons);
        }
    }
}
