using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioClip walkingSoundEffect;
    public float minVelocityToPlay = 0.1f;

    private AudioSource audioSource;
    private CharacterController controller;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.velocity.magnitude > minVelocityToPlay)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(walkingSoundEffect);
                Debug.Log("Audio Played!");
            }
        }
        else
        {
            audioSource.Stop();
            Debug.Log("Audio Stopped.");
        }
    }
}
