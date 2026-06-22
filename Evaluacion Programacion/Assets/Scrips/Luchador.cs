using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class Luchador : PlayerBase
    {
        public override void UsarHabilidadEspecial()
        {
            Debug.Log("golpe fuerte");
        }
    }
}