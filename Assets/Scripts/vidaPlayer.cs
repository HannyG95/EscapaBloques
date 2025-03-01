using UnityEngine;

public class vidaPlayer : MonoBehaviour
{
    [Header("Vida del jugador")]
    public float vidaActual;

    public float daño = 15f;
    public float masVida = 15f;

    void Start()
    {
        vidaActual = VariablesGlobales.vidaPlayer;
    }

    public void TomarDaño()
    {
        vidaActual -= daño;
        //Debug.Log($"Daño: {vidaActual}");
        if (vidaActual <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    
    public void RecuperarVida()
    {
        vidaActual += masVida;
        if (vidaActual > VariablesGlobales.vidaPlayer)
        {
            vidaActual = VariablesGlobales.vidaPlayer;
        }
        Debug.Log($"Vida recuperada: {vidaActual}");
    }
}