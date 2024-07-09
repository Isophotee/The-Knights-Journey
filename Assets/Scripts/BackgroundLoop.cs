using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 1f;
    public float resetPosition = -20f; // The position at which the background should reset
    public float startPosition = 20f;  // The position to which the background should move after resetting

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the background to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Check if the background has moved out of view and reset its position
        if (transform.position.x <= resetPosition)
        {
            Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
