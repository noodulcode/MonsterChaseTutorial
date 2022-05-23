using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;
    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake() // a singleton pattern will allow us to only have one copy of a gameobject, this case game manager
    {
        if (instance == null)
        {
            instance = this; // created a copy of it and equal to this
            DontDestroyOnLoad(gameObject); // makes sure gamobject holding this script will not get destroyed loading the scene
        }
        else
        {
            Destroy(gameObject); // destroy duplicate
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    
    void OnLvelFinishedLoading(Scene scene, LoadSceneMode mode)
    {

    }
   
}  // class
