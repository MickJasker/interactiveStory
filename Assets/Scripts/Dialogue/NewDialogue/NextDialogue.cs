using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : DialogueComponent
{
    public Dialogue Next;

    Dialogue Current;

    // Use this for initialization
    protected override void Start()
    {
        Dialogue d = GetComponentInParent<Dialogue>();
        if (d)
        {
            Current = d;
        }

        Reset();
	}
	
    public override void StartComponent()
    {
        StartCoroutine(_waitForInput());
    }

    IEnumerator _waitForInput()
    {
        Active = true;
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();

        Active = false;
        Next.Interact(Current.conversation);
        Current.Reset();
    }

    public override void Reset()
    {
        Current.conversation = null;
    }
}