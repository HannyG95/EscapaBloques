using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Autodestruccion : MonoBehaviour
{
    //public Vector3 posicion;

    void Update()
    {
        if (transform.position.y < -9)
        {
            //GameManager.AnadirScore(10);
            Destroy(gameObject);
        }
    }
}
