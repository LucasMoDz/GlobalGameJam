using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour {

    public bool senzaBarriera = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pareti" && senzaBarriera == true)
        {
            senzaBarriera = false;
            StartCoroutine(Die());

        }
    }

    public IEnumerator Die()
    {
        this.GetComponent<ForceFromAccelerometer>().enabled = false;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Game Over");

    }

    
}
