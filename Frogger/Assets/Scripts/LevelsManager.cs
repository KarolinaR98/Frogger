using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    private int activeSceneIndex;
    void Start()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator PlayAgain()
    {       
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(activeSceneIndex);
        ResetGameManager();
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(3f);
        if (activeSceneIndex == 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(activeSceneIndex + 1);
        }
        ResetGameManager();
    }

    void ResetGameManager()
    {
        GameManager.playGame = false;
        GameManager.endOfGame = false;
        GameManager.win = false;
        GameManager.points = 0;
        GameManager.frogOnGrass = 0;
        GameManager.numOfLives = 0;
    }
}
