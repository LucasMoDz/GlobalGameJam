using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    public int valore = 10;
    	
	void OnTriggerEnter2D (Collider2D coll)
    {


        if (coll.gameObject.tag == "Barriera")
        {
            coll.transform.parent.GetComponent<WaveBarHandler>().UpdateBar(valore);
            coll.transform.parent.GetComponent<AudioSource>().Play();
        }
        else if (coll.gameObject.tag == "Neurone")
        {
            coll.GetComponent<WaveBarHandler>().UpdateBar(valore);
            coll.GetComponent<AudioSource>().Play();
        }



    }
	
	
	void Update ()
    {
	
	}
}
