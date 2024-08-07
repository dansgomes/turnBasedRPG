using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic
{
    public Vector3Int pos;
    public Vector3 worldPos;
    public GameObject content;
    public Floor floor;
    public int contentOrder;
    //public TileType tileType;

    public TileLogic()
    {

    }

    public TileLogic(Vector3Int cellPos, Vector3 worldPosition, Floor tempfloor)
    {
        pos = cellPos;
        worldPos = worldPosition;
        floor = tempfloor;
        contentOrder = tempfloor.contentOrder;
    }

    public static TileLogic Create(Vector3Int cellPos, Vector3 worldPosition, Floor tempfloor)
    {
        TileLogic tileLogic = new TileLogic(cellPos, worldPosition, tempfloor);
        return tileLogic;
    }
}
