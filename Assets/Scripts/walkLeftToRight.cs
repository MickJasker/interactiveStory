using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkLeftToRight : MonoBehaviour
{

	public bool aggressive;
	public float startPoint;
    public float endPoint;
	public float speed;
	public Sprite characterLeft;
	public Sprite characterRight;

	private SpriteRenderer renderer;
	private bool endless = true;
	private float firstPosition;
	private float secondPosition;
	private bool ableToWalk;

	// Use this for initialization
	void Start ()
	{
		renderer = GetComponent<SpriteRenderer>();
		renderer.sprite = characterLeft;
		ableToWalk = true;
	}
	
	// Update is called once per frame
	void Update () {
		Walk();
		determineDirection();
	}

	void Walk () {
		//PingPong keeps switching between the given startPoint and endPoint. You can set the speed as well.
		//You add startPoint otherwise the pingpong always starts at 0.
		//You subtract the startPoint from the endPoint otherwise the endPoint will be startPoint + endPoint and not 0 + endPoint
		if (ableToWalk == true)
		{
			transform.position = new Vector3(
				Mathf.PingPong(Time.time * speed, endPoint - startPoint
				) + startPoint,
				transform.position.y, transform.position.z
			);
		}
		else
		{
			
		}
		
	}

	void determineDirection()
	{
		//get the current position
		secondPosition = transform.position.x;
		//checks if the current position is either larger or smaller than the previous position.
		checkForDirection();
		//update the previous position with the new one.
		firstPosition = secondPosition;
	}

	void checkForDirection()
	{
		if (secondPosition > firstPosition)
		{
			renderer.sprite = characterRight;
		}
		else
		{
			renderer.sprite = characterLeft;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		//checks wether you want the enemy to address the player in any way
		if (aggressive == true)
		{
			//makes sure only the protagonist is the target no other npc's
			if (col.tag == "Protagonist")
			{
				//makes sure the player can no longer move
				col.GetComponent<Movement>().Locked = true;
				//stops the enemy from walking
				ableToWalk = false;
				//makes sure the enemy looks at the player's direction
				if (col.transform.position.x < transform.position.x)
				{
					renderer.sprite = characterLeft;
				}
				else
				{
					renderer.sprite = characterRight;
				}
			}
		}
		else
		{
			//don't be aggressive towards the player
		}
	}
}
