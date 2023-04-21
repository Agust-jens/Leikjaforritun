using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI; //nær í ui
    public GameObject FirstPersonController; //ná í player
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //ég get ekki notið músina þegar ég er að spila leikin
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true; // ef ég dey get ég nota músina
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
