using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractCats : MonoBehaviour
{

    private MealManager mealM;
    private GameManager gameM;


    void Awake()
    {
        mealM = FindObjectOfType<MealManager>();
        gameM = GameManager.Instance;
    }

    // Use algorithm in MealManager to get cat list and save in GameManager.
    public void Attract()
    {
        Cat[] cats = mealM.GetCatsBasedOnFood();

        gameM.UpdateNextCats(cats);
    }
}
