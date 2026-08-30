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
    public Vector3 offset = new Vector3(-1.11f,2.345f,-9f);
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
        // Mueve la cámara suavemente hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizadoPosicion * Time.deltaTime);

        // Gira suavemente para seguir mirando al jugador
        Quaternion rotacionDeseada = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavizadoRotacion * Time.deltaTime);
        
    }
}
