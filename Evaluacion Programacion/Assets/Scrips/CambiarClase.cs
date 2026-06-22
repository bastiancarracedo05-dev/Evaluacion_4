using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Characters;

public class GestorClases : MonoBehaviour
{
 

    public void CambiarRol(string nombreClase)
    {

        Luchador luchador = GetComponent<Luchador>();
        if (luchador != null) Destroy(luchador);

        Mago mago = GetComponent<Mago>();
        if (mago != null) Destroy(mago);

        Paladin paladin = GetComponent<Paladin>();
        if (paladin != null) Destroy(paladin);

        switch (nombreClase)
        {
            case "Luchador": gameObject.AddComponent<Luchador>(); break;
            case "Mago": gameObject.AddComponent<Mago>(); break;
            case "Paladin": gameObject.AddComponent<Paladin>(); break;
        }

    }

 
    public void SeleccionarLuchador() { CambiarRol("Luchador"); }
    public void SeleccionarMago() { CambiarRol("Mago"); }
    public void SeleccionarPaladin() { CambiarRol("Paladin"); }
}