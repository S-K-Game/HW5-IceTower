using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float jumpVelocity = 12f;

    private bool facingRight = true;
    private PlayerMovement player;
    private Rigidbody2D rb2D;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<PlayerMovement>();
        rb2D = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        boxCollider2D= transform.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            
            rb2D.velocity = Vector2.up * jumpVelocity;
            animator.SetBool("IsJumping", true);
            animator.SetFloat("Speed", moveSpeed);
        }
        if (!Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }
        

        HandleMovement();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2 = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down , .1f , platformsLayerMask);
        Debug.Log(raycastHit2.collider);
       
        return raycastHit2.collider != null;
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        if ((h > 0 && !facingRight) || (h < 0 && facingRight)) Flip();
        animator.SetFloat("Speed", Mathf.Abs(h));

        if (Mathf.Abs(h * rb2D.velocity.x) < moveSpeed)
            rb2D.AddForce(h * moveSpeed * Vector2.right);

        if (Mathf.Abs(h) <= 0.05) rb2D.velocity = new Vector2(0, rb2D.velocity.y);

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
