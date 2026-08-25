using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// This player controller class will update the events from the vehicle player.
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class PlayerController : MonoBehaviour
{
    //Variables
    //velocidad del vehiculo
    public float speed = 20.0f;
    //variable global para la velocidad de giro
    public float turnSpeed = 20.0f;
    //Variable para mover el teclado
    public float horizontalInput;
    //variable para que el carro se mueva para adelante
    public float forwardInput;

    //Camera variables
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey; //Tecla que permite cambiar entre cámaras
    //Multiplayer variables
    public string inputId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Mover vehículo hacia adelante
        //transform.Translate(0,0,1);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Modificar el giro
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        //Vamos a poder girar
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        //Cambio entre camaras
        if(Input.GetKeyDown (switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled  = !hoodCamera.enabled;
        }
    }
}

