using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cutscene : MonoBehaviour
{
    public Text textBox;

    private const byte SECONDS_TO_FADE = 2;
    private const byte WAIT_TIME_TO_DISABLE_TEXT_BOX = 4;

    public Frame[] frames;

    [System.Serializable]
    public struct Frame
    {
        public string text;
        public bool fading;
        public Image[] image;
    }

    private void Awake()
    {
        StartCutscene();
    }

    public void StartCutscene()
    {
        StartCoroutine(StartCutsceneCO());
    }

    private IEnumerator StartCutsceneCO()
    {
        for (int i = 0; i < frames.Length; i++)
        {
            if (frames[i].fading)
            {
                for (int j = 0; j < frames[i].image.Length; j++)
                    StartCoroutine(FadeInCO(frames[i].image[j]));
            }
            else
            {
                for (int j = 0; j < frames[i].image.Length; j++)
                    frames[i].image[j].gameObject.SetActive(true);
            }
                
            textBox.text = frames[i].text;
            yield return new WaitForSeconds(WAIT_TIME_TO_DISABLE_TEXT_BOX);
        }

        textBox.gameObject.SetActive(false);
        Debug.Log("End of cutscene");
    }

    private IEnumerator FadeInCO(Image _image)
    {
        Color newColor = new Color(1, 1, 1, 0);

        while (newColor.a < 1)
        {
            newColor.a += Time.deltaTime / SECONDS_TO_FADE;
            _image.color = newColor;
            yield return null;
        }
    }
}