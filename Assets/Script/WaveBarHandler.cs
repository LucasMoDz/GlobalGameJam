using UnityEngine;

public class WaveBarHandler : MonoBehaviour
{
	private RectTransform rectBar;
	public int count = 15;

    private void Awake()
    {
		rectBar = this.transform.parent.gameObject.GetComponent<RectTransform>();
    }
	
	public void UpdateBar(int _value)
    {
		this.transform.localPosition += new Vector3 (0, rectBar.sizeDelta.y / 30 * _value , 0);
		count += _value;

        CheckArrowLimits();
	}

    private void CheckArrowLimits()
    {
        if (count <= 0)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, -rectBar.sizeDelta.y / 2, this.transform.localPosition.z);
            count = 0;
        }
        else if (count >= 30)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, rectBar.sizeDelta.y / 2, this.transform.localPosition.z);
            count = 30;
        }
    }
}