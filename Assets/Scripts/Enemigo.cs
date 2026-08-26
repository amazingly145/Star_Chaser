using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform player;
    public float velocidadPersecucion = 3f;

    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, velocidadPersecucion * Time.deltaTime);
        Vector3 objetivo = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(objetivo);
        ShootAtPlayer();
        
    }

    void ShootAtPlayer(){
        bulletTime -= Time.deltaTime;

        if(bulletTime > 0) return;
        bulletTime = timer;
        //How we intialate the spawn point from the bullet
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(spawnPoint.forward * enemySpeed, ForceMode.Impulse);
        Destroy(bulletObj, 5f);
    }
}
