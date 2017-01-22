using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

    public float zoomIn = 1f;
    public float zoomOut = 8f;
    Camera main;
     

    void Start()
    {
        main = this.GetComponent<Camera>();
    }

    public IEnumerator IncreaseZoom()
    {
        while (main.orthographicSize > zoomIn)
        {
            main.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }

    public IEnumerator DecreaseZoom()
    {
        while (main.orthographicSize < zoomOut)
        {
            main.orthographicSize += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            StartCoroutine(IncreaseZoom());

        if (Input.GetKeyDown(KeyCode.O))
            StartCoroutine(DecreaseZoom());
    }


}
