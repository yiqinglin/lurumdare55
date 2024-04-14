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
        // If it's already placed, don't do anything.
        if (_placed) return;

        bool flag = MealManager.Instance.AddFood(gameObject.name);

        Debug.Log(flag + "flag value");
        if (Vector2.Distance(transform.position, _slot.transform.position) < 5f && flag)
        {
            transform.position = _slot.transform.position;
            _slot.Placed(); // 这里还要调用音效但是现在还没加
            _renderer.sprite = SpriteOpen;
            _placed = true;
        }
        else
        {
            transform.position = _originalPosition;
            _dragging = false;
            _source.PlayOneShot(_dropClip);
        }
    }
    // 用于场景2生成食物   
    public void SetFood() {
        _renderer.sprite = SpriteOpen;
    }
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
