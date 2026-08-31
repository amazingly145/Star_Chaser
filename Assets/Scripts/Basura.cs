using UnityEngine;

/// <summary>
/// This Basuraclass is the script used for the enemies and mostly collisions
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class Basura : MonoBehaviour
{
    //Variables
    public int penalizacion = 1; 

    /// <summary>
    /// OnTrigger cada vez cuando el jugador este en contacto con un alien se desaparecen.
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
            if (gm != null) gm.Penalizar(penalizacion);

            Destroy(gameObject);
        }
    }
}