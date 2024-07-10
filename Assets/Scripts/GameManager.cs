using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    [SerializeField] private GameObject uiManager; // Referencia al UIManager desde el Inspector 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

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

    private void Start()
    {
        HideAllScreens();
    }

    public void StartGame()
    {
        RenaudeGame();
        HideAllScreens();
        uiManager?.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void RenaudeGame()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        RenaudeGame();
        HideAllScreens();
        uiManager.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        gameOverPanel.SetActive(true);
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
    }

    public void LoadMainMenu()
    {
        RenaudeGame();
        HideAllScreens();
        uiManager?.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void HideAllScreens()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }
}
