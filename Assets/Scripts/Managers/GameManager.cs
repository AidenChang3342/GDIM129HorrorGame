using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public bool bedroomClueFound = false;
    public bool hallwayClueFound = false;
    public bool stairsClueFound = false;
    public bool kitchenClueFound = false;
    public bool anyClueFound = false;
    public bool allCluesFound = false;
    public bool shouldKeypadActivate = false;
        
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

    public void ResetGame()
    {
        bedroomClueFound = false;
        hallwayClueFound = false;
        stairsClueFound = false;
        kitchenClueFound = false;
        anyClueFound = false;
        allCluesFound = false;
        shouldKeypadActivate = false;
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
}
