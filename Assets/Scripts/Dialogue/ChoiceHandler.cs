using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour
{
    public delegate void Chosen();
    public event Chosen OnChoose;
    [HideInInspector]
    public int chosen;

    //sets chosen and triggers the event
    public void Choose(int index)
    {
        chosen = index;
        if (OnChoose != null)
        {
            OnChoose();
        }
    }
}
