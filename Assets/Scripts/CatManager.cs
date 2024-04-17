using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public bool showEndingScene { get; private set; }
    public int doneWalking { get; set; }

    // All unique cats from this round of play.
    // Should never be resetted as long as the game is on.
    public HashSet<Cat> catCollection { get; private set; }
    private float startTime;
    private bool shouldCheckEndingScene = false;

    [SerializeField] private float delayTime = 3f;

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

        catCollection = new HashSet<Cat>();
    }

    public void UpdateNextCats(Cat[] cats)
    {
        // Always replace. So we don't have to be concerned about resetting.
        nextCats = cats;
        // Also reset doneWalking array.
        doneWalking = 0;

        foreach (Cat cat in nextCats)
        {
            catCollection.Add(cat);
        }

        // if (catCollection.Count == 5)
        // {
        //     showEndingScene = true;
        // }
    }

    // private void Update()
    // {
    //     if (shouldCheckEndingScene)
    //     {
    //         checkLoadEndingScene();
    //     }
    // }

    // private void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // private void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    // private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     // if (scene.name == "OneWithCats")
    //     if (scene.name == "Summoning")
    //     {
    //         // shouldCheckEndingScene = true;
    //         checkLoadEndingScene();
    //     }
    //     else
    //     {
    //         shouldCheckEndingScene = false;
    //     }
    // }

    // private void checkLoadEndingScene()
    // {
    //     // bool allCatsDoneWalking = nextCats.Count() == doneWalking;
    //     // bool doneWaiting = showEndingScene && Time.time - startTime > delayTime;

    //     if (catCollection != null && catCollection.Count() == 5)
    //     {
    //         SceneManager.LoadScene("EndScene");
    //     }
    // }
}