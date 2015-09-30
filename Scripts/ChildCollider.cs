using UnityEngine;
using System.Collections;

public class ChildCollider : MonoBehaviour {

	public bool touchingGround = false;
	public Vector2 groundContactPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			touchingGround = true;
		}
	}

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
