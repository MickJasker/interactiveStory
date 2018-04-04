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
        Active = true;
        player.AutoMove = true;

        Vector3 endpos = transform.position;
        endpos.y = player.transform.position.y;
        endpos.z -= 2;

        while (player.AutoMove && player.transform.position != endpos)
        {
            player.MoveTowards(endpos);
            yield return null;
        }

        player.AutoMove = false;
        Active = false;
    }
}