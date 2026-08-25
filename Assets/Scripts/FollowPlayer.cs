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
    private Vector3 offset = new Vector3(-0.68f,1.85f,-2.41f);
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
        //la camara toma posicion de nuestro vehiculo
        //son las coordenadas que tenemos posicionada la camara y la que nos interesa ver la camioneta
        //transform.position = player.transform.position + new Vector3 (0,6,-7);
        transform.position = player.transform.position + offset;
        
    }
}
