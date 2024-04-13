using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** Keep track of what cats should show up in the next OneWithCats scene.
* Also keep track of what all cats have shown up in the game session. 
*/

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private GameManager() { } // Private constructor

    public Cat[] nextCats;
    public Cat[] catCollection;

    // Important. Use a singleton GM so we don't create a new one
    // every time the first screen loads.
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
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

        Initialize();
    }

    void Initialize()
    {
        // Reset collection of cats for a new round of play.
        catCollection = Array.Empty<Cat>();
    }

    public void UpdateNextCats(Cat[] cats)
    {
        nextCats = cats;
    }

    public Cat[] GetNextCats()
    {
        return nextCats;
    }
}