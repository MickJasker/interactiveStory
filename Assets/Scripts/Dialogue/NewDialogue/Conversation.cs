﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : Interacter
{
    public Dialogue Dialogue;

    public override void Interact(GameObject player)
    {
        Active = true;
        Dialogue.Interact(this);
    }
}