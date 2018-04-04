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
            StartCoroutine(_wait());
        }
    }

    //triggers at the end of the frame, making sure the next dialogue doesn't get skipped
    IEnumerator _wait()
    {
        yield return new WaitForEndOfFrame();
        OnChoose();
    }
}