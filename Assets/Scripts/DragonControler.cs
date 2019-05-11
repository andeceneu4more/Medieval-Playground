using UnityEngine;
using System;

public class DragonControler : MonoBehaviour
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
        isGrounded = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("HorizontalDragon") * speed;
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

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public bool getFlipOrientation()
    {
        if (transform.localScale.Equals(new Vector3(-1, 1, 1)))
            return false;
        return true;
    }

    /*void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }*/
}
