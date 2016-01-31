using UnityEngine;
using System.Collections;

public class ShowCredits : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel(0);
    }
}
