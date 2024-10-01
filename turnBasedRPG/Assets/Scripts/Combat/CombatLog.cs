using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombatLog 
{
    public static void CheckActive()
    {
        foreach(Unit u in StateMachineController.instance.units)
        {
            if (u.GetStat(StatEnum.HP) <= 0)
                u.active = false;
            else
                u.active = true;
        }
    }

    public static bool IsOver()
    {
        int activeAlliances = 0;
        for(int i=0; i<MapLoader.instance.alliances.Count; i++)
        {
            activeAlliances += CheckAlliance(MapLoader.instance.alliances[i]);
        }
        if (activeAlliances > 1)
            return false;
        return true;
    }

    public static int CheckAlliance(Alliance alliance)
    {
        int activeAlliance = 0;
        for (int i=0; i<alliance.units.Count; i++)
        {
            Unit currentUnit = alliance.units[i];
            if (currentUnit.active)
            {
                return 1;
            }
        }
        return 0;
    }
}
