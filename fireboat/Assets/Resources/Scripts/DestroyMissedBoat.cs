using UnityEngine;
using System.Collections;

public class DestroyMissedBoat : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	    if (transform.position.x > 15)
        {
            Destroy(this.gameObject);
        }
	}
}
