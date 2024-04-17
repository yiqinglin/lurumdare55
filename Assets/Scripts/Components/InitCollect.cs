using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitCollect : MonoBehaviour
{
    private CatManager catManager;
    [SerializeField] private Transform _catCollect;
    [SerializeField] private List<Image> _images;
    public Sprite[] sprites;
    void Awake()
    {
        catManager = CatManager.Instance;
    }
    void Start()
    {
        InitChild();
    }

    void InitChild()
    {
        HashSet<Cat> cats = catManager.catCollection;
        foreach (int i in cats)
        {
            _images[i].sprite = sprites[i];
        }
    }
}
