using UnityEngine;
using System.Collections;

public class SpawnWavesManager : MonoBehaviour
{
    public GameObject[] waves;
    private SpawnPointsGenerator[] generator;

    private void Start()
    {
        generator = FindObjectsOfType<SpawnPointsGenerator>();

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
                int value = Random.Range(0, waves.Length);

                GameObject newWave = Instantiate(waves[value]);
                newWave.transform.position = generator[i].listSpawnPoints[j].firstTransform.transform.position;

                if (!generator[i].listSpawnPoints[j].isSpawned)
                {
                    StartCoroutine(WaveMovementCO(newWave, generator[i].listSpawnPoints[j].secondTransform.transform));
                    generator[i].listSpawnPoints[j].isSpawned = true;
                }
            }
        }
        
        yield break;
    }

    private IEnumerator WaveMovementCO(GameObject _wave, Transform _pointTarget)
    {
        _wave.SetActive(true);
        float seconds = 0;
        float randomValue = Random.Range(1f, 5f);
        Vector2 startPosition = _wave.transform.position;
        
        while((_wave.transform.position - _pointTarget.position).magnitude > 0.2f)
        {
            seconds += Time.deltaTime / randomValue;
            _wave.transform.position = Vector2.Lerp(startPosition, _pointTarget.position, seconds);
            yield return null;
        }

        float randomValue_1 = Random.Range(3f, 7f);
        yield return new WaitForSeconds(randomValue_1);

        _wave.gameObject.SetActive(false);

        float randomValue_2 = Random.Range(6f, 12f);
        yield return new WaitForSeconds(randomValue_2);

        _wave.transform.position = startPosition;
        StartCoroutine(WaveMovementCO(_wave, _pointTarget));
        yield break;
    }
}