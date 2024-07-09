using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayJump();
        }
    }

    private void PlayerWalk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f)); 
        ScaleFlip(horizontalInput);
        if (horizontalInput != 0)
        {
            PlayWalk();
        }
    }

    private void ScaleFlip(float horizontalInput)
    {
        if (horizontalInput < 0) 
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            Debug.Log("flip!");
        }  
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            Debug.Log("noFlip");
        }
    }

    void Update()
    {
        PlayerWalk();
        PlayerJump();
    }

    #region AnimationHandler
    private void PlayWalk()
    {
        animator.SetTrigger("goWalk");
    }
    
    private void PlayJump()
    {
        animator.SetTrigger("goJump");
    }
    #endregion
}
