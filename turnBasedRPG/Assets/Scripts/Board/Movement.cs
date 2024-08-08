using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool teste;
    public Vector3Int destino;
    SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (teste)
        {
            teste = false;
            StopAllCoroutines();
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        yield return null;
        TileLogic t = Board.instance.tiles[destino];
        transform.position = t.worldPos;
        SR.sortingOrder = t.contentOrder;
        t.content = this.gameObject;
    }
}
