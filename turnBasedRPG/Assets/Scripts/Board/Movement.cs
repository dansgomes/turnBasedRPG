using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    const float MoveSpeed = 0.5f;
    public bool teste;
    public List<Vector3Int> path;
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
        tileAtual = Board.GetTile(path[0]);
        transform.position = tileAtual.worldPos;

        for (int i=1; i < path.Count; i++)
        {
            TileLogic to = Board.GetTile(path[i]);
            if (to == null)
            {
                continue;
            }
            if(tileAtual.floor != to.floor)
            {
                //yield return StartCoroutine(Jump());
            }
            else
            {
                yield return Walk(to);
            }
        }
    }

    IEnumerator Walk(TileLogic to)
    {
        int id = LeanTween.move(transform.gameObject, to.worldPos, MoveSpeed).id;
        tileAtual = to;

        yield return new WaitForSeconds(MoveSpeed * 0.5f);
        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id)!= null)
        {
            yield return null;
        }
        to.content = this.gameObject;
    }

    IEnumerator Jump(TileLogic t, float totalTime)
    {
        Vector3 halfwayPos;
        Vector3 startpos = halfwayPos = jumper.localPosition;
        halfwayPos.y += 0.5f;
        float tempTime = 0;

        if(tileAtual.floor.tilemap.tileAnchor.y < t.floor.tilemap.tileAnchor.y)
        {
            SR.sortingOrder = t.contentOrder;
        }

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
