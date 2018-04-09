using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public bool Locked;
    public float _Speed;
    public Camera Cam;

    public SpriteRenderer r;
    public float floorlevel;

    public float Speed
    {
        get { return _Speed * Time.deltaTime; }
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Locked && Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    // checks for an interactable object on mouseclick, and interacts with it
    public void Click()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Interacter i = hit.collider.GetComponent<Interacter>();
            if (i != null)
            {
                i.Interact(gameObject);
                return;
            }

            print("Found a collider without interact-script!");
        }
    }

    //Moves the character in a direction (currently only used when moving left and right)
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Speed);
    }

    //Moves the character towards a location. Character moves over the x-axis first, then moves over the x-axis
    public void MoveTowards(Vector3 spot)
    {
        if (transform.position.x != spot.x)
        {
            Vector3 pos = new Vector3(spot.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, pos, Speed);
        }
        else //if (transform.position.z != spot.z)
        {
            Transform model = transform.GetChild(0);
            Vector3 pos = new Vector3(transform.position.x, model.transform.position.y, spot.z);
            model.position = Vector3.MoveTowards(model.position, pos, Speed);
        }
    }

    void SetSortingLayer()
    {
        //adds an amount to the sorting layer relative to the gameobject height
        float objHeight = r.bounds.size.z * floorlevel;
        r.sortingOrder = (int)((transform.position.z - objHeight) * -10);
    }
}
