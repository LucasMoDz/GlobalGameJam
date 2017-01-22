using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private WaveBarHandler wabaha;
    public GameObject red, orange, green, blue, purple;
	public int minRange;
	public int maxRange;

	void Start ()
    {
        wabaha = FindObjectOfType<WaveBarHandler>();
        SetCount();
	}
	
	void SetCount ()
	{
		int num = Random.Range (-15, 16);
		int range = wabaha.count + num;

		if (range >= 0 && range <= 5) {
			purple.SetActive (true);
			minRange = 0;
			maxRange = 5;
		} else if (range >= 6 && range <= 11) {
			blue.SetActive (true);
			minRange = 6;
			maxRange = 11;
		} else if (range >= 12 && range <= 17) {
			green.SetActive (true);
			minRange = 12;
			maxRange = 17;
		} else if (range >= 18 && range <= 23) {
			orange.SetActive (true);
			minRange = 18;
			maxRange = 23;
		} else if (range >= 24 && range <= 30) {
			red.SetActive (true);
			minRange = 24;
			maxRange = 30;
		}
    }
}