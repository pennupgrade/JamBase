using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] GameObject light1;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemy1;
    private Queue<GameObject> enemyQueue;

    // Start is called before the first frame update
    void Start()
    {
        enemyQueue = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light1.GetComponent<LightAlert>().lightIsOn()
             && !enemy1.GetComponent<EnemyPatrol>().enemyIsSeeking())
        {
            enemy1.GetComponent<EnemyPatrol>().startSeeking(light1);
        }


    }
}
