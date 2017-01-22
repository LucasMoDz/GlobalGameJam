
using UnityEngine;
using System.Collections;

public class CanvasFader : MonoBehaviour
{

	public float fadeValue = 0.02f;
	public bool fadeOnStart;

	public void Start(){
		if (fadeOnStart) {
			this.GetComponent<CanvasGroup>().alpha = 1;
			FadeOut();
		}
	}

    public void FadeIn()
    {
        StartCoroutine(FadeInCO());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCO());
    }

    private IEnumerator FadeInCO()
    {
		while (this.gameObject.GetComponent<CanvasGroup>().alpha < 1)
        {
			this.gameObject.GetComponent<CanvasGroup>().alpha += fadeValue;
            yield return null;
        }

        yield break;
    }

    private IEnumerator FadeOutCO()
    {
		while (this.gameObject.GetComponent<CanvasGroup>().alpha > 0)
        {
			this.gameObject.GetComponent<CanvasGroup>().alpha -= fadeValue;
            yield return null;
        }

        yield break;
    }
}