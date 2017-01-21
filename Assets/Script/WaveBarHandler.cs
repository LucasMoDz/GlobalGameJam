using UnityEngine;

public class WaveBarHandler : MonoBehaviour
{
	private RectTransform rectArrow;
	public int count = 15;
    public RectTransform rectTarget;
    private RectTransform rectTargetFather;

    private void Awake()
    {
		rectArrow = this.transform.parent.gameObject.GetComponent<RectTransform>();
        rectTarget = rectTarget.transform.gameObject.GetComponent<RectTransform>();
        rectTargetFather = rectTarget.transform.parent.gameObject.GetComponent<RectTransform>();
    }
	
	public void UpdateBar(int _value)
    {
		this.transform.localPosition += new Vector3 (0, rectArrow.sizeDelta.y / 30 * _value , 0);
		count += _value;

        CheckArrowLimits();
	}

    private void CheckArrowLimits()
    {
        if (count <= 0)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, -rectArrow.sizeDelta.y / 2, this.transform.localPosition.z);
            count = 0;
        }
        else if (count >= 30)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, rectArrow.sizeDelta.y / 2, this.transform.localPosition.z);
            count = 30;
        }
    }

    private void CheckTargetLimits()
    {
        if (count <= 0)
        {
            rectTarget.transform.localPosition = new Vector3(rectTarget.transform.localPosition.x, -rectTargetFather.sizeDelta.y / 2, rectTarget.transform.localPosition.z);
            count = 0;
        }
        else if (count >= 30)
        {
            rectTarget.transform.localPosition = new Vector3(rectTarget.transform.localPosition.x, rectTargetFather.sizeDelta.y / 2, rectTarget.transform.localPosition.z);
            count = 30;
        }
    }

    public void UpdateTarget(int _value)
    {
        switch (_value)
        {
            case 1:
            rectTarget.transform.localPosition += new Vector3(0, rectTargetFather.sizeDelta.y / 5 * _value, 0);
                break;

            case 2:
                rectTarget.transform.localPosition += new Vector3(0, rectTargetFather.sizeDelta.y / 5 * _value, 0);
                break;

            case 3:
                rectTarget.transform.localPosition += new Vector3(0, rectTargetFather.sizeDelta.y / 5 * _value, 0);
                break;

            case 4:
                rectTarget.transform.localPosition += new Vector3(0, rectTargetFather.sizeDelta.y / 5 * _value, 0);
                break;
            case 5:
                rectTarget.transform.localPosition += new Vector3(0, rectTargetFather.sizeDelta.y / 5 * _value, 0);
                break;
           
        }

        
      //  count += _value;

      //  CheckTargetLimits();
    }
}