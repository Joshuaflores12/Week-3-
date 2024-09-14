using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb; // players rigid body
    private float gravity; // gravity scale
    public Transform target; // targets position
    private float distanceX;
    private float velocityX;

    public float duration;
    private float timer;

    private float distanceY;
    private float velocityY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets players rb component
        gravity = rb.gravityScale * 9.81f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer += Time.deltaTime;
            distanceX = target.position.x - transform.position.x;
            velocityX = distanceX / duration;

            distanceY = target.position.y - transform.position.y;
            velocityY = Mathf.Sqrt(2 * rb.gravityScale * gravity * distanceY);
            rb.velocity = new Vector2(velocityX, velocityY);

        }
    }
}

