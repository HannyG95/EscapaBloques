using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BRainBox : MonoBehaviour
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
            GameObject nuevaCaja = Instantiate(objeto, posicion, Quaternion.identity);

            // Verificamos si es una caja de daño o de vida
            if (nuevaCaja.CompareTag("CajaCerebro"))
            {
                player.GetComponent<vidaPlayer>().RecuperarVida();
            }
            else
            {
                player.GetComponent<vidaPlayer>().TomarDaño();
            }

            vA = player.GetComponent<vidaPlayer>().vidaActual;
            Debug.Log($"Vida actual: {vA}");

            vida = vA > 0;

        } while (vA > 0);
    }

    Vector2 PosicionAleatoria()
    {
        float distancia = UnityEngine.Random.Range(0, 5);
        float x = player.transform.position.x + distancia;
        float y = 10;
        
        return new Vector2(x, y);
    }
}