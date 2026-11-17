using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfig waveConfig;
    Transform[] waypoints;
    int waypointIndex = 0;

    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        Debug.Log("Spawner: " + enemySpawner);

        waveConfig = enemySpawner.GetCurrentWave();
        Debug.Log("WaveConfig: " + waveConfig);

        waypoints = waveConfig.GetWaypoints();
        Debug.Log("Waypoint count: " + waypoints.Length + ", speed: " + waveConfig.GetEnemyMoveSpeed());

        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        // Prevents repeated errors if Start() failed before waypoints were set
        if (waypoints == null)
        {
            return;
        }

        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;

            float moveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDelta);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}