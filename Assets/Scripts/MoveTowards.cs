using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : Interacter
{
    public override void Interact(GameObject player)
    {
        Movement m = player.GetComponent<Movement>();
        StartCoroutine(_move(m));
    }

    IEnumerator _move(Movement player)
    {
        player.Locked = true;
        Active = true;

        Vector3 endpos = transform.position;
        endpos.y = player.transform.position.y;
        endpos.z -= 2;

        while (player.transform.position != endpos)
        {
            player.MoveTowards(endpos);
            yield return null;
        }

        Active = false;
        player.Locked = false;
    }
}