using UnityEngine;

/// <summary>
/// This Caja class is used to put random objetcts in side the boxes
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
//Es el que manda a llamar al gestor de cajas
public enum TipoContenido { Alien, Premio };

public class Caja : MonoBehaviour
{
    //Varaibles
    public TipoContenido tipoContenido;
    //arreglo de aliens
    [HideInInspector] public GameObject aliens;
    //arreglo de los premios
    [HideInInspector] public GameObject premio;
    /// <summary>
    /// OnTrigger cada vez cuando el jugador este en contacto con un alien se desaparecen.
    /// </summary>

    void OnTriggerEnter(Collider other)
    {
        //Si el jugador tiene contacto con las cajas
        if (other.CompareTag("Player"))
        {
            //Si lo que esta adentro es un premiio
            if (tipoContenido == TipoContenido.Premio)
            {
                //Si esta vacia la caja poner un premio
                if (premio != null)
                    Instantiate(premio, transform.position, Quaternion.identity);

                GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
                if (gm != null) gm.Rescatar();
            //Sino es un alien
            }else{
                if (aliens != null)
                    Instantiate(aliens, transform.position, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }
}