using UnityEngine;
/// <summary>
/// This player controller class will update the events from the player
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class Premio : MonoBehaviour
{
    /// <summary>
    /// OnTrigger cada vez cuando el jugador este en contacto con un alien se desaparecen.
    /// </summary>
    void OnCollisonEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
            if (gm != null) gm.Rescatar();

            Destroy(gameObject);
        }
    }
}
