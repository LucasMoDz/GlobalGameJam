﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceFromAccelerometer : MonoBehaviour
{
    [Range(2,8)]
    public float maxVelocity = 5;
    
    [Range(20,100)]
    public float reactivity = 60;

    private Rigidbody2D rb;

    public UnityEngine.UI.Text text;

    private float gx, gy;

    Quaternion currentRotation;
    
    private void Awake()
    {
        Input.gyro.enabled = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentRotation = Input.gyro.attitude;

        text.text = Input.acceleration.x.ToString();

        gx = Input.acceleration.x * reactivity;
        gy = Input.acceleration.y * reactivity;
    }

    private void FixedUpdate()
    {
        Physics2D.gravity = new Vector2(gx, gy);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity));
    }
}