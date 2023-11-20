using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public int depth, ran, ranlo;
    public GameObject[] lowfish, medfish, deepfish;
    public Transform[] underScreen, aboveScreen;
    public bool under = false;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        ran = Random.Range(0, 3);
        ranlo = Random.Range(0, 3);
        switch (under)
        {
            case false:
                switch (depth)
                {
                    case 0:
                        Instantiate(lowfish[ran], underScreen[ranlo].position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(medfish[ran], underScreen[ranlo].position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(deepfish[ran], underScreen[ranlo].position, Quaternion.identity);
                        break;
                }
                break;
            case true:
                switch (depth)
                {
                    case 0:
                        Instantiate(lowfish[ran], aboveScreen[ranlo].position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(medfish[ran], aboveScreen[ranlo].position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(deepfish[ran], aboveScreen[ranlo].position, Quaternion.identity);
                        break;
                }
                break;
        }           
        
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("Spawn");
    }
}
