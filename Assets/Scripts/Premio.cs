using UnityEngine;

public class Premio : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
            if (gm != null) gm.Rescatar();

            Destroy(gameObject);
        }
    }
}
