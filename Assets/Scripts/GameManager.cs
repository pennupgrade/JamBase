using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float[] lanes = { -1.17f, -0.39f, 0.39f, 1.17f };
    public static float score;
    public static int playerLives = 3;
    public static bool gameOver = false;

    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            score += Time.deltaTime;
            if(playerLives <= 0)
            {
                gameOver = true;
            }
            scoreText.text = "" + (int) score * 100f;
        }
        else
        {
            //GG
            score = 0;
        }
    }
}
