using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Control
{

    [RequireComponent(typeof(CharacterController))]
    public class PlayerSimpleController : MonoBehaviour
    {
        [Header("Movimiento")]
        public float velocidad = 5f;
        public float gravedad = -9.81f;
        public float fuerzaSalto = 5.5f;

        [Header("Cámara y ratón")]
        public float sensibilidadRaton = 2f;
        public float limiteVerticalArriba = 80f;   // grados máximos mirando hacia arriba
        public float limiteVerticalAbajo = -80f;   // grados máximos mirando hacia abajo

        [Header("Referencias")]
        public Transform camara;    // ← Arrastra aquí la cámara (debe ser hijo del player)

        private CharacterController controller;
        private Vector3 velocidadVertical;
        private float rotacionXActual = 0f;   // Para controlar la rotación vertical de la cámara

        void Start()
        {
            controller = GetComponent<CharacterController>();

            // Ocultar y bloquear cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // Validamos que la cámara esté asignada
            if (camara == null)
            {
                Debug.LogError("¡No hay cámara asignada en el componente PlayerSimpleController!");
            }
        }

        void Update()
        {
            ProcesarRotacionRaton();
            ProcesarMovimientoHorizontal();
            ProcesarSaltoYGravedad();
            AplicarMovimiento();
        }

        // ────────────────────────────────────────────────
        // 1. Rotación con ratón (horizontal en cuerpo, vertical en cámara)
        // ────────────────────────────────────────────────
        private void ProcesarRotacionRaton()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibilidadRaton;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidadRaton;

            // Rotación horizontal → gira todo el personaje
            transform.Rotate(0, mouseX, 0);

            // Rotación vertical → solo la cámara (mirar arriba/abajo)
            rotacionXActual -= mouseY;                    // invertimos porque positivo suele ser abajo
            rotacionXActual = Mathf.Clamp(rotacionXActual, limiteVerticalAbajo, limiteVerticalArriba);

            // Aplicamos solo rotación en X a la cámara
            if (camara != null)
            {
                camara.localRotation = Quaternion.Euler(rotacionXActual, 0, 0);
            }
        }

        // ────────────────────────────────────────────────
        // 2. Movimiento WASD relativo a la dirección del personaje
        // ────────────────────────────────────────────────
        private void ProcesarMovimientoHorizontal()
        {
            float horizontal = Input.GetAxisRaw("Horizontal"); // A / D
            float vertical = Input.GetAxisRaw("Vertical");   // W / S

            Vector3 direccion = transform.forward * vertical + transform.right * horizontal;

            // Normalizamos para evitar velocidad extra en diagonal
            if (direccion.magnitude > 1f)
            {
                direccion.Normalize();
            }

            // Guardamos movimiento horizontal (lo usaremos luego)
            movimientoHorizontal = direccion * velocidad;
        }

        private Vector3 movimientoHorizontal; // variable auxiliar para no calcularlo dos veces

        // ────────────────────────────────────────────────
        // 3. Salto + Gravedad
        // ────────────────────────────────────────────────
        private void ProcesarSaltoYGravedad()
        {
            // Reset cuando toca el suelo
            if (controller.isGrounded && velocidadVertical.y < 0)
            {
                velocidadVertical.y = -2f; // pequeño valor para no "flotar"
            }

            // Salto solo si está en el suelo
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                velocidadVertical.y = fuerzaSalto;
            }

            // Aplicamos gravedad siempre
            velocidadVertical.y += gravedad * Time.deltaTime;
        }

        // ────────────────────────────────────────────────
        // 4. Aplicar todo el movimiento combinado
        // ────────────────────────────────────────────────
        private void AplicarMovimiento()
        {
            // Combinamos movimiento horizontal + vertical
            Vector3 movimientoFinal = movimientoHorizontal;
            movimientoFinal.y = velocidadVertical.y;

            // Movemos al personaje
            controller.Move(movimientoFinal * Time.deltaTime);
        }
    }
}