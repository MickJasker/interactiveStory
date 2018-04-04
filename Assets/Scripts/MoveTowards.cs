using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : Interacter
{
    //Starts _move()
    public override void Interact(GameObject player)
    {
        StartCoroutine(_move(player.GetComponent<Movement>()));
    }

    //moves the character towards a spot for as long as the character is not near it.
    IEnumerator _move(Movement player)
    {
        player.Locked = true;
        Active = true;

        Transform model = player.transform.GetChild(0);

        Vector3 endpos = transform.position;
        endpos.y = player.transform.position.y;
        endpos.z -= 2;

        while (model.transform.position != endpos)
        {
            player.MoveTowards(endpos);
            yield return null;
        }

        Active = false;
        player.Locked = false;
    }
}