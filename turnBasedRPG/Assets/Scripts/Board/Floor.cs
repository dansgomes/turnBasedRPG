using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{
    [HideInInspector]
    public TilemapRenderer tilemapRenderer;
    public int order { get { return tilemapRenderer.sortingOrder; } }
    public int contentOrder;

    private void Awake()
    {
        tilemapRenderer = this.transform.GetComponent<TilemapRenderer>();
    }
}
