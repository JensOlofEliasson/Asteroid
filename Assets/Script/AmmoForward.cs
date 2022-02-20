using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoForward : MonoBehaviour
{
    float speed = 20f;
    float timeToDestroy = 0.8f;

    private void Start()
    {
        StartCoroutine(destroyAmmo());
    }

    IEnumerator destroyAmmo()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WallLeft"))
        {
            //Debug.Log("Ammo WallLeft");
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
        if (other.gameObject.CompareTag("WallRight"))
        {
            //Debug.Log("Ammo WallRight");
            transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        }
        if (other.gameObject.CompareTag("WallUp"))
        {
            //Debug.Log("Ammo WallUp");
            transform.position = new Vector3(transform.position.x, -10, transform.position.z);
        }
        if (other.gameObject.CompareTag("WallDown"))
        {
            //Debug.Log("WallDown");
            transform.position = new Vector3(transform.position.x, 12, transform.position.z);
        }
    }
}
