using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveBarHandler : MonoBehaviour {

	GameObject parentBar;
	private int maxValue = 100;

	RectTransform parentRT;
	public int count = 15;

	// Use this for initialization
	void Start () {
		
		parentBar = this.transform.parent.gameObject;
		parentRT = parentBar.GetComponent<RectTransform> ();
		Debug.Log (parentRT.sizeDelta.y.ToString());
		//this.transform.localPosition = new Vector3 (this.transform.localPosition.x, -parentRT.sizeDelta.y / 2, this.transform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKeyDown (KeyCode.A) && count < 30) {
			UpdateBar (4);
		} else if (Input.GetKeyDown (KeyCode.D) && count > 0) {
			UpdateBar (-4);
		}*/
	}


	public void UpdateBar(int value) {
		this.transform.localPosition += new Vector3 (0, parentRT.sizeDelta.y/30 * value , 0);
		count += value;
		if (count < 0) {
			this.transform.localPosition = new Vector3 (this.transform.localPosition.x, -parentRT.sizeDelta.y / 2, this.transform.localPosition.z);
			count = 0;
		} else if (count > 30) {
			this.transform.localPosition = new Vector3 (this.transform.localPosition.x, parentRT.sizeDelta.y / 2, this.transform.localPosition.z);
			count = 30;
		}
	}


}
