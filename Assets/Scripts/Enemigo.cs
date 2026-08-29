using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform player;
    public float velocidadPersecucion = 3f;
    public int penalizacion = 1;

    void Update()
    {
        if (player == null) return;

        transform.position = Vector3.MoveTowards(transform.position, player.position, velocidadPersecucion * Time.deltaTime);
        Vector3 objetivo = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(objetivo);
    }
    void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
            if(gm != null) gm.Penalizar(penalizacion);
        }
    }
}