using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
};

public class BlockRaycaster : MonoBehaviour {

    public List<Direction> CastingDirections;

    public bool Collided(Direction direction)
    {
        foreach (Direction d in CastingDirections)
        {
            if (d == direction && Raycast(d))
            {
                return true;
            }
        }

        return false;
    }

    public bool Raycast(Direction d)
    {
        Vector3 dir = ConvertDirection(d);
        Ray r = new Ray(transform.position + dir * (transform.localScale.x / 2), dir);
        Debug.DrawRay(transform.position + dir * (transform.localScale.x / 2), dir, Color.yellow, 1 * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 0.1f))
        {
            print(hit.collider.ToString());
            return true;
        }

        return false;
    }

    public bool Contains(Direction direction)
    {
        return CastingDirections.Contains(direction);
    }

    Vector3 ConvertDirection(Direction d)
    {
        if(d == Direction.Up)
        {
            return Vector3.up;
        }
        else if (d == Direction.Down)
        {
            return Vector3.down;
        }
        else if (d == Direction.Left)
        {
            return Vector3.left;
        }
        else if (d == Direction.Right)
        {
            return Vector3.right;
        }

        throw new System.NotImplementedException("Raycasting direction unknown!");
    }
}