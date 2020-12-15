using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        //Resume game time 
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
