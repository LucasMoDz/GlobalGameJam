using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    public bool senzaBarriera = false;
    TimeBar timeElements;
    public Canvas mainC;

    void Start()
    {
        timeElements = FindObjectOfType<TimeBar>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pareti" && senzaBarriera == true)
        {
            senzaBarriera = false;
            timeElements.timeEnabled = false;
            StartCoroutine(Die());

        }
    }

    public IEnumerator Die()
    {
        mainC.gameObject.SetActive(false);
        this.GetComponent<ForceFromAccelerometer>().enabled = false;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        this.GetComponent<AudioSource>().clip = AudioContainer.Self.morte;
        this.GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Game Over");

    }

    
}
