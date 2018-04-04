using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractList : Interacter {

    public List<Interacter> Modules;

    //Starts _cycle()
    public override void Interact(GameObject player)
    {
        StartCoroutine(_cycle(player));
    }

    //Goes through all modules in the list
    IEnumerator _cycle(GameObject player)
    {
        Active = true;

        int index = 0;
        Modules[0].Interact(player);

        //Execute module for as long as it is active
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
