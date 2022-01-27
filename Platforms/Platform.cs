using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform platformTransform; 

    [SerializeField] private float lifeTime;
    [SerializeField] private float sizeOfPlatform;

    [SerializeField] private Text lifeTimeScore;

    private void Start()
    {
        Invoke(nameof(Destruction), lifeTime);
        Invoke(nameof(SpawnNewPlatform), lifeTime / 2);

        int numberOfEnemies = Random.Range(3, 6);
        float rangeForSpawn = sizeOfPlatform / 2 - 1;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 enemyPosition = platformTransform.position;
            enemyPosition.x += Random.Range(-rangeForSpawn, rangeForSpawn);
            enemyPosition.z += Random.Range(-rangeForSpawn, rangeForSpawn);

            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        }
    }

    private void SpawnNewPlatform()
    {
        Vector3 newPosition = platformTransform.position;

        switch (Random.Range(0, 4))
        {
            case 0:
                newPosition.x += sizeOfPlatform;
                break;
            case 1:
                newPosition.x -= sizeOfPlatform;
                break;
            case 2:
                newPosition.z += sizeOfPlatform;
                break;
            case 3:
                newPosition.z -= sizeOfPlatform;
                break;
        }

        Instantiate(platformPrefab, newPosition, Quaternion.identity);
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }
}