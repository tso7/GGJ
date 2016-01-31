﻿using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

    // Public vars
    public GameObject arrow;
    public float speed = 5.0f;

    private bool yellowLeft = false;
    private bool yellowRight = false;

    public Transform startMarkerLeft;
    public Transform startMarkerRight;
    public GameObject[] endMarkers;
    public Transform[] missPoints;

    // Audio Clips
    public AudioClip[] arrowRelease;
    public AudioClip arrowImpact;
    public AudioClip arrowImpactCiv;
    public AudioClip[] arrowMiss;

    // Private vars
    private bool isFiredLeft = false;
    private bool isFiredRight = false;

    private Animator anim;

    private GameObject curArrowLeft;
    private GameObject curArrowRight;

    private GameObject curTarget;
    private int missPointIndex = 0;

    void Update()
    {
        CheckForShotLeft();
        CheckForShotRight();
    }

    void CheckForShotLeft()
    {
        if (SliderMovementLeft.curState != SliderMovementLeft.State.Moving && !isFiredLeft)
        {
            isFiredLeft = true;
            curArrowLeft = (GameObject)Instantiate(arrow, startMarkerLeft.position, Quaternion.identity);
            //anim = curArrowLeft.GetComponent<Animator>();

            switch (SliderMovementLeft.curState)
            {
                case SliderMovementLeft.State.Sweet:
                    endMarkers = GameObject.FindGameObjectsWithTag("boat");
                    foreach (GameObject endMarker in endMarkers)
                    {
                       curTarget = endMarker;
                    }
                    break;
                case SliderMovementLeft.State.Pffft:
                    missPointIndex = Random.Range(0, missPoints.Length);
                    curTarget = missPoints[missPointIndex].gameObject;
                    break;
                case SliderMovementLeft.State.Meh:
                    yellowLeft = RandomFloatGenerator.Instance.fiftyfifty();
                    //Debug.Log(yellowLeft);
                    if(yellowLeft)
                    {
                        endMarkers = GameObject.FindGameObjectsWithTag("boat");
                        foreach (GameObject endMarker in endMarkers)
                        {
                            curTarget = endMarker;
                        }
                    }
                    else
                    {
                        missPointIndex = Random.Range(0, missPoints.Length);
                        curTarget = missPoints[missPointIndex].gameObject;
                    }
                    
                    break;
            }
            
            // Show flavor text if wrong target
            if (curTarget.gameObject.name.Contains("Civilian"))
                SliderMovementLeft.Instance.flavorText[3].enabled = true;

            StartCoroutine(ArrowTriggerLeft(startMarkerLeft.position, curTarget, 2.0f));
            SoundManager.instance.LeftArrowRandom(arrowRelease);
            //anim.SetBool("fired", true);
        }
    }
    IEnumerator ArrowTriggerLeft(Vector3 startPos, GameObject target, float time) {
        
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0)
        {
            Vector3 endPos = target.transform.position;
            //endPos.y += 1.0f;
            i += Time.deltaTime * rate;
            curArrowLeft.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        Destroy(curArrowLeft);
        if (SliderMovementLeft.curState == SliderMovementLeft.State.Sweet || (SliderMovementLeft.curState == SliderMovementLeft.State.Meh && yellowLeft))
        {
            target.GetComponent<ChangeSpriteOnInput>().ChangeSprite();
            if (target.gameObject.name.Contains("Civilian"))
            {
                SoundManager.instance.PlaySingle(arrowImpactCiv);
                UpdateScore.ScoreUpdate(1, -3);
                
            }
            else
            {
                SoundManager.instance.PlaySingle(arrowImpact);
                UpdateScore.ScoreUpdate(1, 1);
            }
        }
        else
        {
            SoundManager.instance.LeftArrowRandom(arrowMiss);
        }
        while (SliderMovementLeft.isFiring)
            yield return null;
        
        // Reset final flavor text if activated
        SliderMovementLeft.Instance.flavorText[3].enabled = false;

        isFiredLeft = false;

    }

    void CheckForShotRight()
    {
        if (SliderMovementRight.curState != SliderMovementRight.State.Moving && !isFiredRight)
        {
            isFiredRight = true;            
            curArrowRight = (GameObject)Instantiate(arrow, startMarkerRight.position, Quaternion.identity);
            //anim = curArrowRight.GetComponent<Animator>();

            switch (SliderMovementRight.curState)
            {
                case SliderMovementRight.State.Sweet:
                    endMarkers = GameObject.FindGameObjectsWithTag("boat");
                    foreach (GameObject endMarker in endMarkers)
                    {
                        curTarget = endMarker;
                    }
                    break;
                case SliderMovementRight.State.Pffft:
                    missPointIndex = Random.Range(0, missPoints.Length);
                    curTarget = missPoints[missPointIndex].gameObject;
                    break;
                case SliderMovementRight.State.Meh:
                    yellowRight = RandomFloatGenerator.Instance.fiftyfifty();
                    if(yellowRight)
                    {
                        endMarkers = GameObject.FindGameObjectsWithTag("boat");
                        foreach (GameObject endMarker in endMarkers)
                        {
                            curTarget = endMarker;
                        }
                    }
                    else
                    {
                        missPointIndex = Random.Range(0, missPoints.Length);
                        curTarget = missPoints[missPointIndex].gameObject;
                    }
                    break;
            }

            // Show flavor text if wrong target
            if (curTarget.gameObject.name.Contains("Civilian"))
                SliderMovementRight.Instance.flavorText[3].enabled = true;

            StartCoroutine(ArrowTriggerRight(startMarkerRight.position, curTarget, 2.0f));
            SoundManager.instance.RightArrowRandom(arrowRelease);
            //anim.SetBool("fired", true);
        }
    }
    IEnumerator ArrowTriggerRight(Vector3 startPos, GameObject target, float time)
    {

        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0)
        {
            Vector3 endPos = target.transform.position;
            //endPos.y += 1.0f;
            i += Time.deltaTime * rate;
            curArrowRight.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        Destroy(curArrowRight);
        if (SliderMovementRight.curState == SliderMovementRight.State.Sweet || (SliderMovementRight.curState == SliderMovementRight.State.Meh && yellowRight))
        {
            target.GetComponent<ChangeSpriteOnInput>().ChangeSprite();
            SoundManager.instance.PlaySingle(arrowImpact);
            if (target.gameObject.name.Contains("Civilian"))
            {
                SoundManager.instance.PlaySingle(arrowImpactCiv);
                UpdateScore.ScoreUpdate(2, -3);
            }
            else
            {
                SoundManager.instance.PlaySingle(arrowImpact);
                UpdateScore.ScoreUpdate(2, 1);
            }
        }
        else
        {
            SoundManager.instance.RightArrowRandom(arrowMiss);
        }

        while (SliderMovementRight.isFiring)
            yield return null;

        // Reset final flavor text if activated
        SliderMovementRight.Instance.flavorText[3].enabled = false;

        isFiredRight = false;
    }
}
