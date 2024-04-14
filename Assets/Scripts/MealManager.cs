using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MealManager : MonoBehaviour
{
    private static MealManager _instance;
    // 状态管理，判断盘子里有什么饭以及供Food脚本调用判断能不能继续加
    public List<Ingredient> nextFoods { get; private set; }

    // Important. Use a singleton MealsManager so we don't create a new one
    // every time the first screen loads.
    public static MealManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MealManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Summoning")
        {
            nextFoods = new List<Ingredient>();
        }
    }

    public bool AddFood(string food)
    {
        var parsedFood = parseFoodInput(food);

        if (nextFoods?.Count() < 2)
        {
            nextFoods.Add(parsedFood);
            return true;
        }
        else
        {
            return false;
        }
    }

    // Not used. Keeping around just in case.
    public bool RemoveFood(string food)
    {
        var parsedFood = parseFoodInput(food);
        if (nextFoods.Contains(parsedFood))
        {
            nextFoods.Remove(parsedFood);
            return true;
        }

        return false;
    }

    private Ingredient parseFoodInput(string food)
    {
        // If can't match this returns the first item in Ingreident enum.
        Enum.TryParse(food, out Ingredient parsedFood);
        return parsedFood;
    }
}
