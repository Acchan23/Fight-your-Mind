using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private PlayerController playerController;
    public Light flashlight;
    public float lightRange = 15f;
    public LayerMask enemyLayer;
    public bool hasPowerUp;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        hasPowerUp = playerController.hasPowerUp;
    }
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleFlashlight();
        }

        if (flashlight.enabled)
        {
            DetectAndEliminateEnemies();
        }
       

    }

    void ToggleFlashlight()
    {
            flashlight.enabled = !flashlight.enabled;
    }

    void DetectAndEliminateEnemies()
    {
        RaycastHit hit;

        if (Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit, lightRange, enemyLayer))
        {
            // Comprueba si el objeto impactado tiene un EnemyController
            if (hit.collider != null)
            {
                Debug.Log("Enemigo muerto");

                hit.collider.gameObject.SetActive(false);
            }
        }
    }

}
