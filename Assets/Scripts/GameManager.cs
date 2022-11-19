using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool playerDied = false;
    public Animator deathScreenAnimator;
    public string targetScene;
    public AudioSource soundTrack;
    public AudioSource deathSFX;

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        OnPlayerDied();
    }

    protected void OnPlayerDied()
    {
        if (playerDied == true)
        {
            deathScreenAnimator.SetBool("PlayerDead", true);
            Destroy(player);
            playerDied = false;
            soundTrack.Stop();
            deathSFX.Play();
            StartCoroutine(WaitForDeathScreen());
        }
    }

    IEnumerator WaitForDeathScreen()
    {
        float delay = 4f;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(targetScene);
    }
}
