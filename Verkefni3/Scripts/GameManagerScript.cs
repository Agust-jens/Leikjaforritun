using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI; //n�r � ui
    public GameObject FirstPersonController; //n� � player
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //�g get ekki noti� m�sina �egar �g er a� spila leikin
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true; // ef �g dey get �g nota m�sina
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
        SceneManager.LoadScene(0); //loadar menu scene
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restart");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("menu");
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
