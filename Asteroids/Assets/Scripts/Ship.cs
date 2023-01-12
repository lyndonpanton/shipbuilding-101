using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

/// <summary>
/// functionlity for the ship game object
/// </summary>
public class Ship : MonoBehaviour
{
    Rigidbody2D rb2d;

    float radius;

    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 5;
    const float RotateDegreesPerSecond = 135;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        radius = GetComponent<CircleCollider2D>().radius;

        Debug.Log(ScreenUtils.ScreenLeft+ " " + ScreenUtils.ScreenRight);
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount;
        float isRotating = Input.GetAxis("Rotate");

        if (isRotating != 0)
        {
            rotationAmount = RotateDegreesPerSecond * Time.deltaTime;

            if (isRotating < 0)
            {
                rotationAmount *= -1;
            }

            transform.Rotate(Vector3.forward, rotationAmount);
        }
    }

    // FixedUpdate is for physics-based actions
    void FixedUpdate()
    {
        float isThrusting = Input.GetAxis("Thrust");

        if (isThrusting != 0)
        {
            rb2d.AddForce(
                ThrustForce * thrustDirection,
                ForceMode2D.Force
            );
        }
    }

    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        if (position.x >= ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft;
        } else if (position.x <= ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight;
        }

        if (position.y >= ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom;
        } else if (position.y <= ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop;
        }

        transform.position = position;
    }
}
