using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CatIconStateManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image _image;
    public Sprite collectedSprite;
    public Texture2D handCursor;
    private bool isCollected = false;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _meowSoundClip;

    void Start()
    {
        CheckAndUpdateState();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isCollected)
        {
            Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        }
    }

    void UnsetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Leaving" + name);
        UnsetCursor();
    }

    private void CheckAndUpdateState()
    {
        Cat thisCat = ParseCatName();

        if (CatManager.Instance.catCollection.Contains(thisCat))
        {
            _image.sprite = collectedSprite;
            isCollected = true;
        }
    }

    private Cat ParseCatName()
    {
        // If can't match this returns the first item in Cat enum.
        Enum.TryParse(name, out Cat parsedCat);
        return parsedCat;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("on click");
        if (isCollected)
        {
            _source.PlayOneShot(_meowSoundClip);

        }
    }
}
