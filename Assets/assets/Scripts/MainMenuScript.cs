using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{


    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }  

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Settings()
    {
       
    }
   
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuUI");
    }

    public void Start()
    {
        
    }


}
    