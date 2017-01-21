using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public GameObject CanvasFade;
	public int sceneToLoad;

	public void Start () {
		CanvasFade.GetComponent<CanvasGroup> ().alpha = 1;
		CanvasFade.GetComponent<CanvasFader> ().FadeOut ();
	}

	public void LoadNewGame ()
	{
		StartCoroutine (FadeToScene ());

	}
		

	public IEnumerator FadeToScene () {
		if (CanvasFade != null)
		{
			CanvasFade.GetComponent<CanvasFader>().FadeIn();
			yield return new WaitForSeconds(0.8f);
			SceneManager.LoadScene(sceneToLoad);
		}


	}
} 