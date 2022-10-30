using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
    [SerializeField] GameObject light4;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject leftSpawn;
    [SerializeField] GameObject rightSpawn;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnCooldown;
    private Queue<GameObject> enemyQueue;
    private GameObject firstEnemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyQueue = new Queue<GameObject>();
        GameObject newEnemy = GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform);
        newEnemy.GetComponent<EnemyPatrol>().SetEndPoints(leftSpawn.transform, rightSpawn.transform);
        enemyQueue.Enqueue(newEnemy);
        firstEnemy = enemyQueue.Dequeue();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N)) {
           GameObject newEnemy = GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform);
            newEnemy.GetComponent<EnemyPatrol>().SetEndPoints(leftSpawn.transform, rightSpawn.transform);
            enemyQueue.Enqueue(newEnemy);

        }

        lightQueue(light1);
        lightQueue(light2);
        lightQueue(light3);
        lightQueue(light4);
        BroadcastMessage("CanSee", player.GetComponent<PlayerMovement>().getIsHiding());


    }

    private void lightQueue(GameObject light) {
        if (firstEnemy == null && enemyQueue.Count != 0) 
        {
            firstEnemy = enemyQueue.Dequeue();
            Debug.Log("Looking for next nonNull");
        } else
        {
            if (light.GetComponent<LightAlert>().lightIsOn()
             && !firstEnemy.GetComponent<EnemyPatrol>().enemyIsSeeking() && !light.GetComponent<LightAlert>().getLightHasFinder())
            {
                firstEnemy.GetComponent<EnemyPatrol>().startSeeking(light);
                light.GetComponent<LightAlert>().toggleLightHasFinder();
                if (enemyQueue.Count >= 1)
                {
                    firstEnemy = enemyQueue.Dequeue();
                }
                else
                {
                    GameObject newEnemy = GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform);
                    newEnemy.GetComponent<EnemyPatrol>().SetEndPoints(leftSpawn.transform, rightSpawn.transform);
                    enemyQueue.Enqueue(newEnemy);
                    firstEnemy = enemyQueue.Dequeue();
                }
            }
        }
    }

    public void requeue(GameObject enemy) {
        enemyQueue.Enqueue(enemy);
    }
}
