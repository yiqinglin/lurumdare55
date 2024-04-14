using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _hoverClip, clickClip;

    public void HoverSound() {
        _source.PlayOneShot(_hoverClip);
    }
    public void ClickSound() {
        _source.PlayOneShot(_hoverClip);
    }
}
