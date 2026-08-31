using UnityEngine;

/// <summary>
/// This Enemigo class is the script used for the enemies and mostly collisions
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class Enemigo : MonoBehaviour
{
    //Variables
    public Transform player;
    //velocidad en la que va seguir al jugador
    public float velocidadPersecucion = 3f;
    //que hace su toca al jugador
    public int penalizacion = 1;

    /// <summary>
    /// Update se actualiza cada frame
    /// </summary>
    void Update()
    {
        if (player == null) return;
        //Hace que el fantasma se mueva hacia la posición que se encuentra el jugador
        transform.position = Vector3.MoveTowards(transform.position, player.position, velocidadPersecucion * Time.deltaTime);
        //La posicion que esta el jugador
        Vector3 objetivo = new Vector3(player.position.x, transform.position.y, player.position.z);
        //Hacia donde tiene que mirar el fantasma
        transform.LookAt(objetivo);
    }
    /// <summary>
    ///Cuando choca con el jugador
    /// </summary>
    void OnCollisionEnter (Collision collision)
    {
        //Compara las etiquetas para ver si fue el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            //Busca el objeto en game master
            GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
            //Se llama al metodo para cuitar una vida
            if(gm != null) gm.Penalizar(penalizacion);
        }
    }
}