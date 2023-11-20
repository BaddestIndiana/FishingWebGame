using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject[] Bubbles;
    public Transform[] bLo;
    public Transform[] hLo;
    public int ran, ranlo;
    public bool movingDown = true;

    void Start()
    {
        StartCoroutine("Bubble");
    }

    IEnumerator Bubble()
    {
        ran = Random.Range(0, 2);
        ranlo = Random.Range(0, 3);
        
        switch(movingDown)
        {
            case true:
                Instantiate(Bubbles[ran], bLo[ranlo].position, Quaternion.identity);       
                break;
            case false:
                Instantiate(Bubbles[ran], hLo[ranlo].position, Quaternion.identity);
                break;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Bubble");
    }
}
