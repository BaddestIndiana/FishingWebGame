using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuMGR : MonoBehaviour
{
    public bool underWater;
    public GameObject MenuPan, wonPan, playPan, lure, lurepre, BubbleSpawn, CloudSpawn, FishSpawner;
    public int score, fish1, fish2, fish3;

    public Animator playerAnim, CameraAnim;
    public Transform lurespawn;
    public TextMeshProUGUI scoreText, fish1Txt, fish2Txt, fish3Txt;

    public void Play()
    {
        underWater = true;
        MenuPan.SetActive(false);        
        playerAnim.SetBool("CastLine", true);        
        StartCoroutine("Wait");        
        CloudSpawn.SetActive(false);        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        CameraAnim.SetBool("CamDown", true);
        yield return new WaitForSeconds(1);
        playPan.SetActive(true);
        Cursor.visible = false;
        BubbleSpawn.SetActive(true);
        FishSpawner.SetActive(true);
        lure = Instantiate(lurepre, new Vector3(0, 0, 0), Quaternion.identity);       
    }
    public void Won()
    {
        Cursor.visible = true;
        BubbleSpawn.SetActive(false);
        FishSpawner.SetActive(false);
        CloudSpawn.SetActive(true);
        CameraAnim.SetBool("CamDown", false);
        wonPan.SetActive(true);
        playPan.SetActive(false);
        scoreText.text = "Score: " + score;
        fish1Txt.text = "x " + fish1;
        fish2Txt.text = "x " + fish2;
        fish3Txt.text = "x " + fish3;
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
