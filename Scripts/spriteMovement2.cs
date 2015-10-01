using UnityEngine;
using System.Collections;

public class spriteMovement2 : MonoBehaviour {

	public float horizMove, vertMove;

	private Vector2 groundContactPoint;

	private bool touchingGround = false;

	public bool movingRight = true;
	public bool movingUp = true;

	public float horizontalSpeedCap;


	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().mass = 10;
		GetComponent<Rigidbody2D>().drag = 5;
		GetComponent<Rigidbody2D>().angularDrag = 10;
		GetComponent<Rigidbody2D>().gravityScale = 3;

		horizMove = 500;
		vertMove = 20000;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		Vector2 gravityDir = groundContactPoint - new Vector2(this.transform.position.x, this.transform.position.y);
		gravityDir = gravityDir.normalized;


		if (Input.GetKey (KeyCode.LeftArrow))
		{
			ForceChar(-horizMove, 0);

			movingRight = false;
		}
		
		if (Input.GetKey (KeyCode.RightArrow))
		{
			ForceChar(horizMove, 0);

			movingRight = true;
		}
		

		
		if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
		{
			//ForceChar (0, vertMove);
			//touchingGround = false;

			Vector2 jumpVec = -gravityDir * vertMove * 2;

			GetComponent<Rigidbody2D>().AddForce ( jumpVec );

			print (vertMove);
		}

		if (Input.GetKey (KeyCode.C) && touchingGround)
		{
			//this.GetComponent<Rigidbody2D>().gravityScale = 0;

			print (gravityDir);

			//Physics2D.gravity = gravityDir * 20f;
			GetComponent<Rigidbody2D>().AddForce( -Physics2D.gravity);
			GetComponent<Rigidbody2D>().AddForce ( gravityDir * 100f );

			if (Input.GetKey (KeyCode.UpArrow))
			{
				ForceChar(0, horizMove * 1.3f);
				
				movingUp = true;
			}
			
			if (Input.GetKey (KeyCode.DownArrow))
			{
				ForceChar(0, -horizMove);
				
				movingUp = false;
			}

		}

//		if (Input.GetKeyUp (KeyCode.C) || !touchingGround)
//		{
//			//GetComponent<Rigidbody2D>().AddForce ( Physics2D.gravity );
//		}

		//horiz velocity cap
		if (this.GetComponent<Rigidbody2D>().velocity.x > horizontalSpeedCap)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeedCap, this.GetComponent<Rigidbody2D>().velocity.y);
		}
		if (this.GetComponent<Rigidbody2D>().velocity.x < -horizontalSpeedCap)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalSpeedCap, this.GetComponent<Rigidbody2D>().velocity.y);
		}


	}

	void VelChar(float x, float y)
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
	}
	
	void ForceChar(float x, float y)
	{
		GetComponent<Rigidbody2D>().AddForce ( new Vector2(x, y) );
	}

//	void OnCollisionEnter2D(Collision2D col)
//	{
//		if (col.gameObject.tag == "Ground")
//		{
//			this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
//		}
//	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			touchingGround = true;

			foreach(ContactPoint2D contactPoint in col.contacts)
			{
				//print (	contactPoint.point);

				groundContactPoint = contactPoint.point;
			}
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			touchingGround = false;
		}
	}


}
