using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadGiro = 100f; 
    public Camera mainCamera;
    private Animator animator;
    public Camera hoodCamera;
    public KeyCode switchKey;
    private Rigidbody rb;
    private float avance;
    private float giro;
    private Vector3 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        Debug.LogError("¡Animator no encontrado!");
        else
        Debug.Log("Animator encontrado correctamente en: " + animator.gameObject.name);
    }

    void Update()
    {
         // El script no elige la animación: solo informa. Decidir es del Animator.
        if (animator != null)
            animator.SetFloat("velocidad", movimiento.magnitude);
        //Cambio entre cámaras
        if(Input.GetKeyDown(switchKey))
        {
        mainCamera.enabled = !mainCamera.enabled;
        hoodCamera.enabled = !hoodCamera.enabled;
        }
        avance = Input.GetAxisRaw("Vertical"); 
        giro = Input.GetAxisRaw("Horizontal");   
    }

    void FixedUpdate()
    {
        // Mover hacia adelante/atrás en la dirección actual del jugador
        movimiento = transform.forward * avance * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimiento);

        // Girar libremente sobre el eje Y, sin límite de dirección
        float rotacion = giro * velocidadGiro * Time.fixedDeltaTime;
        Quaternion giroDelta = Quaternion.Euler(0f, rotacion, 0f);
        rb.MoveRotation(rb.rotation * giroDelta);
    }
}