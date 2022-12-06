using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flightPlanBBF : MonoBehaviour
{
	[SerializeField] float movement;
	[SerializeField] int speed;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] int countdown;

	// Start is called before the first frame update
	void Start()
	{
		speed = 15;
		countdown = 360;
		if (rigid == null)
            	rigid = GetComponent<Rigidbody2D>();
		if(transform.rotation.y >= 0)
			movement = 1;
		else if(transform.rotation.y < 0)
			movement = -1;
	}

	// Update is called once per frame
	void Update()
	{
		countdown = countdown - 1;
		if (countdown == 0)
			Destroy(gameObject);
	}

	//called potentially multiple times per frame
	//used for physics & movement
	void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
	}

}
