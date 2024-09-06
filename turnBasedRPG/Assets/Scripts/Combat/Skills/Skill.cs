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
    public List<TileLogic> GetTargets()
    {
        List<TileLogic> targets = new List<TileLogic>();

        targets.Add(StateMachineController.instance.selectedTile);
        return targets;
    }
    public void Effect()
    {


        for(int i=0; i<Turn.targets.Count; i++)
        {
            FilterContent();

            Unit unit = Turn.targets[i].content.GetComponent<Unit>();
            if (unit != null)
            {
                Debug.LogFormat("{0} estava com {1} de HP, foi afetado por {2} e ficou com {3}",
                    unit, unit.GetStat(StatEnum.HP), -damage, unit.GetStat(StatEnum.HP) - damage);
                unit.SetStat(StatEnum.HP, -damage);
            }
        }
    }

    void FilterContent()
    {
        Turn.targets.RemoveAll((x) => x.content == null);
    }
}
