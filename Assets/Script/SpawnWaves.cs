using UnityEngine;
using System.Collections.Generic;

public class SpawnWaves : MonoBehaviour
{
    [Range(0, 100)]
    public int spawnPercentage;

    public List<SpawnPoint> listSpawnPoints;
    private EdgeCollider2D[] sides;

    private void Awake()
    {
        InitialiseArray(2);
        GenerateSpawnPoints();
    }

    private void InitialiseArray(byte _number)
    {
        sides = new EdgeCollider2D[_number];

        for (int i = 0; i < sides.Length; i++)
            sides[i] = this.transform.GetChild(i).GetComponent<EdgeCollider2D>();
    }

    public void GenerateSpawnPoints()
    {
        #region Create child point
        for (int i = 0; i < sides.Length; i++)
        {
            for (int j = 0; j < sides[i].pointCount; j++)
            {
                GameObject newTransform = new GameObject();
                newTransform.transform.SetParent(sides[i].gameObject.transform);
                newTransform.transform.name = newTransform.transform.parent.name + "_Child(" + i + ")";
                newTransform.transform.localPosition = new Vector2(sides[i].points[j].x, sides[i].points[j].y);
            }
        }
        #endregion

        #region Create targets list
        for (int i = 0; i < sides[0].transform.childCount; i++)
        {
            if (Random.Range(0, 101) > 100 - spawnPercentage)
            {
                SpawnPoint newCoppia = new SpawnPoint(sides[0].transform.GetChild(i).gameObject, sides[1].transform.GetChild(i).gameObject);
                listSpawnPoints.Add(newCoppia);
            }
            else
            {
                Destroy(sides[0].transform.GetChild(i).gameObject);
                Destroy(sides[1].transform.GetChild(i).gameObject);
            }
        }
        #endregion
    }
}

[System.Serializable]
public class SpawnPoint
{
    public GameObject firstTransform, secondTransform;

    public SpawnPoint(GameObject _first, GameObject _second)
    {
        firstTransform = _first;
        secondTransform = _second;
    }
}