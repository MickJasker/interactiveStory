using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : DialogueComponent {

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
	}
	
    public override void StartComponent()
    {
        Next.Interact(Current.Conversation);
    }
}