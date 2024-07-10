using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private UIManager uiManager; // Referencia al UIManager desde el Inspector 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        uiManager.ShowGameOverScreen();
    }

    public void WinGame()
    {
        uiManager.ShowWinScreen();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Hola");
    }
}