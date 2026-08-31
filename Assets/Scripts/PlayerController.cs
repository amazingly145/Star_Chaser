using UnityEngine;

/// <summary>
/// This player controller class will update the events from the player
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    //variables
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
    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //Obtenemos la animacion
        animator = GetComponentInChildren<Animator>();
    }
    /// <summary>
    /// Update se actualiza cada frame
    /// </summary>
    void Update()
    {
        //El script pone la animacion y asigna una variable.
        if (animator != null)
            animator.SetFloat("velocidad", movimiento.magnitude);
        //Cambio entre cámaras
        if(Input.GetKeyDown(switchKey))
        {
        mainCamera.enabled = !mainCamera.enabled;
        hoodCamera.enabled = !hoodCamera.enabled;
        }
        //Girar con las teclas de derecha e izquiera y de arriba hacia abajo
        avance = Input.GetAxisRaw("Vertical"); 
        giro = Input.GetAxisRaw("Horizontal");   
    }

    void FixedUpdate()
    {
        //Mover hacia adelante 
        movimiento = transform.forward * avance * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimiento);

        //Girar los 360 grados en la dirección que quiera la persona
        float rotacion = giro * velocidadGiro * Time.fixedDeltaTime;
        Quaternion giroDelta = Quaternion.Euler(0f, rotacion, 0f);
        rb.MoveRotation(rb.rotation * giroDelta);
    }
}