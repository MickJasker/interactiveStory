using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    bool Opened;

    Transform Door1;
    Transform Door2;
    BoxCollider Hitbox;

    private void Start()
    {
        Opened = false;
        Door1 = transform.GetChild(0);
        Door2 = transform.GetChild(1);
        Hitbox = GetComponent<BoxCollider>();
    }

    public void Open()
    {
        if (!Opened)
        {
            StartCoroutine(_open());
        }
    }

    public void Close()
    {
        if (Opened)
        {
            StartCoroutine(_close());
        }
    }

    IEnumerator _open()
    {
        float end = Door1.transform.position.z + 2.3f;
        while (Door1.transform.position.z <= end)
        {
            Door1.transform.position += Vector3.forward * Time.deltaTime * 3;
            Door2.transform.position += Vector3.back * Time.deltaTime * 3;
            yield return null;
        }

        Hitbox.enabled = false;
    }

    IEnumerator _close()
    {
        float end = Door1.transform.position.x - 2.3f;
        while (Door1.transform.position.z >= end)
        {
            Door1.transform.position += Vector3.back * Time.deltaTime * 3;
            Door2.transform.position += Vector3.forward * Time.deltaTime * 3;
            yield return null;
        }

        Hitbox.enabled = true;
    }
}