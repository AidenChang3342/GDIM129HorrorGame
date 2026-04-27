using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Name of scene to load into
    [SerializeField] private string sceneName;

    // Loads the scene based on name set in editor
    public void LoadScene()
    {
        Debug.Log("Load Scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    // Quits game
    public void Quit()
    {
        Debug.Log("Quitting game");

        /* if in-editor, stops playing
           if in real build, exits application */
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();      
        }
      
    }
}
