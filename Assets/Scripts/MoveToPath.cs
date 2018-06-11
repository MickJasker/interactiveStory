using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPath : Interacter {

    //Starts _move()
    public override void Interact(GameObject player)
    {
        StartCoroutine(_move(player.GetComponent<Movement>()));
    }

    //moves the character back to the main path
    IEnumerator _move(Movement player)
    {
        player.Locked = true;
        Active = true;

        Vector3 endpos = player.transform.position;
        endpos.z = 0.5f;

        while (player.transform.position != endpos)
        {
            player.MoveTowards(endpos);
            yield return null;
        }

        Active = false;
        player.Locked = false;
    }
}
