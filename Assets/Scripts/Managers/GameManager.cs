using UnityEditor;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    // variables to track if clues have been found in each room
    [Header("Clue Tracking")]
    public bool bedroomClueFound = false;
    public bool hallwayClueFound = false;
    public bool stairsClueFound = false;
    public bool kitchenClueFound = false;
    
    // variables to track if any or all clues have been found to trigger certain events
    [Space]
    [Header("Clue States")]
    public bool anyClueFound = false;
    public bool allCluesFound = false;
    public bool shouldKeypadActivate = false;
    
    // variables for intro sequence
    [Space]
    [Header("Intro Sequence")]
    public bool introDialoguePlayed = false;


    // variables for managing scenes and transitions
    [Space]
    [Header("Scene Management")]
    public ManageScene manageScene;
    public bool cutsceneActive;
        
    private void Awake()
    {
        // creating singleton to call from anywhere
        if (instance == null)
        {
            instance = this;
            // keep sounds playing between scenes
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        manageScene = this.GetComponent<ManageScene>();
    }

    public void ResetGame()
    {
        bedroomClueFound = false;
        hallwayClueFound = false;
        stairsClueFound = false;
        kitchenClueFound = false;
        anyClueFound = false;
        allCluesFound = false;
        shouldKeypadActivate = false;
        introDialoguePlayed = false;
    }

    public void CheckClues()
    {
        if(hallwayClueFound || stairsClueFound || kitchenClueFound)
        {
            anyClueFound = true;
        } else
        {
            anyClueFound = false;
        }
        
        if(hallwayClueFound && stairsClueFound && kitchenClueFound)
        {
            allCluesFound = true;
        } else
        {
            allCluesFound = false;
        }
    }
    public void ChangeScene(string sceneName)
    {
        manageScene.PlayUISound();
        GameEvents.OnChangeScene?.Invoke(sceneName);
    }
    public void StartGame()
    {
        ResetGame();
        manageScene.LoadScene("Bedroom");
    }
    public void ExitGame()
    {
        manageScene.Quit();
    }
}
