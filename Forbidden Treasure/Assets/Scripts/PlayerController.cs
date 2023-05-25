using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player's movement varibles
    public float speed;
    public float jumpForce;

    // the player's rigidbody
    public Rigidbody2D rb;
    Animator anim;
    Vector2 move;
    // varible to see if the place is on the ground or not
    public bool isOnGround;

    // bool to see what direction the player is facing
    public bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!anim.GetBool("isDead"))
        {
            // the input for the left/right movement
            float horizontalInput = Input.GetAxis("Horizontal");
            // the left/right movement
            rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);



            // flips the player to the direction they are facing
            if (horizontalInput > 0 && !facingRight)
            {
                Flip();
            }

            if (horizontalInput < 0 && facingRight)
            {
                Flip();
            }
        }
        


    }

    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // the input for the jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !anim.GetBool("isDead"))
        {
            // the jump
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }


    }

    // the logic for the character flipping direction
    void Flip()
    {
        // Multiply the player's x local scalce by -1
        transform.Rotate(0f, 180f, 0f);

        // Switch the way the player is labelled as facing
        facingRight = !facingRight;
    }

    // this determines if the player is the air or on the ground
    private void OnCollisionEnter2D(Collision2D col)
    {
        isOnGround = true;
        if (col.gameObject.tag == "Moving Platform")
        {
            transform.parent = col.transform;
        }
    }

    private void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.tag == "Moving Platform")
        {
            transform.parent = null;
        }
    }

}
