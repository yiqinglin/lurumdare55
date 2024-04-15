using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodInScenes2 : MonoBehaviour
{
    [SerializeField] private Transform _slotParent;
    [SerializeField] private List<Food> _foodPrefabs;
    private MealManager mealManager;
    void Start()
    {
        Spawn();
    }
    void Awake()
    {
        mealManager = MealManager.Instance;
    }

    void Spawn()
    {
        Ingredient[] ingredientList = (Ingredient[])Ingredient.GetValues(typeof(Ingredient));
        List<Ingredient> foodList = mealManager.nextFoods;
        for (int i = 0; i < foodList.Count; i++)
        {
            int index = (int)foodList[i];
            var spawnedFood = Instantiate(_foodPrefabs[index], _slotParent.GetChild(index).position, Quaternion.identity);
            spawnedFood.name = ingredientList[index].ToString();
            spawnedFood.SetFood();
        }
    }
}
