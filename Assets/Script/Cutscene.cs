using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Zoom))]
[RequireComponent(typeof(AudioSource))]
public class Cutscene : MonoBehaviour
{
    public Text textBox;

    private const byte SECONDS_TO_FADE = 2;
    private float waitTimeToDisableTextBox = 4;

    public Frame[] frames;

    [System.Serializable]
    public struct Frame
    {
        public string text;
        public bool fading;
        public GameObject[] image;
        public AudioClip sound;
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
        yield return new WaitForSeconds(1);

        for (int i = 0; i < frames.Length; i++)
        {
            if (frames[i].fading)
            {
                for (int j = 0; j < frames[i].image.Length; j++)
                {
                    if (frames[i].image[j] != null)
                        StartCoroutine(FadeInCO(frames[i].image[j]));

                    if (frames[i].sound != null)
                    {
                        this.GetComponent<AudioSource>().clip = frames[i].sound;
                        this.GetComponent<AudioSource>().Play();
                    }
                }
            }
            else
            {
                for (int j = 0; j < frames[i].image.Length; j++)
                {
                    frames[i].image[j].GetComponent<SpriteRenderer>().color = Color.white;
                    frames[i].image[j].gameObject.SetActive(true);

                    if (frames[i].sound != null)
                    {
                        this.GetComponent<AudioSource>().clip = frames[i].sound;
                        this.GetComponent<AudioSource>().Play();
                    }
                }
            }
                
            textBox.text = frames[i].text;
            
            while(waitTimeToDisableTextBox > 0)
            {
                waitTimeToDisableTextBox -= Time.deltaTime;

                if (Input.touchCount == 1)
                    yield break;
                else
                    yield return null;
            }

            waitTimeToDisableTextBox = 4;
        }

        yield return new WaitForSeconds(2);

        this.GetComponent<Zoom>().StartCameraTransition();

        textBox.gameObject.SetActive(false);
        Debug.Log("End of cutscene");
    }

    private IEnumerator FadeInCO(GameObject _sprite)
    {
        Color newColor = new Color(1, 1, 1, 0);
        
        while (newColor.a < 1)
        {
            newColor.a += Time.deltaTime / SECONDS_TO_FADE;
            _sprite.GetComponent<Image>().color = newColor;

            if (Input.touchCount == 1)
            {
                newColor.a = 1;
                yield break;
            }
            else
                yield return null;
        }
    }
}