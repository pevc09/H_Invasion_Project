using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerss : MonoBehaviour
{

    [Header("Personaje")]
    public float runSpeed = 2;

    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    [Header("Bala")]

    public Transform FirePoint;
    public GameObject Bullet;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            //spriteRenderer.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            //spriteRenderer.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            //rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            rb2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        }
    }
}
