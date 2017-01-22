using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    public bool senzaBarriera = false;
    TimeBar timeElements;
    public Canvas mainC;
    public GameObject CanvasFade;


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
        mainC.GetComponent<Canvas>().enabled = false;
        this.GetComponent<ForceFromAccelerometer>().enabled = false;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        this.GetComponent<AudioSource>().clip = AudioContainer.Self.morte;
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.2f);
        CanvasFade.GetComponent<CanvasFader>().FadeIn();
        yield return new WaitForSeconds(0.8f);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Game Over");

    }

    
}
