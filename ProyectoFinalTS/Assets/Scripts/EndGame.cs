using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class EndGame : MonoBehaviour
{

    [SerializeField] public static bool GameEnded = false;

    [SerializeField] GameObject restartButton;

    public GameObject endMenuUi;
    Text text;
    Outline outline;
    // Start is called before the first frame update
    public void GameOver()
    {
        enableMenu();
        text = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
        outline = GameObject.FindGameObjectWithTag("Message").GetComponent<Outline>();
        outline.effectColor = Color.red;
        text.text = "Game Over";
        
    }

    public void GameFinished()
    {
        enableMenu();
        text = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
        outline = GameObject.FindGameObjectWithTag("Message").GetComponent<Outline>();
        outline.effectColor = Color.green;
        text.text = "You escaped!";

    }

    void enableMenu()
    {
        endMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameEnded = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(restartButton);
        
    }

    void disAbleMenu()
    {
        endMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameEnded = false;
    }

    public void Restart()
    {
        disAbleMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        disAbleMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
