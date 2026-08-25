using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //velocidad porque se va estar moviendo de lugar
    public float velocidad = 2f;   // qué tan rápido se desplaza
    public float alcance = 3f;     // cuántas unidades se aleja del centro
    //tiene un origen que es el vector inicial
    private Vector3 origen;

    void Start()
    {
        origen = transform.position;
    }

    void Update()
    {
        // PingPong va y viene entre 0 y alcance*2; al restar alcance
        // el recorrido queda centrado en la posición original.
        //funcion ping pong: va y regresa, da el movimiento necesario para que se mueva
        float desfase = Mathf.PingPong(Time.time * velocidad, alcance * 2f) - alcance;
        //ajustamos el vector para hacer el movimiento del cubo
        transform.position = origen + new Vector3(desfase, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bombero"))
        {
            //Su el jugador toca el fuego se acaba la partida
            GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
            if (gm != null) gm.Perder();
        }
    }
}
