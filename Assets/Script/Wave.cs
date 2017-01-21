using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    public int valore = 10;
    WaveBarHandler playerElements;

    void Start()
    {
        playerElements = FindObjectOfType<WaveBarHandler>();
    }
    	
	void OnTriggerEnter2D (Collider2D coll)
    {


        if (coll.gameObject.tag == "Barriera")
        {
            playerElements.UpdateBar(valore);
            coll.transform.parent.GetComponent<AudioSource>().Play();
        }
        else if (coll.gameObject.tag == "Neurone")
        {
            playerElements.UpdateBar(valore);
            coll.GetComponent<AudioSource>().Play();
        }



    }
	
	
	void Update ()
    {
	
	}
}
