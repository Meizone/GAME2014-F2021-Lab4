using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.0f,100.0f)]
    public float HorizontalForce;
    [Range(0.1f,1.0f)]
    public float speedDecay;
    public Bounds bounds;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        checkBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(x * HorizontalForce, 0.0f));

        rb.velocity *= (1.0f - speedDecay);
    }

    private void checkBounds()
    {
        // Left Boundary
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }

        // Right Boundary
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
