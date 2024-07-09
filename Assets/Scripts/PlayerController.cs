using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] private float moveSpeed = 5f;
    //[SerializeField] private float rotationSpeed = 700f;
    [SerializeField] private GameObject flashlight;
    private Vector3 movement, scale;
    private Rigidbody playerRb;
    private float moveVertical, moveHorizontal;
    private float timeLight = 7;
    public bool hasPowerUp = false;
    public float playerLife = 3;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        flashlight.SetActive(false);
        scale = transform.localScale;
    }

    private void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (playerLife == 0)
        {
            GameManager.instance.EndGame();
        }

    }

    void FixedUpdate()
    {

        playerRb.MovePosition(playerRb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //// Si hay movimiento, rota el jugador hacia la dirección del movimiento
        //if (movement != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { 
            collision.gameObject.SetActive(false);
            playerLife -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            hasPowerUp = true;
            flashlight.SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(timeLight);
        hasPowerUp = false;
        flashlight.SetActive(false);
        transform.localScale = scale;
    }
}
