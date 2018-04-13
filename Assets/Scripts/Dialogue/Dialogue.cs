using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [HideInInspector]
    public bool Finished;

    [HideInInspector]
    public Conversation conversation;

    DialogueComponent[] Components;

    private void Start()
    {
        Finished = false;
        Components = GetComponentsInChildren<DialogueComponent>();
    }

    public void Interact(Conversation conversation)
    {
        StartCoroutine(_interaction());
    }

    IEnumerator _interaction()
    {
        foreach (DialogueComponent c in Components)
        {
            c.StartComponent();

            while(c.Active)
            {
                yield return null;
            }
        }

        Reset();
    }

    //Resets all components of the Dialogue
    public void Reset()
    {
        foreach (DialogueComponent c in Components)
        {
            c.Reset();
        }
    }
}