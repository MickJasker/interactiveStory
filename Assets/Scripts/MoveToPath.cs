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

        Transform model = player.transform.GetChild(0);
        Vector3 endpos = model.position;
        endpos.z = -3.58f;

        while (model.transform.position != endpos)
        {
            player.MoveTowards(endpos);
            yield return null;
        }

        Active = false;
        player.Locked = false;
    }
}
