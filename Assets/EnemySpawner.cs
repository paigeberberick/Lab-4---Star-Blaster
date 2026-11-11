using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfig currentWave;
    [SerializeField] WaveConfig[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (WaveConfig wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {

                Instantiate(
                    currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingWaypoint().position,
                    Quaternion.identity,
                    transform);

                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
}

