using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerExit : MonoBehaviour {

	WaveBarHandler playerElements;
	public GameObject CanvasFade;
	public int[] sceneIndexes;
	//public GameObject scrittaWin;
	public GameObject targetManager;
	public string sceneWin;
	public string sceneSleep;

	void Start()
	{
		playerElements = FindObjectOfType<WaveBarHandler>();
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		//scrittaWin.SetActive (true);
		int finalCount = playerElements.count;
		if (finalCount > targetManager.GetComponent<TargetManager> ().minRange && finalCount < targetManager.GetComponent<TargetManager> ().maxRange) {
			StartCoroutine (FadeToScene (sceneWin));
		} else {
			StartCoroutine (FadeToScene (sceneSleep));
		}

		/*
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
		}*/

	}

	public IEnumerator FadeToScene (string scene) {
		if (CanvasFade != null)
		{
			GameObject player = GameObject.FindGameObjectWithTag ("Neurone");
			player.GetComponent<Rigidbody2D> ().isKinematic = true;
			player.GetComponent<ForceFromAccelerometer> ().enabled = false;
			//player.GetComponent<AudioSource>().clip = AudioContainer.Self.win;
			player.GetComponent<AudioSource>().Play();

			yield return new WaitForSeconds(0.2f);
			CanvasFade.GetComponent<CanvasFader>().FadeIn();
			yield return new WaitForSeconds(0.8f);
			SceneManager.LoadScene(scene);
		}


	}

}
