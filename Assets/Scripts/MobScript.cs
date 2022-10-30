using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MobScript : MonoBehaviour
{
    public Sprite[] mobTextures;
    public int type; // 0 is nontricky, 1 is tricky

    public int lane;
    public int lives;

    public int switchTo;


    public float speed;

    private Color[] monsterColors = { Color.red, Color.blue, Color.green, Color.yellow };
    private bool hasSwitched;

    
    // Start is called before the first frame update
    void Start()
    {
        //don't do anything
        //gameObject.GetComponent<SpriteRenderer>().color = monsterColors[lane];
        gameObject.GetComponent<SpriteRenderer>().sprite = mobTextures[lane];
    }

    // Update is called once per frame
    void Update()
    {
        //move bsed on score
        List<GameObject> currLane = MobSpawnerScript.laneObj[lane];
        List<GameObject> toLane = MobSpawnerScript.laneObj[switchTo];

        int id_m = currLane.IndexOf(gameObject);

        //if (lives <= 0) Destroy(this.gameObject);

        transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);

        if(transform.position.y <= 2 && !hasSwitched && type == 1) //do tricky moves
        {
            hasSwitched = true;

            currLane.Remove(gameObject);

            toLane.Insert(Math.Min(id_m, Math.Max(0, toLane.Count - 1)), gameObject);

            //lane = switchTo;

            transform.position = new Vector3(GameManager.lanes[switchTo], transform.position.y, 0);
        }

        if (transform.position.y <= -4)
        {
            GameManager.playerLives -= 1;

            if (hasSwitched)
            {
                toLane.Remove(gameObject);
            }
            else
            {
                currLane.Remove(gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
