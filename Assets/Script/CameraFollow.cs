using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    void Start()
    {
		target = GameObject.FindGameObjectWithTag ("Neurone").transform;
    }

   
    void Update()
    {

        transform.position = new Vector3(target.position.x, target.position.y, -10f);

    }
}
