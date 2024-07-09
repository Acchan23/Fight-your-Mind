using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method will load the game scene
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
