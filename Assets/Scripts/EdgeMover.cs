using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMover : Interacter {

    public Vector3 Direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact(GameObject player)
    {
        player.GetComponent<Movement>().Move(Direction);
    }
}
