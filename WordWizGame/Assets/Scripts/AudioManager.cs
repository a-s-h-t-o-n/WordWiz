using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private AudioClip restartSound;
    
    private static AudioSource audioSource;
    
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayIncorrectSound()
    {
        audioSource.PlayOneShot(incorrectSound);
    }

    public void PlayRestartSound()
    {
        audioSource.PlayOneShot(restartSound);
    }
}
