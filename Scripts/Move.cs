using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool left;

    void Start()
    {
        if(transform.position.x >= 10)
        {
            left = false;
        }
        else if(transform.position.x <= -10)
        {
            left = true;
        }
        StartCoroutine("Wait");
    }
    void Update()
    {
        switch(left)
        {
            case true:
                transform.Translate(Vector2.right * Time.deltaTime);
                break;
            case false:
                transform.Translate(-Vector2.right * Time.deltaTime);
                break;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        StartCoroutine("Wait");
        yield return new WaitForSeconds(17);
        Destroy(gameObject);
    }
}
