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
        Cat[] cats = GetCatsBasedOnFood(mealManager.nextFoods);

        catManager.UpdateNextCats(cats);

        // Only loads the next scene if there's at least one ingredient selected.
        SceneManager.LoadScene("OneWithCats");
    }


    // 计算来的是什么猫猫
    private Cat[] GetCatsBasedOnFood(List<Ingredient> foods)
    {
        Cat[] cats = new Cat[2];

        if (foods[0] == Ingredient.Grass)
        {
            cats[0] = Cat.Black;
            if (foods[1] == Ingredient.CannedFood)
            {
                cats[1] = Cat.Siamese;
            }
            else if (foods[1] == Ingredient.DriedFish)
            {
                cats[1] = Cat.TriColor;
            }
            else if (foods[1] == Ingredient.DriedFish)
            {
                cats[1] = Cat.White;
            }
        }
        else if (foods[0] == Ingredient.CannedFood)
        {
            if (foods[1] == Ingredient.Grass)
            {
                cats[0] = Cat.Black;
                cats[1] = Cat.Siamese;
            }
            else if (foods[1] == Ingredient.DriedFish)
            {
                cats[0] = Cat.Siamese;
                cats[1] = Cat.Odd;

            }
        }
        else if (foods[0] == Ingredient.DriedFish)
        {
            if (foods[1] == Ingredient.Grass)
            {
                cats[0] = Cat.Black;
                cats[1] = Cat.TriColor;
            }
            else if (foods[1] == Ingredient.CannedFood)
            {
                cats[0] = Cat.Siamese;
                cats[1] = Cat.Odd;

            }
        }
        else if (foods[0] == Ingredient.Slime)
        {
            if (foods[1] == Ingredient.Grass)
            {
                cats[0] = Cat.White;
            }
        }

        return cats;
    }
}
