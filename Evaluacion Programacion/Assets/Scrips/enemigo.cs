using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Characters; 

public class TrampaDano : MonoBehaviour
{
    [Header("Configuración")]
    public float cantidadDanio = 20f;

    private void OnTriggerEnter(Collider other)
    {
        
        IDamageable objetivo = other.GetComponent<IDamageable>();

        


        if (objetivo != null)
        {
            objetivo.RecibirDanio(cantidadDanio);
            Debug.Log("daño" + other.name);
        }
    }
}
