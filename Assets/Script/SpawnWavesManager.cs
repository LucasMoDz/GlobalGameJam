using UnityEngine;
using System.Collections;

public class SpawnWavesManager : MonoBehaviour
{
    public GameObject[] waves;

    private SpawnPointsGenerator generator;

    private void Awake()
    {
        generator = FindObjectOfType<SpawnPointsGenerator>();
    }

    public void StartWavesManager()
    {
        StartCoroutine(ManagerWavesCO());
    }

    private IEnumerator ManagerWavesCO()
    {
        while (true)
        {
            for (int i = 0; i < generator.listSpawnPoints.Count; i++)
            {
                generator.listSpawnPoints[i].firstTransform.GetComponent<Rigidbody2D>().AddForce(generator.listSpawnPoints[i].secondTransform.transform.position - generator.listSpawnPoints[i].firstTransform.transform.position, ForceMode2D.Impulse);
            }
        }
    }
}