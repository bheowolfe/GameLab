using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour
{
	[SerializeField] float xmovement;
	[SerializeField] float ymovement;
	[SerializeField] double left;
	[SerializeField] double right;
	[SerializeField] double top;
	[SerializeField] double bottom;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] int xspeed;
	[SerializeField] int yspeed;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] int points;
	[SerializeField] GameObject controller;
	[SerializeField] AudioSource audio;


    // Start is called before the first frame update
	void Start()
	{
		if (rigid == null)
      		rigid = GetComponent<Rigidbody2D>();
		int min = 2;
		int max = 7;
		xspeed = Random.Range(min, max);
		yspeed = Random.Range(min, max);
		//wierd equation to get equally random -1 or 1 to detirmin movement direction
		ymovement = (Random.Range(1, 2)*2)-3;
		xmovement = (Random.Range(1, 2)*2)-3;
		if (xmovement == -1)
			Flip();
		points = 10;
		if (controller == null)
        	{
            	controller = GameObject.FindGameObjectWithTag("GameController");
        	}
		if (audio == null)
        	{
            	audio = GetComponent<AudioSource>();
        	}
		InvokeRepeating("pointDrop",3f,3f);
	}


    // Update is called once per frame
    void Update()
    {
    }

	//called potentially multiple times per frame
    //used for physics & movement
	void FixedUpdate()
	{ 
		rigid.velocity = new Vector2(ymovement * yspeed, rigid.velocity.y);
		rigid.velocity = new Vector2(xmovement * xspeed, rigid.velocity.x);
		float h = transform.position.x;
		float v = transform.position.y;
		if(v <= bottom)
			ymovement = 1;
		else if(v >= top)
			ymovement = -1;
		if(h <= left){
			xmovement = 1;
			if(!isFacingRight)
				Flip();
		}
		else if(h >= right){
			xmovement = -1;
			if(isFacingRight)
				Flip();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}

	void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight;
	}

	void pointDrop()
	{
		points = points - 3;
		Vector3 objectScale = transform.localScale;
		transform.localScale = new Vector3(objectScale.x*2,  objectScale.y*2, objectScale.z);
		if(points <= 0){
			controller.GetComponent<statusTracker>().Restart();
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D (Collider2D collider){
		if (collider.gameObject.tag == "Projectile"){
			controller.GetComponent<statusTracker>().AddPoints(points);
			audio.volume = PersistentData.Instance.GetVolume();
			AudioSource.PlayClipAtPoint(audio.clip, transform.position);
			Destroy(gameObject);
		}
	}
}
