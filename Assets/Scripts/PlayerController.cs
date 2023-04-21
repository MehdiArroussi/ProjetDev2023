using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rbody = null;
    Vector2 movement = Vector2.zero;

    SpriteRenderer spr = null;

    public float speed = 2.0f;
    bool grounded = false;

    Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new Vector2(movement.x*speed,rbody.velocity.y);
        animator.SetBool("Running",movement.x != 0);
        if(movement.x != 0){
            spr.flipX = movement.x < 0;
        }
        OnMove();
    }

    void OnJump(){
        if(grounded){
            animator.SetBool("InTheAir",true);
            rbody.AddForce(new Vector2(0,10),ForceMode2D.Impulse);
            grounded = false;
        }
        
    }

    void OnMove(){
        movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }

    void OnCollisionEnter2D(Collision2D collision){
        foreach(ContactPoint2D contact in collision.contacts){
            if(contact.normal.y > 0.8f){
                grounded = true;
                animator.SetBool("InTheAir",false);
            }
        }
    }
}
