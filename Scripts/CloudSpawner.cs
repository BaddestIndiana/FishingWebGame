using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public int ran, ranlo;
    public GameObject[] Clouds;
    public Transform[] lo;

    void Start()
    {
        StartCoroutine("Spawner");
    }

    IEnumerator Spawner()
    {
        ran = Random.Range(0, 4);
        ranlo = Random.Range(0, 4);
        Instantiate(Clouds[ran], lo[ranlo].position, Quaternion.identity);
        
        yield return new WaitForSeconds(4);
        StartCoroutine("Spawner");
    }
}
