using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] float movement;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] int speed;
	[SerializeField] bool isFacingRight = true;
    	[SerializeField] bool jumpPressed = false;
	[SerializeField] bool divePressed = false;
	[SerializeField] bool firePressed = false;
    	[SerializeField] float jumpForce = 0.0f;
	[SerializeField] float diveForce = 0.0f;
    	[SerializeField] bool shiftPressed = false;
	[SerializeField] GameObject BBF;
	[SerializeField] Animator animator;
	
	const int IDLE = 0;
    	const int FLAP = 1;
    	const int DIVE = 2;

    // Start is called before the first frame update
    void Start()
    {
         if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
	   if (animator == null)
            animator = GetComponent<Animator>();
        speed = 15;

	  animator.SetInteger("motion", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
		movement = Input.GetAxis("Horizontal");
		if (Input.GetKeyDown("up"))
           		jumpPressed = true;
		if (Input.GetKey("down"))
			divePressed = true;
		if (Input.GetButtonDown("Fire1"))
			firePressed = true;
    }

	//called potentially multiple times per frame
	//used for physics & movement
	void FixedUpdate()
	{ 
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
		if(movement != 0)
			animator.SetInteger("motion", FLAP);
		else
			animator.SetInteger("motion", IDLE);
		if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
			Flip();
		if (jumpPressed)
			Jump();
		if (divePressed)
			Dive();
		if (firePressed)
			Fire();
	}

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
    }

	void Dive(){
		//animator.SetInteger("motion", DIVE);
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
      	rigid.AddForce(new Vector2(0, diveForce));
		divePressed = false;
	}

	void Fire()
	{
		Instantiate(BBF, transform.position, transform.rotation);
		firePressed = false;
	}
}
