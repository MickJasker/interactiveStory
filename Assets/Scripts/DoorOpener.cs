using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : DialogueComponent {

    public Door Door;

    public override void StartComponent()
    {
        Door.Open();
        Active = false;
    }
}