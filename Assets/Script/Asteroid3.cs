using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid3 : MonoBehaviour
{
    private GameManager gameManager;
    public float speed = 2f;
    private float randomDirection = 180;
    // public GameObject asteroid;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        float randonRotationz = Random.Range(-randomDirection, randomDirection);
        transform.Rotate(new Vector3(0, 0, randonRotationz));
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ammo"))
        {
            gameManager.UpdateScore(300);
            Destroy(gameObject);
            Destroy(other.gameObject);
            // Instantiate(asteroid, transform.position, transform.rotation);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            gameManager.GameOver();
        }
        if (other.gameObject.CompareTag("WallLeft"))
        {
            transform.position = new Vector3(22, transform.position.y, transform.position.z);
        }
        if (other.gameObject.CompareTag("WallRight"))
        {
            transform.position = new Vector3(-22, transform.position.y, transform.position.z);
        }
        if (other.gameObject.CompareTag("WallUp"))
        {
            transform.position = new Vector3(transform.position.x, -13, transform.position.z);
        }
        if (other.gameObject.CompareTag("WallDown"))
        {
            transform.position = new Vector3(transform.position.x, 13, transform.position.z);
        }
    }

}
