using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Inventory;

namespace RPG.Inventory
{
    public class ItemRecoger : MonoBehaviour
    {
        public string nombreArma;
        public int danoArma;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                InventarioArmas inventario = other.GetComponent<InventarioArmas>();

                if (inventario != null)
                {
                    Arma nuevaArma = new Arma(nombreArma, danoArma);
                    inventario.AgregarArma(nuevaArma);
                    Destroy(gameObject);
                }
            }
        }
    }
}