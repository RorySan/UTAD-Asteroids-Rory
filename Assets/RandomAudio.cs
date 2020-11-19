using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomClip()
    {
        var randomIndex = Random.Range(0, audioClips.Length);

        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
    }
}
