using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float Speed;
    public Camera Cam;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
                i.Interact(this);
                return;
            }

            print("Found a collider without interacter-script!");
        }
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
