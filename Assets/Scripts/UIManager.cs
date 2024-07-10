using UnityEngine;
using UnityEngine.UI;

//Maneja la actualizacion de la interfaz de Usuario
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject instructionPanel;


    //Pantalla de Instrucciones
    public void ShowInstructions()
    {
        instructionPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionPanel.SetActive(false);
    }

    //Pantalla de creditos
    public void ShowCredits()
    {
        creditPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditPanel.SetActive(false);
    }

    //Funcion para ocultar los Canvas
    
}
