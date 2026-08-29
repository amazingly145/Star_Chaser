using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    //la cantidad de victimas que necesitamos ayudar
    public int meta = 3;              // cuántas víctimas hay que rescatar
    //Le digo quien es la salida para ver si ya paso por ahi el objeto
    public Renderer salida;           // para pintarla de color como aviso
    public int vidas = 5;

    private int rescatadas = 0; //contador de victimas resctadas
    private bool terminada = false; //condicion de victoria

    // ¿Ya se rescataron todas? La Salida lo consulta antes de dejar ganar.
    //Definimos un metodo para ver si cumplimos o no la mision
    public bool MisionCumplida
    {
        get { return rescatadas >= meta; }
    }

    public void Rescatar()
    {
        if (terminada) return;
        //sumo las personas rescatadas
        rescatadas++;
        //se retroalimentan a los usuarios
        Debug.Log("Víctima rescatada (" + rescatadas + " de " + meta + ")");
        // Si se cumple el metodo de mision cumplida, retroalimento al usuario
        if (MisionCumplida)
        {
            Debug.Log("Todas rescatadas. Ve a la salida.");
            if (salida != null) salida.material.color = Color.green;
        }
    }

    public void Ganar()
    {
        //si no he ganado cambio la variable a true
        if (terminada) return;
        terminada = true;
        Debug.Log("¡Ganaste!");
    }

    public void Perder()
    {
        if (terminada) return;
        terminada = true;
        Debug.Log("Perdiste");
        if (salida != null) salida.material.color = Color.red;
        //reinicio el juego
        Invoke("Reiniciar", 1.5f);   // deja ver el mensaje antes de reiniciar
    }

    void Reiniciar()
    {
        //scenemanager, la escena que tenemos la resetea
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Penalizar(int cantidad)
    {
        vidas -= cantidad;
        Debug.Log("Vida perdida. Vidas restantes: " + vidas);
        if (vidas <= 0)
        {
            Perder();
        }
    }
}
