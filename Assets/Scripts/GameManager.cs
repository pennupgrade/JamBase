using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static AudioSource aaron_Hurt;
    public AudioSource aH;
    public AudioSource deathSound;
    public AudioSource gameMusic;

    public TMP_Text overText;
    public TMP_Text restText;

    public static float[] lanes = { -1.17f, -0.39f, 0.39f, 1.17f };
    public static float score;
    public static int maxLives = 3;
    private int playerStartlives = 3;
    public static int playerLives;
    public static bool gameOver = false;

    public Texture[] heart_Textures;
    public RawImage[] Images;

    public TMP_Text scoreText;
    public GameObject deathScreen;

    private bool startAnim = false;
    private bool canRestart = false;
    private bool runCour = false; //i'm so tired that this ugliness could work

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float fade_speed = 0.01f;
    public float threshold = float.Epsilon;

    public bool faded = true;

    public SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        //gameMusic.Play()
        aaron_Hurt = aH;
        sprite = deathScreen.GetComponent<SpriteRenderer>();
        playerLives = playerStartlives;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            for (int i = 0; i < maxLives; i++)
            {
                int idx = 0;
                if (i >= playerLives)
                {
                    idx = 1; // 1,2<3
                }
                Images[i].texture = heart_Textures[idx];
            }

            score += Time.deltaTime;
            scoreText.text = "" + (int)(score * 10f);

            if (playerLives <= 0)
            {
                gameOver = true;
                deathSound.Play();
            }
        }
        else
        {
            //GG
            //gameMusic.Stop()
            if (!startAnim)
            {
                startAnim = true;
            }
            else if(startAnim && !canRestart && !runCour)
            {
                //score = 0; //we need to do the sequence

                float step = fade_speed * Time.deltaTime;


                if (faded)
                {
                    Debug.Log("Go");
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, maximum, step));
                    if (Mathf.Abs(maximum - sprite.color.a) <= 0.01f)
                    {
                        runCour = true;
                        faded = false;
                    }
                }
                else
                {
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, minimum, step));
                    if (Mathf.Abs(sprite.color.a - minimum) <= threshold)
                    {
                        faded = true;
                    }
                }

            }
            else if (!canRestart && runCour)
            {
                Debug.Log("Yeah");
                canRestart = true;
                StartCoroutine(ExampleCoroutine());
            }

            if (Input.GetKeyDown(KeyCode.Space) && canRestart){
                score = 0;
                startAnim = false;
                runCour = false;
                canRestart = false;
                faded = true;
                overText.gameObject.SetActive(false);
                restText.gameObject.SetActive(false);

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);

                playerLives = playerStartlives;

                //gameMusic.Play()
                gameOver = false; //it is 3 am and i think i am losing it wowza
            }

        }


    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(7); // should be 7
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        restText.text = "Score: " + (int)(score * 10f) + "\nPress space to play again!";
        overText.gameObject.SetActive(true);
        restText.gameObject.SetActive(true);
    }
}
