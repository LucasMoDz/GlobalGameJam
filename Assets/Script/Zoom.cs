using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour
{
    public Camera targetCamera;
    private Camera mainCamera;

    public float transitionSeconds;
     
    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void StartCameraTransition()
    {
        StartCoroutine(CameraTransitionCO());
        StartCoroutine(IncreaseZoomCO());
    }

    private IEnumerator CameraTransitionCO()
    {
        Vector2 currentCameraPosition = mainCamera.transform.position;
        float step = 0;

        while ((targetCamera.transform.position - mainCamera.transform.position).magnitude > 0.1f)
        {
            step += Time.deltaTime / transitionSeconds;
            mainCamera.transform.position = Vector2.Lerp(currentCameraPosition, targetCamera.transform.position, step);
            yield return null;
        }

        mainCamera.transform.position = targetCamera.transform.position;
    }

    private IEnumerator IncreaseZoomCO()
    {
        float startSizeCamera = mainCamera.orthographicSize;
        float step = 0;

        while ((Mathf.Abs(mainCamera.orthographicSize - targetCamera.orthographicSize) > 0.1f))
        {
            step += Time.deltaTime / transitionSeconds;
            mainCamera.orthographicSize = Mathf.Lerp(startSizeCamera, targetCamera.orthographicSize, step);
            yield return null;
        }

        mainCamera.orthographicSize = targetCamera.orthographicSize;
    }
}