using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    public int valore = 10;
    WaveBarHandler playerElements;
    Transform targetTr;
    bool toccato = false;

    void Start()
    {
        playerElements = FindObjectOfType<WaveBarHandler>();
        targetTr = GameObject.FindGameObjectWithTag("Neurone").transform;
    }
    	
	void OnTriggerEnter2D (Collider2D coll)
    {


        if (coll.gameObject.tag == "Barriera")
        {
           // playerElements.UpdateBar(valore);
            coll.transform.parent.GetComponent<AudioSource>().Play();
            toccato = true;
        }
        else if (coll.gameObject.tag == "Neurone")
        {
            //playerElements.UpdateBar(valore);
            coll.GetComponent<AudioSource>().Play();
            toccato = true;
        }



    }


    void Update()
    {

        Vector3 distance = targetTr.position - this.transform.position;
        Vector3 direction = distance.normalized;

        if (toccato == true)
        {

            transform.position = transform.position + direction * 10 * Time.deltaTime;

            if (distance.magnitude < 0.5f)
            {
                Destroy(this.gameObject);

            }
        }
    }
}
