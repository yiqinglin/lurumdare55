using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _completeClip;

    public void Placed() {
        _source.PlayOneShot(_completeClip);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
