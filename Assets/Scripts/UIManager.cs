using UnityEngine;
using UnityEngine.UI;

//Maneja la actualizacion de la interfaz de Usuario
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    //Pantalla para el fin del juego o GameOver
    public void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

    //Pantalla de Victoria
    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
    }

    //Funcion para ocultar los Canvas
    public void HideAllScreens()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }
}
