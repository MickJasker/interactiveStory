using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : Interacter {

    public GameObject Door;

    public override void Interact(GameObject player)
    {
        StartCoroutine(_open());
    }

    // Opens the door
    IEnumerator _open()
    {
        GameObject[] Doors = Door.GetComponentsInChildren<GameObject>();

        while (!Active)
        {
            Doors[0].transform.Translate(new Vector2(-0.1f, 0));
            Doors[1].transform.Translate(new Vector2(0.1f, 0));
            yield return null;
        }
    }
}