using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{

    public GameObject asteroid;
    public float spawnTime;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsteroidSpawnManager());
    }

    IEnumerator AsteroidSpawnManager()
    {
        while (gameManager.isGameActive)
        {           
            yield return new WaitForSeconds(spawnTime);
            Instantiate(asteroid, transform.position, transform.rotation);
            if (spawnTime > 1)
            {
                spawnTime -= 0.1f;
            }
        }
    }
} 
