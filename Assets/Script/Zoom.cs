using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Zoom : MonoBehaviour
{
    private CanvasFader canvasFader;
    public Camera targetCamera;
    private Camera mainCamera;

    public float transitionSeconds;
     
    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvasFader = FindObjectOfType<CanvasFader>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            StartCameraTransition();
    }

    public void StartCameraTransition()
    {
        GameObject.Find("Canvas").SetActive(false);

        StartCoroutine(CameraTransitionCO());
        StartCoroutine(IncreaseZoomCO());
    }
    
    private IEnumerator CameraTransitionCO()
    {
        Vector2 currentCameraPosition = mainCamera.transform.position;
        float step = 0;

        while ((targetCamera.transform.position - mainCamera.transform.position).magnitude > 0.1f)
        {
            Debug.Log("Loop");
            step += Time.deltaTime / transitionSeconds;
            mainCamera.transform.position = Vector2.Lerp(currentCameraPosition, targetCamera.transform.position, step);
            mainCamera.transform.position -= new Vector3(0, 0, 20);
            yield return null;
        }

        mainCamera.transform.position = targetCamera.transform.position;
    }

    private IEnumerator IncreaseZoomCO()
    {
        float startSizeCamera = mainCamera.orthographicSize;
        float step = 0;

        while ((Mathf.Abs(targetCamera.orthographicSize - mainCamera.orthographicSize) > 0.1f))
        {
            step += Time.deltaTime / transitionSeconds;
            mainCamera.orthographicSize = Mathf.Lerp(startSizeCamera, targetCamera.orthographicSize, step);
            yield return null;
        }

        mainCamera.orthographicSize = targetCamera.orthographicSize;

        yield return new WaitForSeconds(1);

        StartCoroutine(FadeToScene("LevelGame"));
    }

    public IEnumerator FadeToScene(string scene)
    {
        if (canvasFader != null)
        {
            yield return new WaitForSeconds(0.2f);
            canvasFader.GetComponent<CanvasFader>().FadeIn();
            yield return new WaitForSeconds(0.8f);
            SceneManager.LoadScene(scene);
        }
    }
}