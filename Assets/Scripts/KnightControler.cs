using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightControler : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float jump;
    [SerializeField] private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("HorizontalKnight");
        animator.SetFloat("Horizontal", moveHorizontal);

        if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        rb.velocity = new Vector2(speed * moveHorizontal, rb.velocity.y);


        /*float moveVertical = Input.GetAxis("VerticalDragon");

        rb.velocity = new Vector2(rb.velocity.x, speed * moveVertical);*/

        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        */
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

    }

    public bool getFlipOrientation()
    {
        if (transform.localScale.Equals(new Vector3(-1, 1, 1)))
            return false;
        return true;
    }
}
