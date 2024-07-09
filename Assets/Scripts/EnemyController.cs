using UnityEngine;

//Persecucion basica de un enemigo al jugador
public class EnemyController : MonoBehaviour
{
    private float speed = 3.0f;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Calcula la dirección hacia la que debe mirar el enemigo
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Calcula la cantidad de movimiento basado en la velocidad y el tiempo entre fotogramas
        float moveDistance = speed * Time.deltaTime;

        // Mueve al enemigo en la dirección calculada
        transform.Translate(lookDirection * moveDistance, Space.World);

        // Destruye el GameObject del enemigo si cae por debajo de cierta altura
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}