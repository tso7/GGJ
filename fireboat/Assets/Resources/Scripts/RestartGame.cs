using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateScore.leftScore = 0;
            UpdateScore.rightScore = 0;
            Application.LoadLevel(0);
        }
    }
}
