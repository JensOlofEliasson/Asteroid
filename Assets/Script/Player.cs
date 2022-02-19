using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed;
    public float rotationSpeed;


    private void Start()
    {
       
    }
   
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.back * rotationSpeed * horizontalInput * Time.deltaTime);

        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("WallLeft"))
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
        if(other.gameObject.CompareTag("WallRight"))
        {
            transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        }
        if(other.gameObject.CompareTag("WallUp"))
        {
            transform.position = new Vector3(transform.position.x, -10, transform.position.z);
        }
        if(other.gameObject.CompareTag("WallDown"))
        {
            transform.position = new Vector3(transform.position.x, 12, transform.position.z);
        }
    }
}

