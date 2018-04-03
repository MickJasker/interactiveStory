using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Interacter {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact(GameObject player)
    {
        player.GetComponent<Movement>().MoveTowards(transform.position);
    }
}
