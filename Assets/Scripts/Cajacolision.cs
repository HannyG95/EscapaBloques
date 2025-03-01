using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cajacolision : MonoBehaviour
{
    [SerializeField] public GameObject jugador;

    private void Start()
    {
        jugador = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == ("Player"))
        {
            jugador.GetComponent<vidaPlayer>().TomarDaño();
        }
        else
        {
            jugador.GetComponent<vidaPlayer>().RecuperarVida();
        }
    }
}
