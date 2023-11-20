using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMover : MonoBehaviour
{
    public bool Down;
    public int speed;
    void Start()
    {
        if (transform.position.y <= -15)
        {
            Down = false;
        }
        else if(transform.position.y >= -5)
        {
            Down = true;
        }
        StartCoroutine("Wait");
    }

    void Update()
    {
        switch(Down)
        {
            case true:
                transform.Translate(-Vector2.up * Time.deltaTime * speed);
                break;
            case false:
                transform.Translate(Vector2.up * Time.deltaTime * speed);
                break;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
