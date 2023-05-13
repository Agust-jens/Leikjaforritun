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
        Cursor.visible = false; // �etta l�tur svo �g sj�i ekki m�sina
        Cursor.lockState = CursorLockMode.Locked; //l�sir m�sina svo �g get ekki klikka�
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true; //ef �a� kemur game over mun �g sj� m�sina
            Cursor.lockState = CursorLockMode.None; //ef �a� kemur game over mun �g sj� m�sina
        }
        else
        {
            Cursor.visible = false; //ef ekki s� �g ekki m�sina
            Cursor.lockState = CursorLockMode.Locked;// ef ekki er m�sinn l�st
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // �f �g �ti � restart � game over menu mun leikurinn byrja aftur
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
