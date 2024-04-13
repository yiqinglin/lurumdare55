using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private List<FoodSlot> _slotPrefabs;
    [SerializeField] private List<Food> _foodPrefabs;
    [SerializeField] private Food _foodPrefab;
    [SerializeField] private Transform _slotParent, _foodParent;

    void Start() {
        Spawn();
    }

    void Spawn() {
        for (int i = 0; i < _slotPrefabs.Count; i++) {
            var spawnedSlot = Instantiate(_slotPrefabs[i], _slotParent.GetChild(i).position, Quaternion.identity);
            var spawnedFood = Instantiate(_foodPrefabs[i], _foodParent.GetChild(i).position, Quaternion.identity);
            spawnedFood.Init(spawnedSlot);
        }
    }
}
