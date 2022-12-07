using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemylife : MonoBehaviour
{
    public float PuntosVida;
    public float VidaMaxima = 1;

    void Start()
    {
        PuntosVida = VidaMaxima;
    }

    public void Takehit(float damage)
    {
        PuntosVida -= damage;
        if (PuntosVida <= 0)
        {
            Destroy(gameObject);
        }
    }

}
