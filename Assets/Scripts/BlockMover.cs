using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : Interacter {

    List<Vector3> DeltaSpeed;
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

            Vector3 pos = OrthoCam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos;

            yield return null;
        }

    }

    //keeps track of a list of positions of the last 10 frames
    void UpdateDeltaSpeed()
    {
        DeltaSpeed.Add(transform.position);
        if (DeltaSpeed.Count > 10)
        {
            DeltaSpeed.RemoveAt(0);
        }
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