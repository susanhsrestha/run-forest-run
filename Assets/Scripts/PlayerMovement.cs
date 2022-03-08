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
                rb.velocity = new Vector3(0, jumpForce, 0);
            }
            UpdateAnimationState();
        }

        private void UpdateAnimationState() 
        {
            if(dirX > 0f)
            {
                anim.SetBool("running", true);
                spr.flipX = false;
            } 
            else if (dirX < 0f)
            {
                anim.SetBool("running", true);
                spr.flipX = true;
            }
            else 
            {
                anim.SetBool("running", false);
            }
        }
    }
