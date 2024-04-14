using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private List<FoodSlot> _slotPrefabs;
    [SerializeField] private List<Food> _foodPrefabs;
    [SerializeField] private Food _foodPrefab;
    [SerializeField] private Transform _slotParent, _foodParent;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Ingredient[] ingredientList = (Ingredient[])Ingredient.GetValues(typeof(Ingredient));

        for (int i = 0; i < _slotPrefabs.Count; i++)
        {
            var spawnedSlot = Instantiate(_slotPrefabs[i], _slotParent.GetChild(i).position, Quaternion.identity);
            var spawnedFood = Instantiate(_foodPrefabs[i], _foodParent.GetChild(i).position, Quaternion.identity);

            // Identifiable name of the food. So it can be parsed to enum which we track in GM.
            spawnedFood.name = ingredientList[i].ToString();

            spawnedFood.Init(spawnedSlot);
        }
    }
}
