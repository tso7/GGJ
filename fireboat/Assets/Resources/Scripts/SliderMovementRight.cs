using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderMovementRight: GenericSingleton<SliderMovementRight> {

    public enum State
    {
        Sweet,
        Meh,
        Pffft,
        Moving
    };
    // Variables
    public float sliderSpeed = 2f;
    public static State curState;

    // GUI Text
    public Image[] flavorText;
    public Image coolDown;

    // Slider
    private Slider slider;
    private int sliderDir = 1;

    // Boolean for movement
    private bool isPaused = false;
    public static bool isFiring = false;
    private bool boundaryHit = false;
        
    // Use this for initialization
    void Start()
    {
        slider = GameObject.FindGameObjectWithTag("sliderRight").GetComponent<Slider>();
        slider.value = 0;
        curState = State.Moving;
        coolDown.enabled = false;
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

        sliderSpeed = RandomFloatGenerator.Instance.RandomFloat();
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
        if ( Input.GetKeyDown (KeyCode.UpArrow))
        {
            isFiring = true;
            coolDown.enabled = true;
            coolDown.GetComponent<Cooldown>().coolingDown = true;
            StartCoroutine(FireArrow());            
        }
    }

    IEnumerator FireArrow()
    {
        isPaused = true;
        float curVal = slider.value;
        int textType;
        if (curVal > 45 && curVal < 55)
            textType = 0;
        else if (curVal > 35 && curVal < 65)
            textType = 1;
        else 
            textType = 2;

        curState = (State)textType;

        flavorText[textType].enabled = true;
        yield return new WaitForSeconds(3);
        flavorText[textType].enabled = false;
        isPaused = false;
        isFiring = false;
        coolDown.enabled = false;
        coolDown.GetComponent<Cooldown>().coolingDown = false;
        curState = State.Moving;
        slider.value = Random.Range(0, 100);
    }
}
