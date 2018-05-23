﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : Interacter {

    List<Vector3> DeltaSpeed;
    Vector3 DeltaPosition;
    public Camera OrthoCam;

    protected override void Start()
    {
        base.Start();
        DeltaSpeed = new List<Vector3>();
    }

    public override void Interact(GameObject player)
    {
        enabled = true;
        StartCoroutine(Hold());
    }

    IEnumerator Hold()
    {
        while (enabled)
        {
            if (Input.GetMouseButtonUp(0))
            {
                enabled = false;
            }

            Vector3 pos = LongestAxis();

            
            if (Collision(pos))
            {
                //transform.position = pos;
            }
            Vector3 pos2 = OrthoCam.ScreenToWorldPoint(Input.mousePosition);
            pos2.z = 0;
            transform.position = pos2;
            yield return null;
        }
    }

    //determines axis furthes from the deltaposition, and returns the next position
    Vector3 LongestAxis()
    {
        Vector3 pos = OrthoCam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        Vector3 distpos = pos - DeltaPosition;

        UpdateDelta();

        if (Mathf.Abs(distpos.x) >= Mathf.Abs(distpos.y))
        {
            return new Vector3(pos.x, 0, 0);
        }
        else
        {
            return new Vector3(0, pos.y, 0);
        }
    }

    //Checks if there's a collider in front of the object
    bool Collision(Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction, Color.yellow, Time.deltaTime);
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            return false;
        }
        
        return true;
    }

    //keeps track of a list of positions of the last 10 frames
    void UpdateDelta()
    {
        DeltaSpeed.Add(transform.position);
        if (DeltaSpeed.Count > 10)
        {
            DeltaSpeed.RemoveAt(0);
        }

        DeltaPosition = transform.position;
    }

    //Returns a Vector3 with the average speed over the last 10 frames
    Vector3 GetSpeed()
    {
        Vector3 speed = Vector3.zero;

        foreach (Vector3 i in DeltaSpeed)
        {
            speed.x += i.x;
            speed.y += i.y;
        }

        speed.x = speed.x / DeltaSpeed.Count;
        speed.y = speed.y / DeltaSpeed.Count;

        return speed;
    }

    //Returns a Vector3 pointing in the direction the object is moving towards most (x or y)
    Vector3 GetDirection()
    {
        Vector3 speed = GetSpeed();

        if (Mathf.Abs(speed.x) >= Mathf.Abs(speed.y))
        {
            if (speed.x >= 0)
            {
                return Vector3.right;
            }
            else //(speed.x < 0)
            {
                return Vector3.left;
            }
        }
        else //if (Mathf.Abs(speed.x) < Mathf.Abs(speed.y))
        {
            if (speed.y >= 0)
            {
                return Vector3.up;
            }
            else //if (speed.y < 0)
            {
                return Vector3.down;
            }
        }
    }
}