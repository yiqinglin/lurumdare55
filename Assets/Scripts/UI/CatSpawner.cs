using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CatSpawner : MonoBehaviour
{
    public Cat[] catsToSpawn = new Cat[] { Cat.Black };

    public GameObject blackCatPrefab;
    public GameObject whiteCatPrefab;
    public GameObject siameseCatPrefab;
    public GameObject gingerCatPrefab;
    public GameObject CalicoCatPrefab;

    void Start()
    {
        Cat[] cats = CatManager.Instance.nextCats;

        foreach (Cat cat in cats)
        {
            SpawnCat(cat);
        }
    }

    void SpawnCat(Cat cat)
    {
        GameObject catPrefab = null;

        // Assign prefab based on cat type
        switch (cat)
        {
            case Cat.Black:
                catPrefab = blackCatPrefab;
                break;
            case Cat.White:
                catPrefab = whiteCatPrefab;
                break;
            case Cat.Siamese:
                catPrefab = siameseCatPrefab;
                break;
            case Cat.Ginger:
                catPrefab = gingerCatPrefab;
                break;
            case Cat.Calico:
                catPrefab = CalicoCatPrefab;
                break;
        }

        if (catPrefab != null)
        {
            // Get a edge position on the scene
            Vector3 spawnPoint = GetStartingPosition(cat);

            // Spawn the cat and set its target
            GameObject catInstance = Instantiate(catPrefab, spawnPoint, Quaternion.identity);
            catInstance.GetComponent<CatMovement>()?.SetTarget(catPrefab.transform);
        }
    }

    Vector3 GetStartingPosition(Cat cat)
    {
        // Each cat has its own specific edge, so they dont cross each other when entering.
        switch (cat)
        {
            case Cat.Black:
                return Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 1, 8));
            case Cat.Ginger:
                Debug.Log("here " + Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 8)));
                return Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 8));
            case Cat.White:
                return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 8));
            case Cat.Calico:
                return Camera.main.ViewportToWorldPoint(new Vector3(0.32f, 1, 8));
            case Cat.Siamese:
            default:
                return Camera.main.ViewportToWorldPoint(new Vector3(0, 0.25f, 8));
        }
    }
}
