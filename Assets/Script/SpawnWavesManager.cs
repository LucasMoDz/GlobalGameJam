using UnityEngine;
using System.Collections;

public class SpawnWavesManager : MonoBehaviour
{
    public GameObject[] waves;

    private ObjectPool objectPool;
    private SpawnPointsGenerator[] generator;

    private void Start()
    {
        generator = FindObjectsOfType<SpawnPointsGenerator>();
        objectPool = FindObjectOfType<ObjectPool>();

        StartWavesManager();
    }

    public void StartWavesManager()
    {
        StartCoroutine(ManagerWavesCO());
    }

    private IEnumerator ManagerWavesCO()
    {
        for (int i = 0; i < generator.Length; i++)
        {
            for (int j = 0; j < generator[i].listSpawnPoints.Count; j++)
            {
                int value = Random.Range(0, waves.Length - 1);
                GameObject newWave = waves[value].Spawn(generator[i].listSpawnPoints[j].firstTransform.transform.position);

                Vector2 direction = generator[i].listSpawnPoints[j].secondTransform.transform.position - generator[i].listSpawnPoints[j].firstTransform.transform.position;
                direction.Normalize();

                newWave.GetComponent<Rigidbody2D>().AddForce(direction * 3, ForceMode2D.Impulse);

                yield return new WaitForSeconds(Random.Range(0, 1.5f));
            }
        }
        
        yield break;
    }
}