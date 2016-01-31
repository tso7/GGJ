using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

    // Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel(Application.loadedLevel + 1);
	}
}
