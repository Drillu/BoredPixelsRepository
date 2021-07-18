using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator animator;
    public float transTime = 1f;

    public GameObject menu;

    public Animator carAnimator;

    public GameObject ground;
    public GameObject background1;
    public GameObject background2;

    private bool slowDown = false;

    private float groundStartSpeed;
    private float background1StartSpeed;
    private float background2StartSpeed;



    private void Start()
    {
        animator = GetComponent<Animator>();
        groundStartSpeed = ground.GetComponent<GroundMovement>().groundSpeed;
        background1StartSpeed = background1.GetComponent<ParallaxBackground>().backgroundSpeed;
        background2StartSpeed = background2.GetComponent<ParallaxBackground>().backgroundSpeed;
    }

    float timeElapsed;
    float lerpDuration = 3;

    void Update()
    {
        if(slowDown)
        {
            if (timeElapsed < lerpDuration)
            {
                ground.GetComponent<GroundMovement>().groundSpeed = Mathf.Lerp(groundStartSpeed, 0, timeElapsed / lerpDuration);
                background1.GetComponent<ParallaxBackground>().backgroundSpeed = Mathf.Lerp(background1StartSpeed, 0, timeElapsed / lerpDuration);
                background2.GetComponent<ParallaxBackground>().backgroundSpeed = Mathf.Lerp(background2StartSpeed, 0, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
        }
    }

    public void PlayButton()
    {
        menu.SetActive(false);
        slowDown = true;
        StartCoroutine(KickCat());
        //StartCoroutine(LoadLevel());
    }

    public IEnumerator KickCat()
    {
        yield return new WaitForSeconds(lerpDuration);
        carAnimator.SetBool("kickCat", true);
        yield return new WaitForSeconds(5);
        StartCoroutine(LoadLevel());
    }

    public IEnumerator LoadLevel()
    {
        animator.SetTrigger("Trans");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
