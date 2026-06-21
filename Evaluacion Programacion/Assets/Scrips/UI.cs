using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Inventory;
public class UI : MonoBehaviour
{
    void OnEnable()
    {
        InventarioArmas.OnArmaEquipada += AlEquiparArma;
    }
    void OnDisable()
    {
        InventarioArmas.OnArmaEquipada -= AlEquiparArma;
    }
    void AlEquiparArma(Arma arma)
    {
        Debug.Log("UI recibió el evento: se equipó " + arma.nombre);
    }
}