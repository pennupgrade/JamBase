using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] AudioSource theMusic;
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
    [SerializeField] GameObject light4;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject leftSpawn;
    [SerializeField] GameObject rightSpawn;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnCooldown;
    //[SerializeField] TextMesh ;
    private Queue<GameObject> enemyQueue;
    private bool enemyQueued;
    private GameObject firstEnemy;
    public int score;
    private float timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        theMusic.Play();
        enemyQueue = new Queue<GameObject>();
        GameObject newEnemy = GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform);
        newEnemy.GetComponent<EnemyPatrol>().SetEndPoints(leftSpawn.transform, rightSpawn.transform);
        enemyQueue.Enqueue(newEnemy);
        firstEnemy = enemyQueue.Dequeue();

    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;


        if (Mathf.FloorToInt(timeCount % 60) % 10 == 0) {
            if (!enemyQueued) {
                int spawn = Random.Range(1, 3);
                enemyQueued = true;
                GameObject newEnemy = new GameObject();
                if (spawn == 1) {
                    newEnemy = GameObject.Instantiate(enemyPrefab, leftSpawn.transform.position, Quaternion.identity, this.transform);
                } else {
                    newEnemy = GameObject.Instantiate(enemyPrefab, rightSpawn.transform.position, Quaternion.identity, this.transform);
                }
                
                newEnemy.GetComponent<EnemyPatrol>().SetEndPoints(leftSpawn.transform, rightSpawn.transform);
                enemyQueue.Enqueue(newEnemy);
            }

        } else {
            enemyQueued = false; 
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

    public void addScore() {
        score += 100;
        Debug.Log(score);
    }
}
