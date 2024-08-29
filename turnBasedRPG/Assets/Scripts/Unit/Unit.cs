using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Stats stats;
    public int faction;
    public TileLogic tile;
    public int ChargeTime;
    void Awake()
    {
        stats = GetComponentInChildren<Stats>();
    }
    public int GetStat(StatEnum stat)
    {
        return stats.stats[(int)stat].value;
    }
    
}
