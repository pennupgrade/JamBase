using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] GameObject light1;
    [SerializeField] GameObject enemy1;

    // Start is called before the first frame update
    void Start()
    {
        
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
