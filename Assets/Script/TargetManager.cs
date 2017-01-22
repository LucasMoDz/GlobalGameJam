using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private WaveBarHandler wabaha;
    public GameObject red, orange, green, blue, purple;
	
	void Start ()
    {
        wabaha = FindObjectOfType<WaveBarHandler>();
        SetCount();
	}
	
	void SetCount ()
    {
        int num = Random.Range(-15, 16);
        int range = wabaha.count + num;

        if (range >= 0 && range <= 5)
            purple.SetActive(true);

        else if (range >= 6 && range <= 11)
            blue.SetActive(true);

        else if (range >= 12 && range <= 17)
            green.SetActive(true);

        else if (range >= 18 && range <= 23)
            orange.SetActive(true);

        else if (range >= 24 && range <= 30)
            red.SetActive(true);
    }
}