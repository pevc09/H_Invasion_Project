using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Bullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(Bullet, FirePoint.position, transform.rotation);
        }

    }
}