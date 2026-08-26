using UnityEngine;

public class caja : MonoBehaviour
{
    void OnTriggerEnter (Collider other){
        if (other.CompareTag("Player")){
            GameMaster gm = Object.FindFirstObjectByType <GameMaster>();
            if(gm != null) gm.Rescatar();

            gameObject.SetActive(false);
        }
    }
}
