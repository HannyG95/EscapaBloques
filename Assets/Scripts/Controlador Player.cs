using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Controles controles;

    public Vector2 direccion;
    
    public Rigidbody2D rb;
    public float velocidad;
    
    [Header("Animaciones")]
    
    public Animator animator;

    public bool dir = true;
    private void Awake()
    {
        controles = new ();
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }

    private void Update()
    {
        direccion = controles.Base.mover.ReadValue<Vector2>();
        AjustarRotacion(direccion.x);
        animarMovimiento();
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Time.fixedDeltaTime * direccion * velocidad ); //Controla la velocidad lo que hace que relacione que a > velocidad camina
    }

    private void animarMovimiento()
    {
        animator.SetFloat("Speed", Math.Abs(direccion.x)); //Interpola el idle con el walk, el math es para que camine en ambas direcciones
    }

    private void AjustarRotacion(float dirx)
    {
        if (dirx != 0)
        {
            bool nuevaDireccion = direccion.x > 0;
            if (nuevaDireccion != dir)
            {
                dir= nuevaDireccion;
                Vector3 escala = transform.localScale;
                escala.x = dir ? Math.Abs(escala.x) : -Math.Abs(escala.x);
                transform.localScale = escala;
            }
        }
    }
}

