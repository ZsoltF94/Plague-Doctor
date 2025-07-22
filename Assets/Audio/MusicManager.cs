using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip music;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.Play();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
