using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interacter : MonoBehaviour
{
    [HideInInspector]
    public bool Active;
    public abstract void Interact(GameObject player);
}