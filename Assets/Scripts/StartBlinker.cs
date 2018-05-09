using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBlinker : MonoBehaviour {

    [Range(0, 1)]
    public float MaxValue;
    [Range(0, 1)]
    public float MinValue;
    [Range(0.01f, 0.1f)]
    public float Change;

    private void Start()
    {
        StartCoroutine(_Blink());
    }

    IEnumerator _Blink()
    {
        Color c = new Color(1, 1, 1, MinValue);

        Image background = GetComponent<Image>();
        RawImage arrows = transform.GetChild(0).GetComponent<RawImage>();

        background.color = c;
        arrows.color = c;

        while(c.a < MaxValue)
        {
            c = new Color(1, 1, 1, c.a + Change);
            background.color = c;
            arrows.color = c;
            yield return new WaitForFixedUpdate();
        }

        while (c.a > MinValue)
        {
            c = new Color(1, 1, 1, c.a - Change);
            background.color = c;
            arrows.color = c;
            yield return new WaitForFixedUpdate();
        }

        while (c.a < MaxValue)
        {
            c = new Color(1, 1, 1, c.a + Change);
            background.color = c;
            arrows.color = c;
            yield return new WaitForFixedUpdate();
        }

        while (c.a > 0)
        {
            c = new Color(1, 1, 1, c.a - Change);
            background.color = c;
            arrows.color = c;
            yield return new WaitForFixedUpdate();
        }
    }
}