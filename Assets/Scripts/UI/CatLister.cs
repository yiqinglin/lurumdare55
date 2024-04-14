using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    public Text textObject;

    void Start()
    {
        Cat[] cats = CatManager.Instance.nextCats;

        string textToDisplay = "";

        foreach (Cat cat in cats)
        {
            textToDisplay += cat.ToString() + " ";
        }

        textObject.text = textToDisplay;
    }
}
