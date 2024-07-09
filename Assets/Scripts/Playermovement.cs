using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotar hacia la derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

        // Rotar hacia la izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}