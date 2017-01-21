using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {

    WaveBarHandler wabaha;
	
	void Start ()
    {
        wabaha = FindObjectOfType<WaveBarHandler>();
        SetCount();
	}
	
	
	void SetCount ()
    {
        int num = Random.Range(-15, 15);
        wabaha.count += num;
        
	}
}
