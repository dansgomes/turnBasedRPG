using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformSkillState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(PerformSequence());
    }

    IEnumerator PerformSequence()
    {
        yield return null;
        Turn.targets = Turn.skill.GetTargets();
        yield return null;
        Turn.skill.Effect();
        yield return new WaitForSeconds(1.5f);
        machine.ChangeTo<TurnEndState>();
    }
}
