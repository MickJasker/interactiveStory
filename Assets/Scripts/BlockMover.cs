using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : Interacter {

    List<Vector3> DeltaSpeed;
    Vector2 DistPosition;
    Vector2 DeltaPosition;
    public Camera OrthoCam;

    [Space]
    public float MinMovement;
    public List<BlockRaycaster> RaycastScripts;

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
            if (!Collision(DistPosition))
            {
               transform.position = pos;
            }

            yield return null;
        }
    }

    //determines axis furthes from the deltaposition, and returns the next position.
    //if the object isn't moved enough, the object will not move
    Vector3 LongestAxis()
    {
        //Calculates the distance traveled between frames
        Vector2 pos = OrthoCam.ScreenToWorldPoint(Input.mousePosition);
        DistPosition = (pos - DeltaPosition);
        DeltaPosition = OrthoCam.ScreenToWorldPoint(Input.mousePosition);

        //Checks what the largest axis is, X or Y
        //if the largest axis is X
        if (Mathf.Abs(DistPosition.x) >= Mathf.Abs(DistPosition.y))
        {
            if (Mathf.Abs(DistPosition.x) >= MinMovement)
            {
                return new Vector2(pos.x, transform.position.y);
            }
        }
        //if the largest axis is Y
        else
        {
            if (Mathf.Abs(DistPosition.y) >= MinMovement)
            {
                return new Vector2(transform.position.x, pos.y);
            }
        }

        return transform.position;
    }

    //Checks if there's a collider in front of the object
    bool Collision(Vector3 direction)
    {
        if (DistPosition != Vector2.zero)
        {
            foreach (BlockRaycaster br in RaycastScripts)
            {
                Direction dEnum = ConvertVector(direction);
                if (br.Contains(dEnum) && br.Collided(dEnum))
                {
                    print("collided");
                    return true;
                }
            }
        }

        print("not collided");
        return false;
    }

    Direction ConvertVector(Vector3 v)
    {
        if (Mathf.Abs(v.x) > Mathf.Abs(v.y))
        {
            if (v.x > 0)
            {
                return Direction.Right;
            }
            else //if (v.x < 0)
            {
                return Direction.Left;
            }
        }
        else if (Mathf.Abs(v.x) < Mathf.Abs(v.y))
        {
            if (v.y > 0)
            {
                return Direction.Up;
            }
            else //if(v.y < 0)
            {
                return Direction.Down;
            }
        }
        else
        {
            throw new System.NotImplementedException("Raycasting direction unknown!");
        }
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