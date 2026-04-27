using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void Play()
    {
        Debug.Log("Load Scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Debug.Log("Quitting game");
        Application.Quit();            
    }
}
