using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {

	CanvasFader fader;

	public void Start() {
		fader = FindObjectOfType<CanvasFader> ();
	}

	public void Restart ()
    {
        //SceneManager.LoadScene(0);
		StartCoroutine(FadeToScene());
    }
	
	
	public void Exit ()
    {
        Application.Quit();
	
	}


	public IEnumerator FadeToScene () {

		fader.GetComponent<CanvasFader>().FadeOut();
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene(0);


	}
}
