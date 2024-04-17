using System.Collections;
using UnityEngine;

public class PetCatAudio : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 3f;

    [SerializeField] private AudioClip _purringClip;

    private AudioSource audioSource;
    private bool isHovering;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("PetCatAudio: Missing AudioSource component! Please add one.");
        }
    }

    void OnMouseEnter()
    {
        isHovering = true;
        if (_purringClip)
        {
            Debug.Log("got in");
            StartCoroutine(RepeatAudio(_purringClip));
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    IEnumerator RepeatAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = 1;
        audioSource.Play();

        // Wait for audio to finish fading in before checking for mouse exit
        while (audioSource.isPlaying)
        {
            if (!isHovering) // Check if mouse is still hovering
            {
                break;
            }
            yield return null;
        }

        audioSource.loop = false; // Disable loop when mouse exits
        StartCoroutine(FadeOutAudio(fadeDuration));
    }

    IEnumerator FadeOutAudio(float duration)
    {
        while (audioSource.isPlaying)
        {
            if (!isHovering)
            {
                break;
            }
            yield return null;
        }

        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / duration;
            yield return null;
        }

        audioSource.Stop();
    }
}