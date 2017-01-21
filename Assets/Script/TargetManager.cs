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
        int num = Random.Range(-15, 16);
        int range = wabaha.count += num;

        if(range >=0 && range <= 5)
            wabaha.UpdateTarget(1);

        else if (range >= 6 && range <= 11)
            wabaha.UpdateTarget(2);

        else if (range >= 12 && range <= 17)
            wabaha.UpdateTarget(3);

        else if (range >= 18 && range <= 23)
            wabaha.UpdateTarget(4);

        else if (range >= 24 && range <= 30)
            wabaha.UpdateTarget(5);





    }

}
