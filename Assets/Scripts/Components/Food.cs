using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // public GameObject FoodTypeItem;
    // public GameObject TargetPosition;
    // public GameObject Plate;
    [SerializeField] private SpriteRenderer _renderer;
    // [SerializeField] private Sprite _sprite;
    public Sprite SpriteOpen;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging, _placed;
    private Vector2 _offset, _originalPosition;

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

    void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        Debug.Log(name);
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
            }
        }
        else
        {
            Debug.Log("failed to put down");
            transform.position = _originalPosition;
            _dragging = false;
            _source.PlayOneShot(_dropClip);
        };
    }

    // 用于场景2生成食物   
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
            Debug.Log("are we here" + name);
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
