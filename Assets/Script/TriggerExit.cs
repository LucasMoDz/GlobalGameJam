using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerExit : MonoBehaviour {

	WaveBarHandler playerElements;
	public GameObject CanvasFade;
	public int[] sceneIndexes;
	public GameObject scrittaWin;

	void Start()
	{
		playerElements = FindObjectOfType<WaveBarHandler>();
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		scrittaWin.SetActive (true);
		int finalCount = playerElements.count;

		if (finalCount > 24 && finalCount <= 30) {
			StartCoroutine (FadeToScene (sceneIndexes[0]));
		} else if (finalCount > 18 && finalCount < 23) {
			StartCoroutine (FadeToScene (sceneIndexes[1]));
		} else if (finalCount > 12 && finalCount < 17) {
			StartCoroutine (FadeToScene (sceneIndexes[2]));
		} else if (finalCount > 6 && finalCount < 11) {
			StartCoroutine (FadeToScene (sceneIndexes[3]));
		} else if (finalCount >= 0 && finalCount < 5) {
			StartCoroutine (FadeToScene (sceneIndexes[4]));
		}

	}

	public IEnumerator FadeToScene (int scene) {
		if (CanvasFade != null)
		{
			CanvasFade.GetComponent<CanvasFader>().FadeIn();
			yield return new WaitForSeconds(0.8f);
			SceneManager.LoadScene(scene);
		}


	}

}
