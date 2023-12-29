using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heart;
    public float spawnRate = 1.0f;  // amount of time until next spawning
    public float leftBound = -8.0f; // Left boundary of spawn area
    public float rightBound = 8.0f; // Right boundary of spawn area
    private float nextSpawnTime;

    private void FixedUpdate()
    {
        int randSeed = Random.Range(0, 1000);
        if (Time.time > nextSpawnTime && randSeed < 5)
        {
            SpawnHeart();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnHeart()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(leftBound, rightBound), transform.position.y, transform.position.z);
        Instantiate(heart, spawnPosition, Quaternion.identity);
    }
}