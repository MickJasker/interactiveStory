using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMover : Interacter
{
    public Vector3 Direction;

    //Starts _move()
    public override void Interact(GameObject player)
    {
        StartCoroutine(_move(player.GetComponent<Movement>()));
    }

    //Moves the player in a direction for as long as the player holds the mouse button
    IEnumerator _move(Movement player)
    {
        if (!player.Locked)
        {
            Active = true;

            while (Input.GetMouseButton(0))
            {
                player.Move(Direction);
                yield return null;
            }

            Active = false;
        }
    }
}