using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject LowDepthWall, MidDepthWall, DeepDepthWall, fSpawner, bSpawner, DiveCounter, FishCounter, menu;
    public GameObject[] fishlow, fishmed, fishdeep;
    public float timer;
    public bool down = true;
    public int check, depth, score, fish1, fish2, fish3;
    public TextMeshProUGUI DiveCount, FishCount;
    public Animator anim;
    public MenuMGR mgr;


    void Start()
    {        
        fSpawner = GameObject.FindWithTag("fSpawn");
        bSpawner = GameObject.FindWithTag("bSpawn");
        DiveCounter = GameObject.FindWithTag("dCounter");
        FishCounter = GameObject.FindWithTag("fCounter");
        LowDepthWall = GameObject.FindWithTag("Lwall");
        MidDepthWall = GameObject.FindWithTag("Mwall");
        DeepDepthWall = GameObject.FindWithTag("Dwall");

        DiveCount = DiveCounter.GetComponent<TextMeshProUGUI>();
        FishCount = FishCounter.GetComponent<TextMeshProUGUI>();

        LowDepthWall.SetActive(true);
        MidDepthWall.SetActive(false);
        DeepDepthWall.SetActive(false);
    }

    void Update()
    {
        switch (down)
        {
            case true:
                timer += Time.deltaTime;
                break;
            case false:
                timer -= Time.deltaTime;
                break;
        }
        DiveCount.text = "Depth - " + Mathf.Round(timer) + "M";

        switch (timer)
        {
            case 5f:
                LowDepthWall.SetActive(true);
                MidDepthWall.SetActive(false);
                DeepDepthWall.SetActive(false);
                fSpawner.GetComponent<FishSpawner>().depth = 0;
                depth = 0;
                break;
            case 6f:
                LowDepthWall.SetActive(false);
                MidDepthWall.SetActive(true);
                DeepDepthWall.SetActive(false);
                fSpawner.GetComponent<FishSpawner>().depth = 1;
                depth = 1;
                break;
            case 10f:
                LowDepthWall.SetActive(false);
                MidDepthWall.SetActive(false);
                DeepDepthWall.SetActive(true);
                fSpawner.GetComponent<FishSpawner>().depth = 2;
                depth = 2;
                break;            
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        if (timer <= 0 && down == false)
        {
            menu = GameObject.FindWithTag("Menu");
            DiveCounter.SetActive(false);
            FishCounter.SetActive(false);
            mgr = menu.GetComponent<MenuMGR>();
            mgr.score = score;
            mgr.fish1 = fish1;
            mgr.fish2 = fish2;
            mgr.fish3 = fish3;
            mgr.Won();
            
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            if (down = true)
            {
                down = false;
                fSpawner.GetComponent<FishSpawner>().under = true;
                bSpawner.GetComponent<BubbleSpawner>().movingDown = false;
            }
            check = collision.gameObject.GetComponentInParent<FishMove>().fishType;
            score++;
            FishCount.text = "Fish - " + score;
            anim.SetBool("Hit", true);
            StartCoroutine("Wait");
            switch (depth)
            {
                case 0:
                    Instantiate(fishlow[check], this.transform);                    
                    break;
                case 1:
                    Instantiate(fishmed[check], this.transform);
                    
                    break;
                case 2:
                    Instantiate(fishdeep[check], this.transform);
                    
                    break;
            }
            switch(check)
            {
                case 0:
                    fish1++;
                    break;
                case 1:
                    fish2++;
                    break;
                case 2:
                    fish3++;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Hit", false);
    }

    /// <summary>
    /// A timer that starts when the lure is created and moved down until player is not seen. timer counts how long it has been out triggering different statements when certain times are hit changing backgrounds 
    /// switching fish then when a fish is hit going the other way. (backgorund is just one sprite looping animation bubbles)
    /// </summary>
}
