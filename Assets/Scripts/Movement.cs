using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public bool Locked;
    public float _Speed;
    private Camera Cam;

    public float Speed
    {
        get { return _Speed * Time.deltaTime; }
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Cam = Camera.main;
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
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 10);
            Interacter i = hit.collider.GetComponent<Interacter>();
            if (i != null)
            {
                i.Interact(gameObject);
                return;
            }
        }
    }

    //Moves the character in a direction (currently only used when moving left and right)
    public void Move(Vector3 direction)
    {
        
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, direction, out hit, 1))
        {
            transform.Translate(direction * Speed);
            MovementSound();
        }
    }

    //Moves the character towards a location. Character moves over the x-axis first, then moves over the z-axis
    public void MoveTowards(Vector3 spot)
    {
        
        if (transform.position.x != spot.x)
        {
            Vector3 pos = new Vector3(spot.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, pos, Speed);
        }
        else //if (transform.position.z != spot.z)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, spot.z);
            transform.position = Vector3.MoveTowards(transform.position, pos, Speed);
        }
    }

    void MovementSound()
    {
        GetComponent<AudioSource>().Play();
    }
}