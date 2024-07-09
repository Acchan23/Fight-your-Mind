using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionController : MonoBehaviour
{
    //This method activates the instruction panel in the scene

    public GameObject instructPanel;

    //This method activates the instruction panel in the scene
    public void ShowInstructions()
    {
        instructPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructPanel.SetActive(false);
    }

}
