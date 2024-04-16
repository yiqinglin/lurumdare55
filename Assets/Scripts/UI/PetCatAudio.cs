using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements (check if necessary)

public class PetCatAudio : MonoBehaviour
{
    public float fadeDuration = 0.2f; // Duration of audio fade in/out (adjust as needed)

    [SerializeField] private AudioClip _purringClip;

    private AudioSource audioSource;
    // public Texture2D handCursor; // Texture for the hand cursor (replace with your texture)
    // private CursorMode originalCursor; // Stores the original cursor mode
    private bool isHovering; // Flag to track hover state

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("PetCatAudio: Missing AudioSource component! Please add one.");
        }
        // originalCursor = Cursor.current; // Store the original cursor mode
    }

    void OnMouseEnter()
    {
        isHovering = true; // Set hover state to true on enter
        if (_purringClip)
        {
            Debug.Log("got in");
            StartCoroutine(FadeInAndRepeatAudio(_purringClip, fadeDuration));
            // Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto); // Set hand cursor
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    IEnumerator FadeInAndRepeatAudio(AudioClip clip, float duration)
    {
        Debug.Log("have we ever been here");
        audioSource.clip = clip;
        audioSource.volume = 0f;
        audioSource.loop = true; // Set loop to true for continuous playback
        audioSource.Play();

        while (audioSource.volume < 1f)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null;
        }

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
            if (!isHovering) // Check if mouse is still hovering
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