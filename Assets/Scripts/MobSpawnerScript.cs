using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<List<GameObject>> laneObj = new List<List<GameObject>>();

    //public static List<GameObject>[] laneObj = Enumerable.Repeat(new List<GameObject>(), 4).ToArray();


    private float timer = 0f;
    private float spawnTime = 0f;

    public static float monsterSpeed = 1.3f;
    public GameObject monster;
    public float spawnLow, spawnHigh;

    public static float p_val = 0.13f;

    float[,] spawn_Probabilities = new float[2,4]
        {  {p_val, p_val, p_val, p_val},
           {0.25f, 0.25f, 0.25f, 0.25f}
        };

    bool[] isThere = new bool[4];

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            laneObj.Add(new List<GameObject>());
        }
        resetT();
    }

    float spawnT;
    // Update is called once per frame


    void Update()
    {
        if (!GameManager.gameOver)
        {
            timer += Time.deltaTime;
            p_val = (0.23f * Mathf.Log(timer + 0.5f)) + 0.1f;

            if (timer > spawnTime)
            {
                resetT();
                spawn();
            }
        }
        else
        {
            resetT();
        }
    }

    public void resetT()
    {
        timer = 0;
        float lowerBound = 2f / (0.1f * GameManager.score + 1) + 0.2f;
        spawnTime = Random.Range(lowerBound, 2*lowerBound);
    }

    public void spawn()
    {
        //reset the isTherearray

        isThere = new bool[4];

        for(int i=0; i<4; i++) // this will go through the lanes; ugly - don't put down a 3
        {
            float prob = Random.Range(0f, 1f); 
            if(prob <= spawn_Probabilities[0, i] && !isThere[i]) //if random lets you spawn, then go
            {
                isThere[i] = true;

                float isTrick = Random.Range(0f, 1f);

                int laneIndex = i;

                int[] slots = new int[3];
                for(int j=0; j<3; j++)
                {
                    if(i != j)
                    {
                        slots[j] = j;
                    }
                }
                if(isTrick < p_val/2f)
                {
                    laneIndex = slots[ (int) Random.Range(0f, 3f)];
                }
                
                var m = Instantiate(monster);

                m.GetComponent<MobScript>().lane = i;
                m.GetComponent<MobScript>().lives = 1;
                m.GetComponent<MobScript>().speed = 0.6f*Mathf.Log(GameManager.score+1) + monsterSpeed; // as score goes up, monsterSpeed should as well.

                m.GetComponent<MobScript>().type = 0;

                if(laneIndex != i && !isThere[laneIndex])
                {
                    isThere[laneIndex] = true;
                    m.GetComponent<MobScript>().type = 1;
                    m.GetComponent<MobScript>().switchTo = laneIndex;
                    Debug.Log("spawned at " + i +   ", will switch to: " + laneIndex);
                }

                laneObj[i].Add(m);

                m.transform.position = new Vector3(GameManager.lanes[i], 6, 0);
            }
        }

    }
}   
