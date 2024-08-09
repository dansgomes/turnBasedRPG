using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool teste;
    public Vector3Int destino;
    SpriteRenderer SR;
    Transform jumper;
    TileLogic tileAtual;

    private void Awake()
    {
        jumper = transform.Find("Jumper");
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

        Vector3 startPos = transform.position;
        Vector3 endPos = t.worldPos;
        float totalTime=1;
        float tempTime=0;

        if(tileAtual == null)
            tileAtual = t;
        if (tileAtual.floor != t.floor)
            StartCoroutine(Jump(t, totalTime));

        while(transform.position != endPos)
        {
            tempTime += Time.deltaTime;
            float perc = tempTime / totalTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            yield return null;
        }


        SR.sortingOrder = t.contentOrder;
        t.content = this.gameObject;
    }

    IEnumerator Jump(TileLogic t, float totalTime)
    {
        Vector3 halfwayPos;
        Vector3 startpos = halfwayPos = jumper.localPosition;
        halfwayPos.y += 0.5f;
        float tempTime = 0;

        while(jumper.localPosition != halfwayPos)
        {
            tempTime += Time.deltaTime;
            float perc = tempTime / (totalTime / 2);
            jumper.localPosition = Vector3.Lerp(startpos, halfwayPos, perc);
            yield return null;
        }

        tempTime = 0;
        while(jumper.localPosition != startpos)
        {
            tempTime += Time.deltaTime;
            float perc = tempTime / (totalTime / 2);
            jumper.localPosition = Vector3.Lerp(halfwayPos, startpos, perc);
            yield return null;
        }
    }
}
