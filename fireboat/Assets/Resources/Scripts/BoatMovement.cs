using UnityEngine;
using System.Collections;

public class BoatMovement : MonoBehaviour {

    // Boat
    public float moveSpeed;
    
    // Bob the boat up and down
    public float boatBobSpeed;
    public float boatBobDamper = 5;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPositionY = Mathf.Sin(Time.time * boatBobSpeed);
        transform.position = startPosition + Vector3.up * (newPositionY / boatBobDamper);
        transform.position += Vector3.right * moveSpeed * Time.time;
     }
}
