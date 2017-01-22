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
                StartCoroutine(WaveMovementCO(newWave, generator[i].listSpawnPoints[j].secondTransform.transform));
            }
        }
        
        yield break;
    }

    private IEnumerator WaveMovementCO(GameObject _wave, Transform _pointTarget)
    {
        _wave.SetActive(true);
        float seconds = 0;
        float randomValue = Random.Range(1f, 3f);
        Vector2 startPosition = _wave.transform.position;
        
        while((_wave.transform.position - _pointTarget.position).magnitude > 0.2f)
        {
            seconds += Time.deltaTime / randomValue;
            _wave.transform.position = Vector2.Lerp(startPosition, _pointTarget.position, seconds);
            yield return null;
        }

        randomValue = Random.Range(3f, 6f);
        yield return new WaitForSeconds(randomValue);

        _wave.gameObject.SetActive(false);

        randomValue = Random.Range(6f, 12f);

        yield return new WaitForSeconds(randomValue);

        _wave.transform.position = startPosition;
        StartCoroutine(WaveMovementCO(_wave, _pointTarget));
        yield break;
    }
}