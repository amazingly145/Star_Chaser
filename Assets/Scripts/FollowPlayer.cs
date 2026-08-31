using UnityEngine;

/// <summary>
/// This Follow Player class will update the events from the main camera.
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class FollowPlayer : MonoBehaviour
{
    //Variables
    //llamamos el jugador que va seguir la camara
    public GameObject player;
    //La posicion en que va estar la camara
    public Vector3 offset = new Vector3(-1.11f,2.345f,-9f);
    //Varaibles de suavizado para que el movimiento de la cámara no sea tan brusco
    public float suavizadoPosicion = 5f;
    public float suavizadoRotacion = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    // LateUpdate is called once per frame
    /// <summary>
    /// This method is called after Update, once the game is Startes
    /// </summary>
    void LateUpdate()
    {
        if (player == null) return;
        Vector3 offsetRotado = player.transform.rotation * offset;
        Vector3 posicionDeseada = player.transform.position + offsetRotado;
        //Mueve la cámara hacia la posición que esta mirando el personaje
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizadoPosicion * Time.deltaTime);

        //Gira para poder seguir al jugador
        Quaternion rotacionDeseada = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavizadoRotacion * Time.deltaTime);
        
    }
}
