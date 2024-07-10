using UnityEngine;
using UnityEngine.EventSystems;

//Persecucion basica de un enemigo al jugador
public class EnemyController : MonoBehaviour
{
    private float speed = 5f;
    private GameObject player;
    private float raycastDistance = 200.0f;

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

        // Calcula la dirección hacia la que debe mirar el enemigo
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        // Raycast hacia adelante para detectar paredes
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                // Calcula una dirección perpendicular para evitar la pared
                moveDirection = Vector3.Cross(Vector3.up, moveDirection);
            }
        }

        // Mueve al enemigo en la dirección calculada
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Hace que el enemigo mire al jugador
        transform.LookAt(player.transform);

        // Destruye el GameObject del enemigo si cae por debajo de cierta altura
        if (transform.position.y < -10)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {

            // Calcula la dirección opuesta al otro enemigo
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;

            // Aplica un impulso para repeler al enemigo
            GetComponent<Rigidbody>().AddForce(repelDirection * 10f, ForceMode.Impulse);
        }
    }
}