using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkLeftToRight : MonoBehaviour {

	public float startPoint;
    public float endPoint;
	public float speed;
	public Sprite characterLeft;
	public Sprite characterRight;

	private SpriteRenderer renderer;
	private bool endless = true;
	private float firstPosition;
	private float secondPosition;

	// Use this for initialization
	void Start ()
	{
		renderer = GetComponent<SpriteRenderer>();
		renderer.sprite = characterLeft;
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
		transform.position = new Vector3(
			Mathf.PingPong(Time.time * speed, endPoint - startPoint
			) + startPoint,
			transform.position.y, transform.position.z
			);
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
}
