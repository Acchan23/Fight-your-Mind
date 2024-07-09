using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float scaleFactor = 1.5f; // Factor de escala para aumentar el tama�o del jugador

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.localScale *= scaleFactor;
            Destroy(gameObject); // Destruir el power-up despu�s de ser recogido
        }
    }
}


