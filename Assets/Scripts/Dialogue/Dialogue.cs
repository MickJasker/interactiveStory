using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : Interacter
{
    public override void Interact(GameObject player)
    {
        StartCoroutine(_interaction());
    }

    IEnumerator _interaction()
    {
        DialogueComponent[] components = GetComponentsInChildren<DialogueComponent>();

        foreach (DialogueComponent c in components)
        {
            c.StartComponent();

            while(c.Active)
            {
                yield return null;
            }
        }

        foreach (DialogueComponent c in components)
        {
            c.Reset();
        }
    }
}