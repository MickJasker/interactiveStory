using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour {

    bool Active;
    float Clicks;
    int TimeTaken;

    public Text TimeText;
    public Text ClickText;

	// Use this for initialization
	void Start () {
        Active = true;
        StartCoroutine(Count());
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            Active = false;
        }
    }

    IEnumerator Count()
    {
        while (Active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Clicks++;
                ClickText.text = "Aantal Clicks: " + Clicks;
            }

            TimeTaken = (int)Time.time;
            TimeText.text = "Tijd: " + TimeTaken + " seconden";

            yield return null;
        }
    }
}