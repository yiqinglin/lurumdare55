using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/** Keep track of what cats should show up in the next OneWithCats scene.
* Also keep track of what all cats have shown up in the game session. 
*/
public class CatManager : MonoBehaviour
{
    private static CatManager _instance;
    private CatManager() { } // Private constructor

    // Persistent throughout a run across scenes.
    // Resetted when we're back at the Summoning scene.
    public Cat[] nextCats { get; private set; }

    // All unique cats from this round of play.
    // Should never be resetted as long as the game is on.
    private HashSet<Cat> catCollection = new HashSet<Cat>();

    // Important. Use a singleton GM so we don't create a new one
    // every time the first screen loads.
    public static CatManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CatManager>();
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

    public void UpdateNextCats(Cat[] cats)
    {
        // Always replace. So we don't have to be concerned about resetting.
        nextCats = cats;

        foreach (Cat cat in nextCats)
        {
            catCollection.Add(cat);
        }

        foreach (var collected in catCollection)
        {
            Debug.Log("Collected:" + collected.ToString());
        }
    }

    public HashSet<Cat> GetCatCollection() {
        return catCollection;
    }
}