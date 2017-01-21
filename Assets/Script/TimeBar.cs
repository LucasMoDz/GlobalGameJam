using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour
{
    public Image barTime;
    public float seconds = 60;
    public float pieceToFill;


    private void Start()
    {
        StartCoroutine(DecreaseBar());
        pieceToFill = barTime.fillAmount / seconds;
    }

	public void DecreaseCo ()
    {
		StartCoroutine(DecreaseBar());
	}

    public IEnumerator DecreaseBar()
    {
        while (barTime.fillAmount > 0)
        {
            barTime.fillAmount -= pieceToFill;
            yield return new WaitForSeconds(1);
        }
        yield break;
    }
}