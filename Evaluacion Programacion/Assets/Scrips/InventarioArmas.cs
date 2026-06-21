using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Inventory;


public class InventarioArmas : MonoBehaviour
{
    private List<Arma> armas=new List<Arma>();

    public static event Action<Arma> OnArmaEquipada;
   
    void Awake()
    {
        armas.Add(new Arma("Espada", 30));

        EquiparArma("Espada");

        MostrarInventario();
    }

    void EquiparArma(string nombre)
    {
        Arma encontrada= armas.Find(a=> a.nombre==nombre);

        if( encontrada!=null )
        {
            Debug.Log("Equipado: " + encontrada.nombre);
            OnArmaEquipada?.Invoke(encontrada);
        }
    }

    void MostrarInventario()
    {
        foreach(Arma a in armas)
        {
            Debug.Log("En inventario: " + a.nombre + "daño: " + a.dano);
        }
    }


    void OnDisable()
    {
        OnArmaEquipada = null;
    }
}
