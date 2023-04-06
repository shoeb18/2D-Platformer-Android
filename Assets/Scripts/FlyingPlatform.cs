using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{

    public float speed = 2f; // The speed the platform moves left and right
    public float amplitude = 1f; // The distance the platform moves up and down
    private Vector2 startPosition; // The platform's starting position

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the platform left and right
        transform.position = new Vector2(startPosition.x + Mathf.PingPong(Time.time * speed, amplitude), transform.position.y);
    }
}