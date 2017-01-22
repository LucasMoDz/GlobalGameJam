using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {


	
	public void Restart ()
    {
        SceneManager.LoadScene(0);

    }
	
	
	public void Exit ()
    {
        Application.Quit();
	
	}
}
