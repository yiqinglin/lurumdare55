// Lookup table mapping ingredient combinations to cat types
using System;
using System.Collections.Generic;
using UnityEngine;

public static class CatLookup
{
    private static readonly Dictionary<HashSet<Ingredient>, Cat[]> foodToCatMap = new Dictionary<HashSet<Ingredient>, Cat[]>(HashSet<Ingredient>.CreateSetComparer())
    {
        { new HashSet<Ingredient>{Ingredient.DryFood}, new Cat[] { Cat.Black } },
        { new HashSet<Ingredient>{Ingredient.DriedFish}, new Cat[] {  Cat.Siamese } },
        { new HashSet<Ingredient>{Ingredient.CannedFood}, new Cat[] { Cat.Ginger } },
        { new HashSet<Ingredient>{Ingredient.FoodTube}, new Cat[] { Cat.White } },
        { new HashSet<Ingredient>{Ingredient.DryFood, Ingredient.DriedFish}, new Cat[] { Cat.Black, Cat.Siamese } },
        { new HashSet<Ingredient>{Ingredient.DryFood, Ingredient.CannedFood
}, new Cat[] { Cat.Black, Cat.Calico } },
        { new HashSet<Ingredient>{ Ingredient.DryFood, Ingredient.FoodTube }, new Cat[] { Cat.Black, Cat.White } },
        { new HashSet<Ingredient>{ Ingredient.DriedFish, Ingredient.CannedFood }, new Cat[] { Cat.Siamese, Cat.Ginger } },
        { new HashSet<Ingredient>{ Ingredient.DriedFish, Ingredient.FoodTube }, new Cat[] { Cat.Ginger } },
        { new HashSet<Ingredient>{ Ingredient.CannedFood, Ingredient.FoodTube }, new Cat[] { Cat.White } }
    };

    public static Cat[] GetCats(List<Ingredient> ingredients)
    {
        return foodToCatMap[new HashSet<Ingredient>(ingredients)];
    }
}