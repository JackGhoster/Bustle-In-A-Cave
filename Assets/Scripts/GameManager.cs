using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool playerDied = false;

    public Animator deathScreenAnimator;
    public Animator winScreenAnimator;

    public string targetScene;

    public AudioSource soundTrack;
    public AudioSource deathSFX;
    public AudioSource winSFX;

    public TextMeshProUGUI timerText;
    public int timeLeft = 20;

    public GameObject timerCanvas;

    //really sorry for the dirty code, wanted to finish this project faster, didn't want to think too much, I know it looks bad!

    private void Start()
    {
        SubtractFromText();
    }

    private void FixedUpdate()
    {
        OnPlayerDied();
    }

    private void SubtractFromText()
    {
        if(timeLeft > 0)
        {
            timerText.SetText(timeLeft.ToString());
            StartCoroutine(WaitForTimer());
        }
        else
        {
            OnPlayerWon();
        }   
    }

    IEnumerator WaitForTimer()
    {
        timeLeft--;
        yield return new WaitForSeconds(1);
        SubtractFromText();
    }

    protected void OnPlayerDied()
    {
        if (playerDied == true)
        {
            timeLeft = 200;
            deathScreenAnimator.SetBool("PlayerDead", true);
            Destroy(player);
            playerDied = false;
            soundTrack.Stop();
            deathSFX.Play();
            StartCoroutine(WaitForScreen());
        }
    }

    IEnumerator WaitForScreen()
    {
        float delay = 4f;
        Destroy(timerCanvas);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(targetScene);
    }

    protected void OnPlayerWon()
    {
        Destroy(player);    
        winScreenAnimator.SetBool("PlayerWon", true);
        winSFX.Play();
        StartCoroutine(WaitForScreen());       
    }
}
