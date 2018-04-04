using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractList : Interacter {

    public List<Interacter> Modules;

    public override void Interact(GameObject player)
    {
        StartCoroutine(_cycle(player));

    }

    IEnumerator _cycle(GameObject player)
    {
        Active = true;

        int index = 0;
        Modules[0].Interact(player);

        while (Active)
        {
            yield return null;
            if (Modules[index].Active == false)
            {
                index++;
                if (index >= Modules.Count)
                {
                    Active = false;
                }
                else
                {
                    Modules[index].Interact(player);
                }
            }
        }
    }
}
