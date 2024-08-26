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
    void Awake()
    {
        instance = this;
    }

    public void CriaUnidades()
    {
        GameObject holder = new GameObject("Units Holder");
        holder.transform.parent = Board.instance.transform;

        Unit unidade = Instantiate(UnitPrefab, Board.GetTile(new Vector3Int(0, 0, 0)).worldPos,
        Quaternion.identity, holder.transform);

    }
}
