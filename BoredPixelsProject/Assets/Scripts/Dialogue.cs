using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public bool dialogueStartSide;
    public string[] dialogue;

    public float messageWaitTime;
    public float lerpDuration;

    public float messageDistance;

    public GameObject dialogueMessageRightPrefab;
    public GameObject dialogueMessageLeftPrefab;

    private GameObject dialogueMessageRight;
    private GameObject dialogueMessageLeft;

    private TMP_Text textRight;
    private TMP_Text textLeft;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartDialogue()
    {
        StartCoroutine(StartDialogueCoroutine());
    }

    public IEnumerator StartDialogueCoroutine()
    {
        int currentDialogue = 0;
        bool dialogueSide;
        dialogueSide = dialogueStartSide;
        while(currentDialogue < dialogue.Length)
        {
            if(dialogueSide==true)
            {
                if(dialogueMessageRight)
                {
                    Destroy(dialogueMessageRight);
                }
                dialogueMessageRight = Instantiate(dialogueMessageRightPrefab, transform);
                dialogueMessageRight.transform.SetParent(transform);
                textRight = dialogueMessageRight.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
                textRight.text = dialogue[currentDialogue];

                if(dialogueMessageLeft)
                {
                    RectTransform rt = dialogueMessageLeft.GetComponent<RectTransform>();
                    rt.localPosition = new Vector3(rt.localPosition.x, messageDistance, rt.localPosition.z);
                    //dialogueMessageLeft.GetComponent<RectTransform>() = rt;
                }

                dialogueSide = false;
            }
            else
            {
                if(dialogueMessageLeft)
                {
                    Destroy(dialogueMessageLeft);
                }
                dialogueMessageLeft = Instantiate(dialogueMessageLeftPrefab, transform);
                dialogueMessageLeft.transform.SetParent(transform);
                textLeft = dialogueMessageLeft.transform.GetChild(0).GetComponent<TMP_Text>();
                textLeft.text = dialogue[currentDialogue];

                if(dialogueMessageRight)
                {
                    RectTransform rt = dialogueMessageRight.GetComponent<RectTransform>();
                    rt.localPosition = new Vector3(rt.localPosition.x, messageDistance, rt.localPosition.z);
                    //dialogueMessageRight.GetComponent<RectTransform>() = rt;
                }

                dialogueSide = true;
            }

            yield return new WaitForSeconds(messageWaitTime);
            currentDialogue++;

        }

        Destroy(dialogueMessageRight);
        Destroy(dialogueMessageLeft);
        
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            //valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            //timeElapsed += Time.deltaTime;

            yield return null;
        }

        //valueToLerp = endValue;
    }
}

    
