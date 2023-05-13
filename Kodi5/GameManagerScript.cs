using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // Þetta lætur svo ég sjái ekki músina
        Cursor.lockState = CursorLockMode.Locked; //læsir músina svo ég get ekki klikkað
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true; //ef það kemur game over mun ég sjá músina
            Cursor.lockState = CursorLockMode.None; //ef það kemur game over mun ég sjá músina
        }
        else
        {
            Cursor.visible = false; //ef ekki sé ég ekki músina
            Cursor.lockState = CursorLockMode.Locked;// ef ekki er músinn læst
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // éf ég ýti á restart í game over menu mun leikurinn byrja aftur
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
