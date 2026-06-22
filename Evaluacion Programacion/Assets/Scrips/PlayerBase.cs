using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace RPG.Characters
{
    public interface IDamageable
    {
        void RecibirDanio(float cantidad);
    }

    public abstract class PlayerBase : MonoBehaviour, IDamageable
    {
        [Header("estadisticas")]
        public float maxVida = 100f;
        protected float vidaActual;

        public static event Action<float> OnVidaCambiada;

        protected virtual void Start()
        {
            vidaActual = maxVida;
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UsarHabilidadEspecial();
            }
        }

        public abstract void UsarHabilidadEspecial();

        public virtual void RecibirDanio(float cantidad)
        {
            vidaActual -= cantidad;
            Debug.Log(gameObject.name + "recisbiste daño, vida:" + vidaActual);

            OnVidaCambiada?.Invoke(vidaActual);
        }
    }
}