using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public static Selector instance;
    public Vector3Int position;
    public TileLogic tile;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        instance = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
}
