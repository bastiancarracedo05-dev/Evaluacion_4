using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio : MonoBehaviour
{
   
    public string claseParaAsignar;

    private void OnTriggerEnter(Collider other)
    {
        
        GestorClases gestor = other.GetComponent<GestorClases>();

        if (gestor != null)
        {
            
            gestor.CambiarRol(claseParaAsignar);

          
            Debug.Log("cambio de clasea " + claseParaAsignar + "!");
        }
    }
}