using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class Cooldown : MonoBehaviour
{

    public Image cooldown;
    public bool coolingDown;
    public float waitTime = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            cooldown.fillAmount -= (1.0f/waitTime) * Time.deltaTime;
        }

        if (!coolingDown)
            cooldown.fillAmount = 1;
    }
}