using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;

    void Update()
    {
        // Obtener las entradas del usuario
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en las entradas
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // Aplicar el movimiento al transform del jugador
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Si hay movimiento, rota el jugador hacia la dirección del movimiento
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
