using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerController playerController;
    public float scaleFactor = 1.5f; // Factor de escala para aumentar el tama�o del jugador
    public bool hasPowerUp;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,10,0));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPowerUp)
        {
            other.transform.localScale *= scaleFactor;
            this.gameObject.SetActive(false); // Destruir el power-up despu�s de ser recogido
        }
    }
}


