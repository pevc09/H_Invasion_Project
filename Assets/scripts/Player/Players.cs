using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Players : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField, Range(0, 100)] private int _velocity;

    private float MoveHorizontal;
    private SpriteRenderer SpR;
    private bool isGrounded;
    private Animator anim;
    [SerializeField] private LayerMask whatIsGround;

    //Salto
    [SerializeField, Range(100, 1000)] private int _jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SpR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveHorizontal = Input.GetAxisRaw("Horizontal");

        if (MoveHorizontal >= 1)
        {
            SpR.flipX = false;
            anim.SetBool("Run", true);
        }
        else if (MoveHorizontal <= -1)
        {
            SpR.flipX = true;
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, _jump));
            Debug.Log("casa");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_velocity * MoveHorizontal, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
