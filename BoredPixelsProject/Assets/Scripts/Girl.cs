using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public GameObject player;
    public GameObject finishPanel;
    public GameObject pauseButton;
    public GameObject lifesPanel;
    public float lerpDuration;

    private Vector2 startPosition;
    private Vector2 targetPosition;

    private Animator animator;
    private float grabAndCleanTime = 6;

    void Start()
    {
        finishPanel.SetActive(false);
        startPosition = transform.position;
        animator = gameObject.GetComponent<Animator>();
    }

    public void Finish()
    {
        finishPanel.SetActive(true);
        pauseButton.SetActive(false);
        lifesPanel.SetActive(false);

        player.GetComponent<PlayerMovement>().gameFinished = true;

        targetPosition = new Vector2(player.transform.position.x, transform.position.y);

        StartCoroutine(Come());
    }

    public IEnumerator Come()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / lerpDuration); 
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPosition;
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        animator.SetBool("pickUp", true);
        player.SetActive(false);
        yield return new WaitForSeconds(grabAndCleanTime);
        StartCoroutine(GoAway());
    }

    public IEnumerator GoAway()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector2.Lerp(targetPosition, startPosition, timeElapsed / lerpDuration); 
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
}
