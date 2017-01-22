using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour
{
    public Image barTime;
    public bool timeEnabled = true;
    public float seconds = 60;
    public float pieceToFill;
    Life life;


    private void Start()
    {
        StartCoroutine(DecreaseBar());
        pieceToFill = barTime.fillAmount / seconds;
        life = FindObjectOfType<Life>();
    }

	public void DecreaseCo ()
    {
		StartCoroutine(DecreaseBar());
	}

    public IEnumerator DecreaseBar()
    {
        
        
            while (barTime.fillAmount > 0)
            {
            if (timeEnabled == true)
                barTime.fillAmount -= pieceToFill;
                yield return new WaitForSeconds(1);
            }

            StartCoroutine(life.Die());
        
        yield break;
    }
}