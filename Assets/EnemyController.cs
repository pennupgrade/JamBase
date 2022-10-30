using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] GameObject light1;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject leftSpawn;
    [SerializeField] GameObject rightSpawn;
    [SerializeField] GameObject player;
    private Queue<GameObject> enemyQueue;
    private GameObject firstEnemy; 

    // Start is called before the first frame update
    void Start()
    { 
        enemyQueue = new Queue<GameObject>();
            enemyQueue.Enqueue(GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform));
            firstEnemy = enemyQueue.Dequeue();
     
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.N)) {
            enemyQueue.Enqueue(GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform));
        }
        if (light1.GetComponent<LightAlert>().lightIsOn() 
             && !firstEnemy.GetComponent<EnemyPatrol>().enemyIsSeeking() && !light1.GetComponent<LightAlert>().getLightHasFinder())
        {
            firstEnemy.GetComponent<EnemyPatrol>().startSeeking(light1);
            light1.GetComponent<LightAlert>().toggleLightHasFinder();
            if (enemyQueue.Count >= 1)
            {
                firstEnemy = enemyQueue.Dequeue();
            }
            else {
                enemyQueue.Enqueue(GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform));
                firstEnemy = enemyQueue.Dequeue();
            }
        }

        BroadcastMessage("CanSee", player.GetComponent<PlayerMovement>().getIsHiding());


    }
}