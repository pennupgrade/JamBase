using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private bool gameHasEnded = false;

    public GameObject GameOverPanel;
    public GameObject GameWonPanel;
    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            GameOverPanel.SetActive(true);

        }
    }
    public void CompleteGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            GameWonPanel.SetActive(true);
            Debug.Log("Game won!");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
 