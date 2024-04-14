using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // public GameObject FoodTypeItem;
    // public GameObject TargetPosition;
    // public GameObject Plate;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    private bool _dragging, _placed;
    private Vector2 _offset, _originalPosition;

    private FoodSlot _slot;

    public void Init(FoodSlot slot)
    {
        // _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
    }
    void Awake()
    {
        _originalPosition = transform.position;
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

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.tag == "plate") {
    //         Debug.Log("进入盘子");
    //         // FoodTypeItem.transform.position = TargetPosition.transform.position;
    //         // if (FoodTypeItem.tag == "FoodA") {

    //         // } 
    //         // 这里放接下来的操作
    //     } 
    // }
    void OnMouseUp()
    {
        // If it's already placed, don't do anything.
        if (_placed) return;

        bool flag = MealManager.Instance.AddFood(gameObject.name);

        Debug.Log(flag + "flag value");
        if (Vector2.Distance(transform.position, _slot.transform.position) < 5f && flag)
        {
            transform.position = _slot.transform.position;
            // _slot.Placed() // 这里还要调用音效但是现在还没加
            _placed = true;
        }
        else
        {
            transform.position = _originalPosition;
            _dragging = false;
            _source.PlayOneShot(_dropClip);
        }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
