using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float _Speed;
    public Camera Cam;
    public bool Locked;
    public bool AutoMove;

    public float Speed
    {
        get { return _Speed * Time.deltaTime; }
    }

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

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

            print("Found a collider without interacter-script!");
        }
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Speed);
    }

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
}
