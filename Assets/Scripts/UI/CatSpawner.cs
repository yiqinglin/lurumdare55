using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CatSpawner : MonoBehaviour
{
    public Cat[] catsToSpawn = new Cat[] { Cat.Black };
    public Transform target; // Transform of the target the cats walk towards

    public GameObject blackCatPrefab;
    public GameObject whiteCatPrefab;
    public GameObject siameseCatPrefab;
    public GameObject gingerCatPrefab;
    public GameObject tricolorCatPrefab;

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
        Debug.Log("Spawning" + cat.ToString());
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
            case Cat.TriColor:
                catPrefab = tricolorCatPrefab;
                break;
        }

        if (catPrefab != null)
        {
            // Get a random edge position on the scene
            Vector3 spawnPoint = GetRandomEdgePosition(cat);

            // Spawn the cat and set its target
            GameObject catInstance = Instantiate(catPrefab, spawnPoint, Quaternion.identity);
            catInstance.GetComponent<CatMovement>()?.SetTarget(catPrefab.transform);
        }
    }

    Vector3 GetRandomEdgePosition(Cat cat)
    {
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x,
                                    Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
        float randomY = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y,
                                    Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);

        float randomZ = 0;


        // Override per cat.
        // Each cat has its own specific edge, so they dont cross each other when entering. 
        switch (cat)
        {
            case Cat.Black:
                // Top edge.
                randomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
                break;
            case Cat.Ginger:
                // Right edge.
                randomX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
                break;
            case Cat.White:
                // Bottom edge.
                randomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
                break;
            case Cat.TriColor:
                randomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
                break;
            case Cat.Siamese:
                // Left edge.
                randomX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
                break;
        }

        return new Vector3(randomX, randomY, randomZ);
    }
}
