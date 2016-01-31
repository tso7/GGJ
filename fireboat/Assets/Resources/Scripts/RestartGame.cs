using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateScore.leftScore = 0;
            UpdateScore.rightScore = 0;
            SliderMovementLeft.curState = SliderMovementLeft.State.Moving;
            SliderMovementRight.curState = SliderMovementRight.State.Moving;
            SliderMovementLeft.isFiring = false;
            SliderMovementRight.isFiring = false;
            Application.LoadLevel(0);
        }
    }
}
