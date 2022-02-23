using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private float maxTimeSpawn;
    [SerializeField]
    private float minTimeSpawn;

    private float instantiateTime = 0;  

    // Update is called once per frame
    void Update()
    {
        if (Time.time > instantiateTime)
        {
            SpawnObstacle();       
            instantiateTime = Time.time +Random.Range(minTimeSpawn, maxTimeSpawn);;
        }
    }

    private void SpawnObstacle()
    {
        int randomObstacle = Random.Range(0, obstacles.Length);
        int randomPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(obstacles[randomObstacle], spawnPoints[randomPoint].position, Quaternion.identity);
    }
}
