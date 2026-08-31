using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This GameMaster has the logic of all the game: winning, losing and restarting 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class GameMaster : MonoBehaviour
{
    //Variables
    //la cantidad de victimas que necesitamos ayudar
    public int meta = 3;
    //El numero de vidas que tiene el jugador
    public int vidas = 5;
    //cuántas estrellas ha ganado
    public int rescatadas = 0;
    //Condición de victoria
    private bool terminada = false;
    //Cuando el usuario gana, sale el panel de ganar
    public GameObject panelGanaste;
    //cuando el usuario pierde, sale el panel de perder
    public GameObject panelPerdiste;
    //Cuando el jugador gana
    //Definimos el metodo cuando se obtienen todas las estrellas 
    public bool MisionCumplida
    {
        get { return rescatadas >= meta; }
    }

    //Sumar las estrellas ganadas
    /// <summary>
    /// Rescatar se llama cada vez que se obtienen estrellas 
    /// <summary>
    public void Rescatar()
    {
        if (terminada) return;
        //sumo las estrellas obtenidas
        rescatadas++;
        //se retroalimentan a los usuarios
        // Si se cumple el metodo de mision cumplida, retroalimento al usuario
        if(rescatadas == 3)
        {
            Ganar();
        }
    }
    
    //Definimos el metodo que hace al usuario ganar
    /// <summary>
    /// Ganar se llama cuando se tiene la meta de todas las estrellas
    /// <summary>
    public void Ganar()
    {
        //si no he ganado cambio la variable a true
        if (terminada) return;
        terminada = true;
        if (panelGanaste != null)
        {
            //Obtenemos el canvas de ganar
            panelGanaste.SetActive(true);
        }
        //Detiene todo el juego
        Time.timeScale = 0f;
    }

    //Metodo cuando el usuario pierde
    /// <summary>
    /// Perder se llama caundo se han agotado todas las vidas
    /// <summary>
    public void Perder()
    {
        //regresa true que ya se acabó la partida
        if (terminada) return;
        terminada = true;
        //Obtengo el panel de perder
        if (panelPerdiste != null)
        {
            panelPerdiste.SetActive(true);
        }
        //Detiene todo el juego
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Reiniciar se llama en el canvas de pausa y cuando se gana/pierde, para que el jugador pueda empezar de nuevo
    /// <summary>
    public void Reiniciar()
    {
        //Reiniciamos la partida
        //velocidad a la que transcurre el tiempo en unity, empeza normal
        Time.timeScale = 1f;
        //Vuelve a reinicar la escene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Metodo para quitar vidas 
    /// <summary>
    /// Penalizar se llama para quitarle vidas al jugador
    /// <summary>
    public void Penalizar(int cantidad)
    {
        //Le quito vidas - 1
        vidas -= cantidad;
        //Si se tienen 0 vidas entonces el usuario 
        if (vidas <= 0)
        {
            Perder();
        }
    }
}
