using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerPrefab;
    
    private void Awake()
    {
        // check if manager already exists before instantiating
        if (AudioManager.instance == null)
        {
            Instantiate(audioManagerPrefab);
        }
        
    }
}
