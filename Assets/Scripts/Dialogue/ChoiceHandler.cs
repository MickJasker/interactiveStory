using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceHandler : MonoBehaviour {

    public delegate void Chosen();
    public event Chosen OnChoose;

    public int chosen;

    public void Choose(int index)
    {
        chosen = index;
        if (OnChoose != null)
        {
            StartCoroutine(_choose());
        }
    }

    IEnumerator _choose()
    {
        yield return new WaitForEndOfFrame();
        OnChoose();
    }
}
