using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnTriggerEnter (Collider other){
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
