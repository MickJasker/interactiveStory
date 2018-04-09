using UnityEngine;
using System.Collections;

public class ObjectSorter : MonoBehaviour
{
    private SpriteRenderer r;

    //number between 0 and 1, checks how far the distance check needs to be from the bottom of the sprite
    public float floorlevel;

    // Use this for initialization
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        if (floorlevel == 0) floorlevel = 0.75f;
        SetSortingLayer();
    }

    //Sets the objects sorting layer to be the same as the objects y-coördinate, allowing walking behind other objects
    void SetSortingLayer()
    {
        //adds an amount to the sorting layer relative to the gameobject height
        float objHeight = r.bounds.size.z * floorlevel;
        r.sortingOrder = (int)((transform.position.z - objHeight) * -10);
    }
}