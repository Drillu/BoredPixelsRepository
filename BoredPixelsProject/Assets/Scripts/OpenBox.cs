using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBox : MonoBehaviour
{

    public float transTime = 1f;

    public Animator animator;

    public void SleepInBox()
    {
        StartCoroutine(SleepInBoxCoroutine());
    }

    public IEnumerator SleepInBoxCoroutine()
    {
        animator.SetTrigger("Trans");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
