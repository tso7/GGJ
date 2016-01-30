using UnityEngine;
using System.Collections;

public class BoatMovement : MonoBehaviour {

    // Boat
    public float moveSpeed;
    
    // Bob the boat up and down
    public float boatBobSpeed;
    public float boatBobDamper = 5;

    private Vector3 startPosition;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        float newPositionY = Mathf.Sin((Time.time - startTime) * boatBobSpeed);
        transform.position = startPosition + Vector3.up * (newPositionY / boatBobDamper);
        transform.position += Vector3.right * moveSpeed * (Time.time - startTime);
     }
}
