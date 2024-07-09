using UnityEngine;

public class PruebaSonido : MonoBehaviour
{

    [SerializeField] AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
