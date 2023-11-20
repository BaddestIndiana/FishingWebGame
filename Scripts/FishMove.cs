using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public int fishType, speed;
    public bool Down, difFish;
    public GameObject player;

    void Start()
    {
        if (transform.position.y <= -15)
        {
            Down = false;
        }
        else if (transform.position.y >= -5)
        {
            Down = true;
        }
        FishBehave();
        StartCoroutine("Wait");
    }

    public void FishBehave()
    {
        switch(fishType)
        {
            case 0:
                speed = 4;
                break;
            case 1:
                speed = 10;
                break;
            case 2:
                speed = 6;
                player = GameObject.FindWithTag("player");
                break;
        }
    }

    void Update()
    {
        switch (Down)
        {
            case true:
                if(difFish)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    StartCoroutine("stopFish");
                }
                else
                {
                    transform.Translate(-Vector2.up * Time.deltaTime * speed);
                }                
                break;
            case false:
                if(difFish)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    StartCoroutine("stopFish");
                }
                else
                {
                    transform.Translate(Vector2.up * Time.deltaTime * speed);
                }                
                break;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    IEnumerator stopFish()
    {
        yield return new WaitForSeconds(3);
        difFish = false;
    }
}
