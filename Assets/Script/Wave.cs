using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour
{
    public int heartz;
    private WaveBarHandler playerElements;
    private Transform player;
    private bool touched = false;

    private const float TIME_MOVEMENT_FROM_WAVE_TO_PLAYER = 1.5f;

    private void Start()
    {
        playerElements = FindObjectOfType<WaveBarHandler>();
        player = GameObject.FindGameObjectWithTag("Neurone").transform;
    }
    	
	private void OnTriggerEnter2D (Collider2D _other)
    {
        if (_other.CompareTag("Barriera"))
            _other.transform.parent.GetComponent<AudioSource>().Play();

        else if (_other.gameObject.tag == "Neurone")
            _other.GetComponent<AudioSource>().Play();

        playerElements.UpdateBar(heartz);

        StartCoroutine(IncorporationCO());
        StartCoroutine(FollowPlayerCO());
    }
    
    private IEnumerator IncorporationCO()
    {
        Vector2 myScale = this.transform.localScale;
        float seconds = 2;

        while (seconds > 0)
        {
            seconds -= Time.deltaTime;
            myScale += new Vector2(Time.deltaTime / 20, -Time.deltaTime / 2);
            this.transform.localScale = myScale;
            yield return null;
        }
    }

    private IEnumerator FollowPlayerCO()
    {
        Vector2 startWavePosition = this.transform.position;
        float step = 0;

        while ((this.transform.position - player.transform.position).magnitude > 0.5f)
        {
            step += Time.deltaTime / TIME_MOVEMENT_FROM_WAVE_TO_PLAYER;
            this.transform.position = Vector2.Lerp(startWavePosition, player.transform.position, step);
            yield return null;
        }

        this.gameObject.SetActive(false);
    }
}