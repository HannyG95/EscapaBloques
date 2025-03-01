using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class spawnBox : MonoBehaviour
{
    [Header("Objetos a crear")] 
    public GameObject objeto;
    public GameObject player;

    [Header("Tiempo")] 
    [Range(0, 3f)]
    public float minTiempo;
    [Range(4, 10f)]
    public float maxTiempo;

    private float vA;
    private bool vida = true;

    private void Start()
    {
        StartCoroutine(GenerarCajas());
    }


    IEnumerator GenerarCajas()
    {
        do
        {
            float esperar = UnityEngine.Random.Range(minTiempo, maxTiempo);
            yield return new WaitForSeconds(esperar);

            Vector3 posicion = PosicionAleatoria();
            Instantiate(objeto, posicion, Quaternion.identity);

            vA = player.GetComponent<vidaPlayer>().vidaActual;
            Debug.Log($"Daño:{vA}");

            if (vA > 0)
            {
                vida = true;
            }
            else
            {
                vida = false;
            }
        } while (vA > 0);
    }

    Vector2 PosicionAleatoria()
    {
        float distancia = UnityEngine.Random.Range(0, 5);
        
        float x = player.transform.position.x+distancia;
        float y = 10;
        
        return new Vector2(x, y);
    }
}
//<a href="https://www.flaticon.es/iconos-gratis/caja-de-madera" title="caja de madera iconos">Caja de madera iconos creados por Freepik - Flaticon</a>