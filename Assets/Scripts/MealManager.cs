using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealManager : MonoBehaviour
{
    // 状态管理，判断盘子里有什么饭以及供Food脚本调用判断能不能继续加
    // 用List在add的时候会报错，不得已用两个变量存
    private string food1 = "";
    private string food2 = "";
    private string cat1 = "";
    private string cat2 = "";
    void Start()
    {
        Play();
    }
    void Play()
    {
        food1 = "";
        food2 = "";
    }
    public bool InCreaseFood(string food)
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
    public void Summoning()
    {
        if (food1 == "Food 1(Clone)")
        {
            cat1 = "CatA";
            if (food2 == "Food 2(Clone)")
            {
                cat2 = "CatB";
            }
            else if (food2 == "Food 3(Clone)")
            {
                cat2 = "CatE";
            }
            else if (food2 == "Food 3(Clone)")
            {
                cat2 = "CatD";
            }
        }
        else if (food1 == "Food 2(Clone)")
        {
            if (food2 == "Food 1(Clone)")
            {
                cat1 = "CatA";
                cat2 = "CatB";
            }
            else if (food2 == "Food 3(Clone)")
            {
                cat1 = "CatB";
                cat2 = "CatC";

            }
        }
        else if (food1 == "Food 3(Clone)")
        {
            if (food2 == "Food 1(Clone)")
            {
                cat1 = "CatA";
                cat2 = "CatE";
            }
            else if (food2 == "Food 2(Clone)")
            {
                cat1 = "CatB";
                cat2 = "CatC";

            }
        }
        else if (food1 == "Food 4(Clone)")
        {
            if (food2 == "Food 1(Clone)")
            {
                cat1 = "CatD";
            }
        }
    }
}
