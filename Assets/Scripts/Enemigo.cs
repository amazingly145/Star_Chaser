using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform player;
    public float velocidadPersecucion = 3f;

    void Update()
    {
        if (player == null) return;

        transform.position = Vector3.MoveTowards(transform.position, player.position, velocidadPersecucion * Time.deltaTime);
        Vector3 objetivo = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(objetivo);
    }
}