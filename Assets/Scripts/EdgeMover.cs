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

    public override void Interact(Movement movement)
    {
        movement.Move(Direction);
    }
}
