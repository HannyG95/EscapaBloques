using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
   public static int score = 0;

   public static void AnadirScore(int cantidad)
   {
      score += cantidad;
      Debug.Log("Puntaje: " + score);
   }
}
