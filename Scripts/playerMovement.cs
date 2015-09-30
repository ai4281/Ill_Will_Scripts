using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {


	private float origGravityScale;
	public float horizMove, vertMove;

	public GameObject centralRef;

	private bool cloneRelease;

	public bool movingRight = true;
	public bool movingUp = true;

	public GameObject[] colliderChildren;

	public GameObject spriteCharacter;

	
	// Use this for initialization
	void Start () {

		colliderChildren = new GameObject[8];

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player"))
		{
			if (go.name.Equals(this.gameObject.name + " Central Ref Point"))
			{
				centralRef = go;
				
				print (centralRef.gameObject.name);
			}
			
			//magic number 8 watch out
			//ex: smiley Ref Point 1 --- smiley being name
			

			
			for (int i = 1; i < 9; i++)
			{
				if  (go.name.Equals( this.gameObject.name + " Ref Point " + i.ToString() ) )
				{
					go.AddComponent<ChildCollider>();
					print (go.gameObject.name);

					colliderChildren[ i-1 ] = go;
				}
			}
		}

		centralRef.transform.position = spriteCharacter.transform.position;
	}
//	
	// Update is called once per frame
	void Update () {

		//centralRef.transform.position = spriteCharacter.transform.position;
	
	}
//
//	//anything physics related
//	void FixedUpdate() {
//
//
//		int numOfFloatingChildren = 0;
//
//		foreach(GameObject coChil in colliderChildren)
//		{
//			if (coChil.GetComponent<ChildCollider>().touchingGround)
//			{
//				touchingGround = true;
//			}
//			else
//			{
//				numOfFloatingChildren ++;
//			}
//		}
//
//		if (numOfFloatingChildren == colliderChildren.Length)
//		{
//			touchingGround = false;
//		}
//
//		print (numOfFloatingChildren);
//
//
//		//print("fixed");
//
//		if (Input.GetKey (KeyCode.LeftArrow))
//		{
//			ForceChar(-horizMove, 0);
//
//			movingRight = false;
//		}
//
//		if (Input.GetKey (KeyCode.RightArrow))
//		{
//			ForceChar(horizMove, 0);
//
//			movingRight = true;
//		}
//
//		if (Input.GetKey (KeyCode.UpArrow))
//		{
//			ForceChar(0, horizMove);
//
//			movingUp = true;
//		}
//
//		if (Input.GetKey (KeyCode.DownArrow))
//		{
//			ForceChar(0, -horizMove);
//
//			movingUp = false;
//		}
//
//		if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
//		{
//			ForceChar (0, vertMove);
//
//			movingUp = true;
//
//			//VelChar(0, vertMove);
//			//touchingGround = false;
//		}
//
//		if (Input.GetKey (KeyCode.C))
//		{
//			Vector2 upVector = new Vector2(0, 1);
//
//			RaycastHit2D upTouch = Physics2D.Raycast(centralRef.transform.position, Vector2.up);
//
//
//			float dist = Mathf.Abs(upTouch.point.y - centralRef.transform.position.y);
//
//			if (dist < 0.7f)
//			{
//				centralRef.GetComponent<Rigidbody2D>().gravityScale = -2;
//			}
//			else
//			{
//				centralRef.GetComponent<Rigidbody2D>().gravityScale = 2;
//			}
//		}
//
//		if (Input.GetKeyUp (KeyCode.C))
//		{
//			centralRef.GetComponent<Rigidbody2D>().gravityScale = 2;
//		}
//
//		if (Input.GetKeyDown(KeyCode.X))
//		{
//			if (cloneRelease && GameObject.FindGameObjectsWithTag("Player").Length < 50)
//			{
//				GameObject clone = Instantiate(this.transform.gameObject) as GameObject;
//				cloneRelease = false;
//			}
//		}
//		if (Input.GetKeyUp (KeyCode.X))
//		{
//			cloneRelease = true;
//		}
//		if (Input.GetKeyDown(KeyCode.Z))
//		{
//			int index = 0;
//
//			foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
//			{
//				if (index > 0)
//				{
//					Destroy (player);
//				}
//
//				index++;
//			}
//		}
//		
//	}
//
//	void VelChar(float x, float y)
//	{
//		centralRef.GetComponent<Rigidbody2D>().velocity = new Vector2(x, centralRef.GetComponent<Rigidbody2D>().velocity.y);
//	}
//
//	void ForceChar(float x, float y)
//	{
//		centralRef.GetComponent<Rigidbody2D>().AddForce ( new Vector2(x, y) );
//	}

}
