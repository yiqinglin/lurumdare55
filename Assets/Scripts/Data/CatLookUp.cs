// Lookup table mapping ingredient combinations to cat types
using System;
using System.Collections.Generic;
using UnityEngine;

public static class CatLookup
{
    private static readonly Dictionary<HashSet<Ingredient>, Cat[]> foodToCatMap = new Dictionary<HashSet<Ingredient>, Cat[]>(HashSet<Ingredient>.CreateSetComparer())
    {
        { new HashSet<Ingredient>{Ingredient.Grass}, new Cat[] { Cat.Black } },
        { new HashSet<Ingredient>{Ingredient.CannedFood}, new Cat[] {  Cat.Siamese } },
        { new HashSet<Ingredient>{Ingredient.DriedFish}, new Cat[] { Cat.Odd } },
        { new HashSet<Ingredient>{Ingredient.Slime}, new Cat[] { Cat.White } },
        { new HashSet<Ingredient>{Ingredient.Grass, Ingredient.CannedFood}, new Cat[] { Cat.Black, Cat.Siamese } },
        { new HashSet<Ingredient>{Ingredient.Grass, Ingredient.DriedFish
}, new Cat[] { Cat.Black, Cat.TriColor } },
        { new HashSet<Ingredient>{ Ingredient.Grass, Ingredient.Slime }, new Cat[] { Cat.Black, Cat.White } },
        { new HashSet<Ingredient>{ Ingredient.CannedFood, Ingredient.DriedFish }, new Cat[] { Cat.Siamese, Cat.Odd } },
        { new HashSet<Ingredient>{ Ingredient.CannedFood, Ingredient.Slime }, new Cat[] { Cat.Odd } },
        { new HashSet<Ingredient>{ Ingredient.DriedFish, Ingredient.Slime }, new Cat[] { Cat.White } }
    };

    public static Cat[] GetCats(List<Ingredient> ingredients)
    {
        Debug.Log("ingredients " + ingredients);

        foreach (var item in foodToCatMap)
        {
            Debug.Log(item.Key.ToString());
            Debug.Log(item.Value.ToString());
        }
        return foodToCatMap[new HashSet<Ingredient>(ingredients)];
    }
}