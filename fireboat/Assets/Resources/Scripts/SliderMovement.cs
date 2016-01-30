﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderMovement : MonoBehaviour {

    public enum State
    {
        Sweet,
        Meh,
        Pffft
    };
    // Variables
    public float sliderSpeed = 2f;
    public static State curState;

    // GUI Text
    public Text[] flavorText;

    // Slider
    private Slider slider;
    private int sliderDir = 1;

    // Boolean for movement
    private bool isPaused = false;
    private bool isFiring = false;
    private bool boundaryHit = false;
        
    // Use this for initialization
    void Start()
    {
        slider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
        slider.value = 0;
        for (int i = 0; i < flavorText.Length; i++)
            flavorText[i].enabled = false;
    }

    void Update()
    {
        if (!isPaused)
            MoveSlider();

        if (!isFiring)
            PlayerInput();

       // Debug.Log("Paused: " + isPaused + " and Firing: " + isFiring);
    }

    void MoveSlider()
    {
        if (!boundaryHit && slider.value == slider.maxValue)
            boundaryHit = true;
        if (boundaryHit && slider.value == slider.minValue)
            boundaryHit = false;
        sliderDir = boundaryHit ? -1 : 1;
        slider.value += sliderSpeed * sliderDir;
    }

    void PlayerInput()
    {
        if ( Input.GetKeyDown (KeyCode.S))
        {
            isFiring = true;
            StartCoroutine(FireArrow());            
        }
    }

    IEnumerator FireArrow()
    {
        isPaused = true;
        float curVal = slider.value;
        int textType;
        if (curVal > 40 && curVal < 60)
            textType = 0;
        else if (curVal > 25 && curVal < 75)
            textType = 1;
        else
            textType = 2;

        curState = (State)textType;

        flavorText[textType].enabled = true;
        yield return new WaitForSeconds(3);
        flavorText[textType].enabled = false;
        isPaused = false;
        isFiring = false;
        slider.value = Random.Range(0, 100);
    }
}
