    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Animator anim;
        private float dirX = 0f;
        private SpriteRenderer spr;
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpForce = 14f;

        private enum MovementState { idle, running, jumping, falling }
        // Start is called before the first frame update
        private void Start()
        {
            // Debug.Log("Hello World");
            rb = GetComponent<Rigidbody2D>();
            spr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            UpdateAnimationState();
        }

        private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            spr.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            spr.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    }
