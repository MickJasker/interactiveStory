using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : Interacter {

    public Door Door;

    public override void Interact(GameObject player)
    {
        print("interacted");
        Door.Open();
    }
}