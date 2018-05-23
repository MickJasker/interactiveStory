using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdgeMover : Interacter
{
    public Vector3 Direction;

    //Starts _move()
    public override void Interact(GameObject player)
    {
        StartCoroutine(_move(player.GetComponent<Movement>()));
    }

    public void Stop()
    {
        Active = false;
    }


    //Moves the player in a direction for as long as the player holds the mouse button
    IEnumerator _move(Movement player)
    {
        if (!player.Locked)
        {
            AudioSource walk = GetComponent<AudioSource>();
            while (Input.GetMouseButton(0) && Active)
            {
                if (!walk.isPlaying)
                {
                    walk.pitch = Random.Range(0.8f, 1.2f);
                    walk.Play();
                }

                player.Move(Direction);
                yield return null;
            }

            walk.Stop();
            Active = false;
        }
    }
}