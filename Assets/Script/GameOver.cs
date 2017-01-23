using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {

	CanvasFader fader;

	public void Start() {
		fader = FindObjectOfType<CanvasFader> ();
	}

	public void TryAgain ()
    {
        //SceneManager.LoadScene(0);
		StartCoroutine(FadeToScene("LevelGame"));
    }
	
	
	public void Exit ()
    {
        //Application.Quit();
		StartCoroutine(FadeToScene("StartScreen"));
	}


	public IEnumerator FadeToScene (string sceneToLoad) {
		if (fader != null)
		{
			fader.GetComponent<CanvasFader>().FadeIn();
			yield return new WaitForSeconds(0.8f);
			SceneManager.LoadScene(sceneToLoad);
		}


	}
}
