using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float jump;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("HorizontalDragon");
        animator.SetFloat("Horizontal", moveHorizontal);

        if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = true;
        }

        rb.velocity = new Vector2(speed * moveHorizontal, rb.velocity.y);


        /*float moveVertical = Input.GetAxis("VerticalDragon");

        rb.velocity = new Vector2(rb.velocity.x, speed * moveVertical);*/

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
}
