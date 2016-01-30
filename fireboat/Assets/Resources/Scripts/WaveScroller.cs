using UnityEngine;
using System.Collections;

public class WaveScroller : MonoBehaviour
{
    // Make the waves scroll across the screen
    public float scrollSpeed;
    public float tileSizeZ;

    // Bob the waves up and down
    public float bobSpeed;
    public float bobDamper = 3;
    

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPositionZ = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.right * newPositionZ;
          
        float newPositionY = Mathf.Sin(Time.time * bobSpeed);
        transform.position += Vector3.up * (newPositionY/bobDamper);
    }
}