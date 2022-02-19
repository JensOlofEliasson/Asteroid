using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject ammoPrefab;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ammoPrefab, transform.position, transform.rotation);
        }
    }
}
