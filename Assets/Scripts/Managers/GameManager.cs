using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public bool bedroomClueFound = false;
    public bool hallwayClueFound = false;
    public bool stairsClueFound = false;
    public bool kitchenClueFound = false;
        
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
    }

    
}
