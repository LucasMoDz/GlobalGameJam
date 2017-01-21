using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PingPongAlpha : MonoBehaviour
{
    private float myAlpha = 1;

    private IEnumerator Start()
    {
        while(true)
        {
            myAlpha = Mathf.PingPong(Time.time, 1);
            this.GetComponent<Text>().color = new Color(0, 0, 0 , myAlpha);
            yield return new WaitForEndOfFrame();
        }
    }
}