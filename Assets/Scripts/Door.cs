using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float OpenSpeed;
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
            Opened = true;
        }
    }

    public void Close()
    {
        if (Opened)
        {
            StartCoroutine(_close());
            Opened = false;
        }
    }

    IEnumerator _open()
    {
        OpenSound();
        float end = Door1.transform.position.z + 2.3f;
        while (Door1.transform.position.z <= end)
        {
            Door1.transform.position += Vector3.forward * Time.deltaTime * OpenSpeed;
            Door2.transform.position += Vector3.back * Time.deltaTime * OpenSpeed;
            yield return null;
        }

        Hitbox.enabled = false;
    }

    IEnumerator _close()
    {
        OpenSound();
        float end = Door1.transform.position.x - 2.3f;
        while (Door1.transform.position.z >= end)
        {
            Door1.transform.position += Vector3.back * Time.deltaTime * OpenSpeed;
            Door2.transform.position += Vector3.forward * Time.deltaTime * OpenSpeed;
            yield return null;
        }

        Hitbox.enabled = true;
    }

    void OpenSound(){
        GetComponent<AudioSource>().Play();
    }
}