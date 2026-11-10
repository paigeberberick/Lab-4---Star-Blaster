using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfig currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(
                currentWave.GetEnemyPrefab(i),
                currentWave.GetStartingWaypoint().position,
                Quaternion.identity,
                transform);
        }

    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
}

