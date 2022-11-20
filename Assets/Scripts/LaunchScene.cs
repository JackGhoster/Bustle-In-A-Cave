using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LaunchScene : MonoBehaviour
{
    public string targetScene;
    private PlayerControls playerControls;
    public AudioSource SFX;
    public Animator mainBGAnimator;
    public Animator tmpAnimator;
    private string anim = "CaveScene";
            

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void InputContextReader(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() == true)
        {
            SFX.Play();
            //mainBGAnimator.SetBool("Pressed", true);
            tmpAnimator.SetBool("Pressed", true);
            StartCoroutine(SceneChangeDelayer());
        }
    }

    IEnumerator SceneChangeDelayer()
    {
        float delay = 1.1f;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }

    private void OnEnable()
    {
        playerControls.Menu.Start.performed += InputContextReader;
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Menu.Start.performed -= InputContextReader;
        playerControls.Disable();
    }



}
