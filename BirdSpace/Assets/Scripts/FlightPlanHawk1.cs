using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPlanHawk1 : MonoBehaviour
{

	[SerializeField] float movement;
	[SerializeField] int speed;
	[SerializeField] float angle;
	[SerializeField] float height;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] GameObject controller;
	[SerializeField] AudioSource audio;
	[SerializeField] bool turn = true;
	[SerializeField] int penelty;

    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
      		rigid = GetComponent<Rigidbody2D>();
		if (controller == null)
            	controller = GameObject.FindGameObjectWithTag("GameController");
		if (audio == null)
            	audio = GetComponent<AudioSource>();
		penelty = 5;
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	//I just made this and I have no idea how it works
	//its not like I copied it from anywhere I just have
	//vuage memories from High School Calculus that I cobbled into something workable
	void FixedUpdate()
	{ 
		rigid.velocity = new Vector3(speed * movement, angle, 0);
		if((angle >= height || angle < -1 * height) && turn)
			Flip();
		else if(angle < height && angle >= -1 * height){
			angle = angle + 1;
			turn = true;
		}
	}

	void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight;
		movement = -1 * movement;
		angle = angle * -1;
		turn = false;
	}

	private void OnTriggerEnter2D (Collider2D collider){
		if (collider.gameObject.tag == "Projectile"){
			controller.GetComponent<statusTracker>().AddPoints(-1*penelty);
			//AudioSource.PlayClipAtPoint(audio.clip, transform.position);
			Destroy(collider.gameObject);
		}
	}
}
