using UnityEngine;
using System;
using System.Collections;
using System.Timers;

public class control_player : MonoBehaviour {
	[HideInInspector]
	public bool facingLeft = true;
	[HideInInspector]
	public bool jump = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;

	private Transform Grounded;
	private bool grounded = false;

	private Animator anim;

	public bool gameStarted = false;
	public float playerHealth = 100f;
	
	// Use this for initialization
	void Awake()
	{
		Grounded = transform.Find ("Grounded");
		anim = GetComponent<Animator> ();

	}

	void Start()
	{

	}

	void Update () {
		grounded = Physics2D.Linecast (transform.position, Grounded.position, 1 << LayerMask.NameToLayer ("Ground"));

		if(Input.GetKeyDown(KeyCode.W) && grounded)
			jump = true;



	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(gameStarted)
		{
			if (Input.GetKey (KeyCode.D) && rigidbody2D.velocity.x < maxSpeed) 
			{
				rigidbody2D.AddForce (Vector2.right * moveForce);
				if(facingLeft)
					Flip();
			}

			if (Input.GetKey (KeyCode.A) && Mathf.Abs (rigidbody2D.velocity.x) < maxSpeed) 
			{
				rigidbody2D.AddForce (new Vector2(-1, 0) * moveForce);
				if(!facingLeft)
					Flip();
			}

			if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
				rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

			if(jump)
			{
				rigidbody2D.AddForce (Vector2.up*jumpForce);

				jump = false;
			}

			// punch
			if (Input.GetKeyDown(KeyCode.J))
			{
				anim.Play ("punch");
			}
		}

	}

	void Flip()
	{
		facingLeft = !facingLeft;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
