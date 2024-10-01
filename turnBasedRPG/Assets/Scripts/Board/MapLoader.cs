using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public Unit UnitPrefab;

    //job
    //objetos do mapa
    //localização das unidades nesse mapa
    public static MapLoader instance;
    GameObject holder;
    public List<Alliance> alliances;

    void Awake()
    {
        instance = this;
        holder = new GameObject("Units Holder");
    }

    private void Start()
    {
        holder.transform.parent = Board.instance.transform;
        InitializeAlliances();
    }

    void InitializeAlliances()
    {
        for (int i=0; i<alliances.Count; i++)
        {
            alliances[i].units = new List<Unit>();
        }
    }

    public void CriaUnidades()
    {
        Unit unit1 = CreateUnit(new Vector3Int(2, 1, 0), "Jogador");
        Unit unit2 = CreateUnit(new Vector3Int(6, 2, 0), "Inimigo");

        StateMachineController.instance.units.Add(unit1);
        StateMachineController.instance.units.Add(unit2);

        unit1.faction = 0;
        unit2.faction = 1;
    }

    public Unit CreateUnit(Vector3Int pos, string name)
    {
        TileLogic t = Board.GetTile(pos);
        Unit unit = Instantiate(UnitPrefab, t.worldPos,
        Quaternion.identity, holder.transform);
        unit.tile = t;
        unit.name = name;
        t.content = unit.gameObject;

        for (int i=0; i<unit.stats.stats.Count; i++)
        {
            unit.stats.stats[i].value = Random.Range(1, 100);
        }

        return unit;
    }
}
