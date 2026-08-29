using UnityEngine;

public enum TipoContenido { Basura, Premio };

public class Caja : MonoBehaviour
{
    public TipoContenido tipoContenido;
    [HideInInspector] public GameObject basuraPrefab;
    [HideInInspector] public GameObject premioPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tipoContenido == TipoContenido.Premio)
            {
                if (premioPrefab != null)
                    Instantiate(premioPrefab, transform.position, Quaternion.identity);

                GameMaster gm = Object.FindFirstObjectByType<GameMaster>();
                if (gm != null) gm.Rescatar();
            }
            else // Basura
            {
                if (basuraPrefab != null)
                    Instantiate(basuraPrefab, transform.position, Quaternion.identity);
            }

            gameObject.SetActive(false);
        }
    }
}