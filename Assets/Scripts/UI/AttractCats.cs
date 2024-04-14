using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttractCats : MonoBehaviour
{

    private MealManager mealManager;
    private CatManager catManager;

    void Awake()
    {
        catManager = CatManager.Instance;
        mealManager = MealManager.Instance;
    }

    public void Attract()
    {
        if (mealManager.nextFoods.Count < 1)
        {
            Debug.Log("Not enough food selected. Intentionally doing nothing.");

            // TODO:Some kind of UI feedback?
            return;
        }

        Cat[] cats = CatLookup.GetCats(mealManager.nextFoods);

        catManager.UpdateNextCats(cats);

        // Only loads the next scene if there's at least one ingredient selected.
        SceneManager.LoadScene("OneWithCats");
    }
}
