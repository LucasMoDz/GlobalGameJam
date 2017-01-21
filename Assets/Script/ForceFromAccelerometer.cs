using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceFromAccelerometer : MonoBehaviour
{
    [Range(2,8)]
    public float maxVelocity = 5;
    
    [Range(20,100)]
    public float reactivity = 60;

    private Rigidbody2D rb;

    private float gx, gy;
    
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #if UNITY_EDITOR

        gx = Input.GetAxis("Horizontal") * reactivity;
        gy = Input.GetAxis("Vertical") * reactivity;

        #else

        gx = Input.acceleration.x * reactivity;
        gy = Input.acceleration.y * reactivity;

        #endif
    }

    private void FixedUpdate()
    {
        Physics2D.gravity = new Vector2(gx, gy);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity));
    }
}