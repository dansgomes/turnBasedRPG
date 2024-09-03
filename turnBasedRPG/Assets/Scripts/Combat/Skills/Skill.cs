using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public int damage;
    public int manaCost;
    public Sprite icon;

    public bool CanUse()
    {
        if (Turn.unit.GetStat(StatEnum.MP) >= manaCost)
            return true;
        return false;
    }

    public bool ValidateTarget()
    {
        Unit unit = null;
        if (StateMachineController.instance.selectedTile.content != null)
            unit = StateMachineController.instance.selectedTile.content.GetComponent<Unit>();

        if (unit != null)
            return true;
        return false;
    }
}
