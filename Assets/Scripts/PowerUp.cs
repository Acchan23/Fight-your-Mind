using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerController playerController;
    public float scaleFactor = 1.5f; // Factor de escala para aumentar el tamaño del jugador
    public bool hasPowerUp;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPowerUp)
        {
            other.transform.localScale *= scaleFactor;
            this.gameObject.SetActive(false); // Destruir el power-up después de ser recogido
        }
    }
}


