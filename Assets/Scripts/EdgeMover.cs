using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdgeMover : Interacter
{
    public Vector3 Direction;
    AudioSource walk;

    protected override void Start()
    {
        base.Start();
        walk = GetComponent<AudioSource>();
    }

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
        Active = true;

        if (!player.Locked)
        {
            while (Input.GetMouseButton(0) && Active)
            {
                UpdateWalkSound();
                player.Move(Direction);
                yield return null;
            }

            walk.Stop();
            Active = false;
        }
    }

    void UpdateWalkSound()
    {
        if (!walk.isPlaying)
        {
            walk.pitch = Random.Range(0.8f, 1.2f);
            walk.Play();
        }
    }
}