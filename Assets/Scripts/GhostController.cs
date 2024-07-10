using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private float speed = 2.5f;
    private GameObject player;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        // Calcula la dirección hacia la que debe mirar el fantasma
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        moveDirection.y = 0f; // Establece el componente Y a cero para mantener la rotación en Y constante

        // Mueve al fantasma en la dirección calculada
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Mantiene la rotación del fantasma en Y constante
        transform.rotation = Quaternion.LookRotation(moveDirection);

        // Destruye el GameObject del enemigo si cae por debajo de cierta altura
        if (transform.position.y < -10)
        {
            gameObject.SetActive(false);
        }
    }
}
