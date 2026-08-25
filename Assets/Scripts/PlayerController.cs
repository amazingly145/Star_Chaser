using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private Vector3 movimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;   // que no se voltee
    }

    void Update()   // cada frame: leer el teclado
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movimiento = new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()   // física: mover con el Rigidbody
    {
        rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
    }
}

