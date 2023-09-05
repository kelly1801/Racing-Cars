using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float minSpawnInterval = 1f;
    [SerializeField] float maxSpawnInterval = 5f;
    [SerializeField] private GameObject road;
    private float outboundY;
    private float outboundX;
  
    private void Start()
    {
        outboundX = road.GetComponent<BoxCollider>().size.x / 2;
        outboundY = road.GetComponent<BoxCollider>().size.y / 2;

        StartCoroutine(SpawnObstaclesCoroutine());
    }

  

    private IEnumerator SpawnObstaclesCoroutine()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(1);

            // Get a pooled object from the ObjectPool
            GameObject obstacle = ObjectPool.instance.GetPooledObject();

            if (obstacle != null)
            {

                float randomPosX = Random.Range(
                   -outboundX, outboundX
               );
                float randomPosY = Random.Range(
                    -outboundY, outboundY
                );
                float randomPosZ = Random.Range(10, 181);
                Vector3 randomPosition = new Vector3(randomPosX, randomPosY, randomPosZ);

                // Set the obstacle's position and activate it
                obstacle.transform.position = randomPosition;
                obstacle.SetActive(true);
            }
            
        }
    }
}
