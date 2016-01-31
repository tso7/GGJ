using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	void Update () {
        if (Time.timeSinceLevelLoad > 3f)
            Application.LoadLevel(4);
	}
}
