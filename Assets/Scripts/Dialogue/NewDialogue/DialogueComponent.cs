using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueComponent : MonoBehaviour
{
    [HideInInspector]
    public bool Active;

    protected virtual void Start()
    {
        Active = false;
    }

    public abstract void StartComponent();
    public abstract void Reset();
}