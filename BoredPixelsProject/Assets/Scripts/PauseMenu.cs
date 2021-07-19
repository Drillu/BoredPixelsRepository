using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Animator animator;
    public float transTime = 1f;
    private bool isPaused = false;
    public GameObject pauseMenu;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel());
    }

    public IEnumerator LoadLevel()
    {
        animator.SetTrigger("Trans");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}
