using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float scaleFactor = 1.5f; // Factor de escala para aumentar el tamaño del jugador

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.localScale *= scaleFactor;
            Destroy(gameObject); // Destruir el power-up después de ser recogido
        }
    }
}


