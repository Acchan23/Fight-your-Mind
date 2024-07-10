using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip hurtSfx;
    [SerializeField] private ParticleSystem lightParticle;


    private Vector3 movement, scale;
    private Rigidbody playerRb;
    private float moveVertical, moveHorizontal;
    private float timeLight = 7;
    public bool hasPowerUp = false;
    public float playerLife = 3;
    public bool isGameOver = false;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerRb = GetComponent<Rigidbody>();
        flashlight.SetActive(false);
        scale = transform.localScale;

        AudioManager.Instance.PlayMusic(backgroundMusic);
    }

    private void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        // Rotar el jugador en el eje Y basado en moveHorizontal
        if (moveHorizontal != 0)
        {
            float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }

        // Actualiza la animaciÃ³n
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            anim.SetBool("Caminar", true);
        }
        else
        {
            anim.SetBool("Caminar", false);
            //Debug.Log("Run: false");
        }


        // Actualiza el vector de movimiento para que vaya hacia adelante
        movement = transform.forward * moveVertical;

        //Condicion de GameOver
        if (playerLife == 0 && !isGameOver)
        {
            isGameOver = true;
            GameManager.instance.EndGame();
        }

    }

    void FixedUpdate()
    {

        playerRb.MovePosition(playerRb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            AudioManager.Instance.PlayEffect(hurtSfx);
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
            lightParticle.Play();
            other.gameObject.SetActive(false);
            StartCoroutine(PowerUpCountDownRoutine());
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            GameManager.instance.WinGame();
            isGameOver = true;
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(timeLight);
        hasPowerUp = false;
        flashlight.SetActive(false);
        lightParticle.Stop();
        transform.localScale = scale;
    }
}
