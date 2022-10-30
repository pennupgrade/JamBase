using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MobScript : MonoBehaviour
{
    public Sprite[] mobTextures;
    public int type; // 0 is nontricky, 1 is tricky

    public int lane;
    public int lives;
    public int switchTo;
    public float speed;
    public bool isDead;

    private Color[] monsterColors = { Color.red, Color.blue, Color.green, Color.yellow };
    private bool hasSwitched;

    // the disappear sequence
    public float minimum = 0.0f; 
    public float maximum = 1f;
    public float fade_speed = 5.0f;
    public float threshold = float.Epsilon;

    public bool faded = false;

    public SpriteRenderer sprite;
    private float gravity = 1f;
    private Vector3 velocityY;

    //

    // Start is called before the first frame update
    void Start()
    {
        //don't do anything
        //gameObject.GetComponent<SpriteRenderer>().color = monsterColors[lane];
        gameObject.GetComponent<SpriteRenderer>().sprite = mobTextures[lane];
        velocityY = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(0.005f, 0.02f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move bsed on score
        List<GameObject> currLane = MobSpawnerScript.laneObj[lane];
        List<GameObject> toLane = MobSpawnerScript.laneObj[switchTo];

        int id_m = currLane.IndexOf(gameObject);

        //if (lives <= 0) Destroy(this.gameObject);
        if (!isDead)
        {
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
        }
        else //you've died! time to fade away
        {
            float step = fade_speed * Time.deltaTime;

            if (faded)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, maximum, step));
                if (Mathf.Abs(maximum - sprite.color.a) <= threshold)
                    faded = false;

            }
            else
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, minimum, step));
                if (Mathf.Abs(sprite.color.a - minimum) <= threshold)
                    faded = true;
            }
            velocityY = new Vector3(velocityY.x, velocityY.y - gravity / 15 * Time.deltaTime, 0);
            transform.position += velocityY;

            Destroy(gameObject, 0.4f);
        }

        if (transform.position.y <= 2 && !hasSwitched && type == 1) //do tricky moves
        {
            hasSwitched = true;

            currLane.Remove(gameObject);

            toLane.Insert(Math.Min(id_m, Math.Max(0, toLane.Count - 1)), gameObject);

            //lane = switchTo;

            transform.position = new Vector3(GameManager.lanes[switchTo], transform.position.y, 0);
        }

        if (transform.position.y <= -4)
        {
            if (!GameManager.gameOver)
            {
                GameManager.playerLives -= 1;
                if(GameManager.playerLives > 0) GameManager.aaron_Hurt.Play();
            }
            
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
