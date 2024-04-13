using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealManager : MonoBehaviour
{
    // 状态管理，判断盘子里有什么饭以及供Food脚本调用判断能不能继续加
    // 用List在add的时候会报错，不得已用两个变量存
    private string food1 = "";
    private string food2 = "";

    private Cat[] cats = new Cat[2];

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        Debug.Log("initializing");
        // Reset everything. Probably don't need as the previous game object
        // always destroys itself on load.
        food1 = "";
        food2 = "";
        cats = new Cat[2];
    }

    public bool IncreaseFood(string food)
    {
        Debug.Log(" 返回的什么" + food);
        if (food1 == "")
        {
            food1 = food;
        }
        else if (food2 == "")
        {
            food2 = food;
        }
        else
        {
            return false;
        }
        return true;
    }

    // 计算来的是什么猫猫
    public Cat[] GetCatsBasedOnFood()
    {
        if (food1 == "Food 1(Clone)")
        {
            cats[0] = Cat.Black;
            if (food2 == "Food 2(Clone)")
            {
                cats[1] = Cat.Siamese;
            }
            else if (food2 == "Food 3(Clone)")
            {
                cats[1] = Cat.TriColor;
            }
            else if (food2 == "Food 3(Clone)")
            {
                cats[1] = Cat.White;
            }
        }
        else if (food1 == "Food 2(Clone)")
        {
            if (food2 == "Food 1(Clone)")
            {
                cats[0] = Cat.Black;
                cats[1] = Cat.Siamese;
            }
            else if (food2 == "Food 3(Clone)")
            {
                cats[0] = Cat.Siamese;
                cats[1] = Cat.Odd;

            }
        }
        else if (food1 == "Food 3(Clone)")
        {
            if (food2 == "Food 1(Clone)")
            {
                cats[0] = Cat.Black;
                cats[1] = Cat.TriColor;
            }
            else if (food2 == "Food 2(Clone)")
            {
                cats[0] = Cat.Siamese;
                cats[1] = Cat.Odd;

            }
        }
        else if (food1 == "Food 4(Clone)")
        {
            if (food2 == "Food 1(Clone)")
            {
                cats[0] = Cat.White;
            }
        }

        return cats;
    }
}
