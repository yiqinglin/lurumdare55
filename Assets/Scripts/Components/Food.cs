using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    // [SerializeField] private Sprite _sprite;
    public Sprite SpriteOpen;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging, _placed;
    private Vector2 _offset, _originalPosition;
    public Texture2D handCursor;
    public Texture2D pickupCursor;
    private FoodSlot _slot;

    public void Init(FoodSlot slot)
    {
        _slot = slot;
    }

    void Awake()
    {
        _originalPosition = transform.position;
        _renderer = GetComponent<SpriteRenderer>();
        setSortingLayer("package");

    }

    void Update()
    {
        if (_placed) return;
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    void OnMouseEnter()
    {
        // If food is already placed, don't show the hand cursor as it can't be moved anymore.
        if (_placed) return;
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseDown()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName != "Summoning")
        {
            return;
        }

        if (_placed) return;

        _dragging = true;
        Cursor.SetCursor(pickupCursor, Vector2.zero, CursorMode.Auto);
        _source.PlayOneShot(_pickUpClip);

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName != "Summoning")
        {
            return;
        }
        // If it's already placed, don't do anything.
        if (_placed) return;

        if (Vector2.Distance(transform.position, _slot.transform.position) < 3f)
        {
            if (MealManager.Instance.AddFood(gameObject.name))
            {
                Debug.Log("flag value true");
                transform.position = _slot.transform.position;
                _slot.Placed();
                _renderer.sprite = SpriteOpen;
                setSortingLayer("food");
                _placed = true;
                _dragging = false;
                UnsetCursor();
            }
        }
        else
        {
            Debug.Log("failed to put down");
            transform.position = _originalPosition;
            _dragging = false;
            UnsetCursor();
            _source.PlayOneShot(_dropClip);
        };
    }

    void OnMouseExit()
    {
        UnsetCursor();
    }

    private void UnsetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void SetFood()
    {
        _renderer.sprite = SpriteOpen;
        setSortingLayer("food");
    }

    private void setSortingLayer(string layerName)
    {
        _renderer.sortingLayerName = layerName;
        if (layerName == "food")
        {
            switch (name)
            {
                case "CannedFood":
                    _renderer.sortingOrder = 3;
                    break;
                case "DriedFish":
                    _renderer.sortingOrder = 2;
                    break;
                case "DryFood":
                    _renderer.sortingOrder = 0;
                    break;
                case "FoodTube":
                    _renderer.sortingOrder = 2;
                    break;
            }

        }
    }
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
