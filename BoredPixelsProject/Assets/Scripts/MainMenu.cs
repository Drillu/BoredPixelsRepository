using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator animator;
    public float transTime = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayButton()
    {
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
