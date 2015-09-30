using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;

	private Vector3 playerPos;

	public float camRangeX, camRangeY, camOffset, camHorizSpeed, camVertSpeed;

	private float camX, camY;

	bool movingRight, movingUp;
	
	private spriteMovement2 pm_cache;

	// Use this for initialization
	void Start () {

//		camRangeX = 0.5f;
//		camRangeY = 0.5f;

		camX = player.transform.position.x;
		camY = player.transform.position.y;

		pm_cache = player.GetComponent<spriteMovement2>();

	
	}
	
	// Update is called once per frame
	void Update () {

		playerPos = player.transform.position;
	

//		if ( Mathf.Abs (camX - playerPos.x) > camRangeX)
//		{
//			if (camX - playerPos.x > camRangeX)
//			{
//				movingRight = false;
//				print ("is moving left");
//			}
//			if (camX - playerPos.x < camRangeY)
//			{
//				movingRight = true;
//				print ("is moving right");
//			}
//
//			//camX += (playerPos.x - camX) / 50;
//		}

		//right follow
		if (pm_cache.movingRight)
		{
			//camX += ((playerPos.x + camOffset) - camX) / camMovementIncrementDivision;
			camX = Mathf.Lerp(camX, playerPos.x + camOffset, Time.time/camHorizSpeed);
		}
		//left follow
		else
		{
			//camX += ((playerPos.x - camOffset) - camX) / camMovementIncrementDivision;
			camX = Mathf.Lerp(camX, playerPos.x - camOffset, Time.time/camHorizSpeed);
		}

//		//up follow
//		if ( pm_cache.movingUp )
//		{
//			camY = Mathf.Lerp(camY, playerPos.y + camOffset, Time.time/camVertSpeed);
//		}
//		//down follow
//		else
//		{
//			camY = Mathf.Lerp(camY, playerPos.y - camOffset, Time.time/camVertSpeed);
//		}

		camY = playerPos.y;


		this.transform.position = new Vector3(camX, camY, this.transform.position.z);


		                                   
	
	}
}
