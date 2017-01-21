using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceFromAccelerometer : MonoBehaviour
{
    public float maxVelocity = 5;

    private Rigidbody2D rb;

    private const float GRAVITY = 50;
    private float gx, gy;
    
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        gx = Input.acceleration.x * GRAVITY;
        gy = Input.acceleration.y * GRAVITY;
    }

    private void FixedUpdate()
    {
        Physics2D.gravity = new Vector2(gx, gy);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity));
    }
}