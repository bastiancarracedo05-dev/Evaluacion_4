using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class Paladin : PlayerBase
    {
        public override void UsarHabilidadEspecial()
        {
            Debug.Log("aura");
        }
        public override void RecibirDanio(float cantidad)
        {
            float danoMitigado = cantidad * 0.9f;
            base.RecibirDanio(danoMitigado);
        }
    }
}