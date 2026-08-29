using UnityEngine;

public class Basura : MonoBehaviour
{
    public int penalizacion = 1; 

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