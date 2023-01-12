using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// functionlity for the ship game object
/// </summary>
public class Ship : MonoBehaviour
{
    Rigidbody2D rb2d;

    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is for physics-based actions
    void FixedUpdate()
    {
        float input = Input.GetAxis("Thrust");

        if (input != 0)
        {
            rb2d.AddForce(
                ThrustForce * thrustDirection,
                ForceMode2D.Force
            );
        }
    }
}
